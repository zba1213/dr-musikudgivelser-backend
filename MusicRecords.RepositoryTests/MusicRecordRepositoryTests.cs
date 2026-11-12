using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicRecords.Api;

[assembly: DoNotParallelize]

namespace MusicRecords.RepositoryTests;

[TestClass]
public class MusicRecordRepositoryTests
{
    [TestMethod]
    public void GetAll_ReturnsEveryRecordWithItsDetails()
    {
        var repository = new MusicRecordRepository([
            new() { Id = 10, Title = "Aften", Artist = "Nord", Duration = 90, PublicationYear = 2020 },
            new() { Id = 20, Title = "Morgen", Artist = "Syd", Duration = 120, PublicationYear = 2022 }
        ]);

        var records = repository.GetAll();

        Assert.HasCount(2, records);
        AssertRecord(records[0], 10, "Aften", "Nord", 90, 2020);
        AssertRecord(records[1], 20, "Morgen", "Syd", 120, 2022);
    }

    [TestMethod]
    public void GetAll_ReturnsEmptyListWhenThereAreNoRecords()
    {
        var repository = new MusicRecordRepository([]);

        Assert.IsEmpty(repository.GetAll());
    }

    [TestMethod]
    [DataRow("  fTe  ", null, new int[] { 10, 20 })]
    [DataRow(null, "  nOr  ", new int[] { 10, 30 })]
    [DataRow("fTe", "nOr", new int[] { 10 })]
    [DataRow("Aften", "Øst", new int[] { })]
    [DataRow("Udgivelsen findes ikke", null, new int[] { })]
    [DataRow(null, "Kunstneren findes ikke", new int[] { })]
    [DataRow("", "   ", new int[] { 10, 20, 30 })]
    public void GetAll_FiltersByTitleAndArtist(string? title, string? artist, int[] expectedIds)
    {
        var repository = new MusicRecordRepository([
            new() { Id = 10, Title = "Aften", Artist = "Nord" },
            new() { Id = 20, Title = "Efter Aften", Artist = "Syd" },
            new() { Id = 30, Title = "Morgen", Artist = "Nordlys" }
        ]);

        var records = repository.GetAll(title, artist);

        CollectionAssert.AreEqual(expectedIds, records.Select(record => record.Id).ToArray());
    }

    private static void AssertRecord(MusicRecord record, int id, string title, string artist, int duration, int year)
    {
        Assert.AreEqual(id, record.Id);
        Assert.AreEqual(title, record.Title);
        Assert.AreEqual(artist, record.Artist);
        Assert.AreEqual(duration, record.Duration);
        Assert.AreEqual(year, record.PublicationYear);
    }
}
