namespace Messenger.Domain;

public sealed record Message(string? Content, DateTimeOffset SendTimestamp)
{
    public Guid Id { get; init; }
}

