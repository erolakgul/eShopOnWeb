using AutoMapper;
using Microsoft.eShopWeb.ApplicationCore.Entities;
using Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate;
using Microsoft.eShopWeb.PublicApi.CatalogBrandEndpoints;
using Microsoft.eShopWeb.PublicApi.CatalogItemEndpoints;
using Microsoft.eShopWeb.PublicApi.CatalogTypeEndpoints;
using Microsoft.eShopWeb.PublicApi.OrderEndPoints;
using Microsoft.eShopWeb.PublicApi.OrderStatusEndPoints;
using Address = Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate.Address;
using Order = Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate.Order;
using OrderStatus = Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate.OrderStatus;

namespace Microsoft.eShopWeb.PublicApi;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CatalogItem, CatalogItemDto>();
        CreateMap<CatalogType, CatalogTypeDto>()
            .ForMember(dto => dto.Name, options => options.MapFrom(src => src.Type));
        CreateMap<CatalogBrand, CatalogBrandDto>()
            .ForMember(dto => dto.Name, options => options.MapFrom(src => src.Brand));

        #region Order
        CreateMap<OrderStatus, OrderStatusDto>();
        CreateMap<Order, OrderDto>();
            //.ForMember(dto => dto.ShipToAddress, 
            //                  options
            //               => options.MapFrom(src => src.ShipToAddress));
        CreateMap<Address, BlazorShared.Models.Orders.Address>();
        CreateMap<OrderItem, OrderItemDto>();
        CreateMap<CatalogItemOrdered,BlazorShared.Models.Orders.CatalogItemOrdered> ();
        #endregion
    }
}
