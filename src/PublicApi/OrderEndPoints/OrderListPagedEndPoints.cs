using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using Microsoft.eShopWeb.ApplicationCore.Specifications.Orders;
using MinimalApi.Endpoint;

namespace Microsoft.eShopWeb.PublicApi.OrderEndPoints;

/// <summary>
/// List Order Items (paged)
/// </summary>
public class OrderListPagedEndPoints : IEndpoint<IResult, ListPagedOrderRequest, IRepository<Order>>
{
    private readonly IMapper _mapper;

    public OrderListPagedEndPoints(IMapper mapper)
    {
        _mapper = mapper;
    }

    public void AddRoute(IEndpointRouteBuilder app)
    {
        app.MapGet("api/order-items",
            async (int? pageSize, int? pageIndex, int? orderStatusId, IRepository<Order> itemRepository) =>
            {
                return await HandleAsync(new ListPagedOrderRequest(pageSize, pageIndex, orderStatusId), itemRepository);
            })
            .Produces<ListPagedOrderResponse>()
            .WithTags("OrderItemEndpoints");
    }

    public async Task<IResult> HandleAsync(ListPagedOrderRequest request, IRepository<Order> itemRepository)
    {
        var response = new ListPagedOrderResponse(request.CorrelationId());

        var filterSpec = new OrderFilterSpecification(request.OrderStatusId);
        int totalItems = await itemRepository.CountAsync(filterSpec);

        var pagedSpec = new OrderFilterPaginatedSpecification(
            skip: request.PageIndex * request.PageSize,
            take: request.PageSize,
            orderStatusId: request.OrderStatusId);

        var items = await itemRepository.ListAsync(pagedSpec);

        response.Orders.AddRange(items.Select(_mapper.Map<OrderDto>));
  
        if (request.PageSize > 0)
        {
            response.PageCount = int.Parse(Math.Ceiling((decimal)totalItems / request.PageSize).ToString());
        }
        else
        {
            response.PageCount = totalItems > 0 ? 1 : 0;
        }

        return Results.Ok(response);
    }
}
