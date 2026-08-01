using Messenger.Domain;

namespace Messenger.Application.Interfaces;

public interface IMessageService
{
    public Task<Message> CreateAsync(string content, CancellationToken ct);
    public Task<Message> GetByIdAsync(Guid id, CancellationToken ct);
    public Task<IEnumerable<Message>> GetAllAsync(CancellationToken ct);
}