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
/// Get a Order with Items by Id
/// </summary>
public class OrderGetByIdEndPoints : IEndpoint<IResult, GetByIdOrderRequest, IRepository<Order>>
{
    private readonly IMapper _mapper;

    public OrderGetByIdEndPoints(IMapper mapper)
    {
        _mapper = mapper;
    }

    public void AddRoute(IEndpointRouteBuilder app)
    {
        app.MapGet("api/order-items/{orderId}",
           async (int orderId, IRepository<Order> orderRepository) =>
           {
               return await HandleAsync(new GetByIdOrderRequest(orderId), orderRepository);
           })
           .Produces<GetByIdOrderResponse>()
           .WithTags("OrderItemEndpoints");
    }

    public async Task<IResult> HandleAsync(GetByIdOrderRequest request, IRepository<Order> orderRepository)
    {
        var response = new GetByIdOrderResponse(request.CorrelationId());

        var spec = new OrderWithItemsByIdSpecification
            (
              orderId : request.OrderId
            );

        var item = await orderRepository.FirstOrDefaultAsync(spec);

        if (item is null)
            return Results.NotFound();

        response.Order = _mapper.Map<OrderDto>(item);

        return Results.Ok(response);
    }
}
