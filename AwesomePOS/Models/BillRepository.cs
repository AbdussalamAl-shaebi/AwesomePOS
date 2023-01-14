using Microsoft.EntityFrameworkCore;
using SqliteWasmHelper;

namespace AwesomePOS.Models;

public class BillRepository
{
    private readonly ISqliteWasmDbContextFactory<AppLocalContext> _db;

    public BillRepository(ISqliteWasmDbContextFactory<AppLocalContext> db)
    {
        _db = db;
    }
   

    public async Task<Bill> Save(Bill bill)
    {
        using var dbContext = await _db.CreateDbContextAsync();
        var mst = bill.BillMaster;
        var dtl = bill.BillDetail;

        if (mst?.Id == default)
        {
            await dbContext.BillMasters.AddAsync(mst);
            await dbContext.BillDetails.AddRangeAsync(dtl);
            await dbContext.SaveChangesAsync();
        }
        
        return bill;
    }


    public async Task<BillMaster> Delete(BillMaster bill)
    {

        using var dbContext = await _db.CreateDbContextAsync();
        await dbContext.BillMasters.Where(m=>m.Id == bill.Id).ExecuteDeleteAsync();
        await dbContext.BillDetails.Where(d=>d.BillMasterId == bill.Id).ExecuteDeleteAsync();
        await dbContext.SaveChangesAsync();
        return bill;
    }
}
