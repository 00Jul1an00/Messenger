namespace Messenger.Api.MessageMapping;

public static class MessageMappings
{
    public static MessageResponse ToResponse(this Domain.Message message)
    {
        return new MessageResponse(message.Id, message.Content, message.SendTimestamp);
    }
}