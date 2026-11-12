namespace MusicRecords.Api;

public class MusicRecordRepository
{
    private readonly List<MusicRecord> records;

    public MusicRecordRepository() : this([
        new() { Id = 1, Title = "Hej Matematik", Artist = "Hej Matematik", Duration = 212, PublicationYear = 2007 },
        new() { Id = 2, Title = "Hjertestarter", Artist = "Nephew", Duration = 281, PublicationYear = 2012 },
        new() { Id = 3, Title = "Malibu", Artist = "Anderson .Paak", Duration = 3692, PublicationYear = 2016 }
    ])
    {
    }

    public MusicRecordRepository(IEnumerable<MusicRecord> records)
    {
        this.records = records.ToList();
    }

    public IReadOnlyList<MusicRecord> GetAll()
    {
        return records.AsReadOnly();
    }
}
