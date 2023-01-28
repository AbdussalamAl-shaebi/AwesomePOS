using AwesomePOS;
using AwesomePOS.Models;
using Fluxor;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.EntityFrameworkCore;
using MudBlazor;
using MudBlazor.Services;
using SqliteWasmHelper;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.Services.AddSqliteWasmDbContextFactory<AppLocalContext>(
    opts => opts.UseSqlite("Data Source=things.sqlite3"));
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddFluxor(o =>
{
    o.ScanAssemblies(typeof(App).Assembly);
#if DEBUG
    o.UseReduxDevTools();
#endif
});
builder.Services.AddSingleton<ProductRepository>();
builder.Services.AddSingleton<BillRepository>();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddMudServices(config =>
{
    config.SnackbarConfiguration.PreventDuplicates = false;
    config.SnackbarConfiguration.NewestOnTop = false;
    config.SnackbarConfiguration.ShowCloseIcon = true;
    config.SnackbarConfiguration.VisibleStateDuration = 1000;
    config.SnackbarConfiguration.HideTransitionDuration = 100;
    config.SnackbarConfiguration.ShowTransitionDuration = 100;
    config.SnackbarConfiguration.SnackbarVariant = Variant.Outlined;
});
await builder.Build().RunAsync();
