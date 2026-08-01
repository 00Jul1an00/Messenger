using System.ComponentModel.DataAnnotations;
using Messenger.Domain;
using Messenger.Application.Interfaces;

namespace Messenger.Application.Services;

internal sealed class MessageService(IMessageRepository messageRepository, TimeProvider clock) : IMessageService
{
    public async Task<Message> CreateAsync(string content, CancellationToken ct)
    {
        if(string.IsNullOrWhiteSpace(content))
            throw new ValidationException("Content is required");

        var message = new Message(content, clock.GetUtcNow());
        return await messageRepository.AddAsync(message, ct);
    }

    public async Task<IEnumerable<Message>> GetAllAsync(CancellationToken ct)
    {
        return await messageRepository.GetAllAsync(ct);
    }

    public async Task<Message> GetByIdAsync(Guid id, CancellationToken ct)
    {
        return await messageRepository.GetByIdAsync(id, ct);
    }
}