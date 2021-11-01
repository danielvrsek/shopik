using Facades.Shop;
using Microsoft.Extensions.DependencyInjection;
using Shopik.Shared.Shop;
using VrsekDev.Blazor.BlazorCommunicationFoundation.Server.Abstractions.DependencyInjection;

namespace Facades
{
    public static class FacadeInstaller
    {
        public static void AddFacades(this IServerContractCollection services)
        {
            services.AddScoped<IShopItemFacade, ShopItemFacade>();
        }
    }
}
