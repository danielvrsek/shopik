using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Shopik.Client;
using Shopik.Shared.Shop;
using VrsekDev.Blazor.BlazorCommunicationFoundation.Client.DependencyInjection;
using VrsekDev.Blazor.BlazorCommunicationFoundation.Serializers.Json;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddBCFClient(builder =>
{
    builder.Contracts.AddContract<IShopItemFacade>();
    builder.UseSerializer<JsonInvocationSerializer>();
});

await builder.Build().RunAsync();
