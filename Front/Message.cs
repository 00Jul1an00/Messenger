namespace Front;

public sealed class Message
{
    public Guid Id { get; init; }
    public required string Content { get; init; }
    public DateTime SendTimestamp { get; init; }
}