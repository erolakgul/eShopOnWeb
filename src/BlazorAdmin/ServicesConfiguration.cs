using BlazorAdmin.Services;
using BlazorAdmin.Services.Orders;
using BlazorShared.Interfaces;
using BlazorShared.Interfaces.Orders;
using BlazorShared.Models;
using BlazorShared.Models.Orders;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorAdmin;

public static class ServicesConfiguration
{
    public static IServiceCollection AddBlazorServices(this IServiceCollection services)
    {

        #region catalog brand-type service injection
        services.AddScoped<ICatalogLookupDataService<CatalogBrand>, CachedCatalogLookupDataServiceDecorator<CatalogBrand, CatalogBrandResponse>>();
        services.AddScoped<CatalogLookupDataService<CatalogBrand, CatalogBrandResponse>>();

        services.AddScoped<ICatalogLookupDataService<CatalogType>, CachedCatalogLookupDataServiceDecorator<CatalogType, CatalogTypeResponse>>();
        services.AddScoped<CatalogLookupDataService<CatalogType, CatalogTypeResponse>>();
        #endregion

        #region catalog service injection
        services.AddScoped<ICatalogItemService, CachedCatalogItemServiceDecorator>();
        services.AddScoped<CatalogItemService>();
        #endregion


        #region orderstatus service injection
        services.AddScoped<IOrderLookupDataService<OrderStatus>, CachedOrderLookupDataServiceDecorator<OrderStatus, OrderStatusResponse>>();
        services.AddScoped<OrderLookupDataService<OrderStatus, OrderStatusResponse>>();
        #endregion

        #region order service injection
        services.AddScoped<IOrderService, CachedOrderServiceDecorator>();
        services.AddScoped<OrderService>();
        #endregion


        return services;
    }
}
