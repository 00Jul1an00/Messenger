using Microsoft.EntityFrameworkCore;

namespace Messenger.Infrastructure;

internal sealed class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<MessageEntity> Messages => Set<MessageEntity>();
}