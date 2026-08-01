using Messenger.Domain;

namespace Messenger.Application.Interfaces;

public interface IMessageRepository
{
    public Task<IEnumerable<Message>> GetAllAsync(CancellationToken ct);
    public Task<Message> GetByIdAsync(Guid id, CancellationToken ct);
    public Task<Message> AddAsync(Message message, CancellationToken ct);
}

