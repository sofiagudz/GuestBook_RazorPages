using Microsoft.EntityFrameworkCore;

namespace GuestBook_RazorPages.Models
{
    public class GuestBookContext : DbContext
    {
        public GuestBookContext(DbContextOptions<GuestBookContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}
