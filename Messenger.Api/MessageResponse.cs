namespace Messenger.Api;

public sealed record MessageResponse(Guid Id, string Content, DateTimeOffset SendTimestamp)
{
}
