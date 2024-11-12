using Microsoft.EntityFrameworkCore;
using Promomash.Entities.User;

namespace Promomash.Database
{
    public class PromomashContext : DbContext
    {
        public PromomashContext(DbContextOptions<PromomashContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
