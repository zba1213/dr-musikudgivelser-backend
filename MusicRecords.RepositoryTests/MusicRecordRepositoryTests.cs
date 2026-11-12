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

    private static void AssertRecord(MusicRecord record, int id, string title, string artist, int duration, int year)
    {
        Assert.AreEqual(id, record.Id);
        Assert.AreEqual(title, record.Title);
        Assert.AreEqual(artist, record.Artist);
        Assert.AreEqual(duration, record.Duration);
        Assert.AreEqual(year, record.PublicationYear);
    }
}
