using Messenger.Application.Interfaces;
using Messenger.Domain;
using Microsoft.EntityFrameworkCore;

namespace Messenger.Infrastructure;

internal sealed class MessageRepository(AppDbContext context) : IMessageRepository
{
    public async Task<Message> AddAsync(Message message, CancellationToken ct)
    {
        var messageEntity = new MessageEntity()
        {
            Id = message.Id,
            Content = message.Content,
            SendTimestamp = message.SendTimestamp
        };
        
        await context.Messages.AddAsync(messageEntity, ct);
        await context.SaveChangesAsync(ct);
        
        return message;
    }

    public async Task<IEnumerable<Message>> GetAllAsync(CancellationToken ct)
    {
        var messageEntities = await context.Messages.ToListAsync(ct);

        return messageEntities.Select(m => new Message(m.Content, m.SendTimestamp));
    }

    public async Task<Message> GetByIdAsync(Guid id, CancellationToken ct)
    {
        var messageEntity = await context.Messages.FindAsync(id, ct);
        var message = new Message(messageEntity.Content, messageEntity.SendTimestamp);

        return message;
    }
}