using Microsoft.EntityFrameworkCore;

namespace AwesomePOS.Models
{
    public class AppLocalContext: DbContext
    {
        public AppLocalContext(DbContextOptions<AppLocalContext> opts) : base(opts)
        {

        }

        public DbSet<Product> Products { get; set; } = null!;
    }
}
