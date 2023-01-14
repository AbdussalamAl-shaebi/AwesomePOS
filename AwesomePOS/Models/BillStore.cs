using Fluxor;
namespace AwesomePOS.Models;

public record BillsSaveAction(Bill Bill);

public class BillsEffects
{
    private readonly BillRepository _repo;

    public BillsEffects(BillRepository repo)
    {
        _repo = repo;
    }

    [EffectMethod]
    public async Task Save(BillsSaveAction action, IDispatcher dispatcher)
    {
        await _repo.Save(action.Bill);
    }
 
}