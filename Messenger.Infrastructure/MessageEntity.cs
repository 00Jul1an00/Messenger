namespace Messenger.Infrastructure;

public sealed class MessageEntity
{
    public Guid Id { get; init; }
    public string? Content { get; init; }
    public DateTimeOffset SendTimestamp { get; init; }
}

