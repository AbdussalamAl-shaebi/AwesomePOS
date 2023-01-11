using Microsoft.EntityFrameworkCore;
using SqliteWasmHelper;

namespace AwesomePOS.Models;

public class ProductRepository
{
    private readonly ISqliteWasmDbContextFactory<AppLocalContext> _db;

    public ProductRepository(ISqliteWasmDbContextFactory<AppLocalContext> db)
    {
        _db = db;
    }
    public async Task<Product[]> Get()
    {
        using var dbContext = await _db.CreateDbContextAsync();
        var items = await dbContext.Products.ToArrayAsync();
        return items;
    }

    public async Task<Product> Save(Product product)
    {
        using var dbContext = await _db.CreateDbContextAsync();
        
        if (product.Id == default)
        {
            await dbContext.Products.AddAsync(product);
            await dbContext.SaveChangesAsync();
        }
        else
        {
            var tracking = dbContext.Products.Attach(product);
            tracking.State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }
        return product;
    }


    public async Task<Product> Delete(Product product)
    {
        using var dbContext = await _db.CreateDbContextAsync();
        var tracking = dbContext.Products.Attach(product);
        tracking.State = EntityState.Deleted;
        await dbContext.SaveChangesAsync();
        return product;
    }


}

