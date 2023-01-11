using Fluxor;

namespace AwesomePOS.Models;

public record ProductsLoadAction();
public record ProductsSetAction(Product[] Products);
public record ProductsSaveAction(Product Product);
public record ProductsOnAddAction(Product Parcode);
public record ProductsDeleteAction(Product Product);

public record ProductsState
{
    public Product[] Products { get; init; }
}

public class ProductsFeature : Feature<ProductsState>
{
    public override string GetName() => "Products";

    protected override ProductsState GetInitialState()
    {
        return new ProductsState
        {
            Products = Array.Empty<Product>()
        };
    }
}

public static class UnitsReducers
{

    [ReducerMethod]
    public static ProductsState OnSetUnits(ProductsState state, ProductsSetAction action)
    {
        return state with
        {
            Products = action.Products,
        };
    }

    [ReducerMethod]
    public static ProductsState OnUnitAdd(ProductsState state, ProductsOnAddAction action)
    {
        var list = state.Products.ToList();
        list.Add(action.Parcode);

        var newList = list
               .ToArray();

        return state with
        {
            Products = newList
        };
    }
}

public class ProductsEffects
{
    private readonly ProductRepository _repo;

    public ProductsEffects(ProductRepository repo)
    {
        _repo = repo;
    }

    [EffectMethod(typeof(ProductsLoadAction))]
    public async Task OnLoadProducts(IDispatcher dispatcher)
    {
        var list = await _repo.Get();
        dispatcher.Dispatch(new ProductsSetAction(list));
    }

    [EffectMethod]
    public async Task Save(ProductsSaveAction action, IDispatcher dispatcher)
    {
        var isNew = action.Product.Id == default;

        var item = await _repo.Save(action.Product);

        if (isNew)
        {
            dispatcher.Dispatch(new ProductsOnAddAction(item));
        }
        else
        {
            //dispatcher.Dispatch(new UnitsUpdateAction(unt));
        }
    }


    [EffectMethod]
    public async Task Delete(ProductsDeleteAction action, IDispatcher dispatcher)
    {
        var item = await _repo.Delete(action.Product);
    }
}
