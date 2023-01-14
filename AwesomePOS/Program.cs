using AwesomePOS;
using AwesomePOS.Models;
using Fluxor;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.EntityFrameworkCore;
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
builder.Services.AddMudServices();

await builder.Build().RunAsync();
