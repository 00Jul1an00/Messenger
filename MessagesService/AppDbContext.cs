using Microsoft.EntityFrameworkCore;

namespace MessagesService
{
    public sealed class AppDbContext : DbContext
    {
        public DbSet<MessageEntity> Messages => Set<MessageEntity>();

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=messages.db");
        }
    }
}
