using Messenger.Api.MessageMapping;
using Messenger.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Messenger.Api;

[ApiController]
[Route("api/messages")]
public sealed class MessageController(IMessageService messages) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateMessageRequest content, CancellationToken cancellationToken)
    {
        var message = await messages.CreateAsync(content.Content, cancellationToken);
        return CreatedAtRoute(nameof(GetByIdAsync), new { id = message.Id }, message.ToResponse());
    }

    [HttpGet("{id:guid}", Name = "GetByIdAsync")]
    public async Task<IActionResult> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var message = await messages.GetByIdAsync(id, cancellationToken);
        return Ok(message.ToResponse());
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
    {
        var message = await messages.GetAllAsync(cancellationToken);
        return Ok(message.Select(m => m.ToResponse()));
    }
}