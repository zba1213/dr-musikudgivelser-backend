namespace MusicRecords.Api;

public class MusicRecord
{
    public int Id { get; init; }
    public string Title { get; init; } = "";
    public string Artist { get; init; } = "";
    public int Duration { get; init; }
    public int PublicationYear { get; init; }
}
