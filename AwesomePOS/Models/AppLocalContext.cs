using Microsoft.EntityFrameworkCore;

namespace AwesomePOS.Models;

public class AppLocalContext: DbContext
{
    public AppLocalContext(DbContextOptions<AppLocalContext> opts) : base(opts)
    {

    }

    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<BillMaster> BillMasters { get; set; } = null!;
    public DbSet<BillDetail> BillDetails { get; set; } = null!;
}
