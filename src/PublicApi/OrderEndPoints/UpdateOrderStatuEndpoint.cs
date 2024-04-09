using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using Microsoft.eShopWeb.ApplicationCore.Specifications.Orders;
using MinimalApi.Endpoint;

namespace Microsoft.eShopWeb.PublicApi.OrderEndPoints;

/// <summary>
/// Updates a Order Statu
/// </summary>
public class UpdateOrderStatuEndpoint : IEndpoint<IResult, UpdateOrderStatuRequest, IRepository<Order>>
{
    private IMapper _mapper;

    public UpdateOrderStatuEndpoint(IMapper mapper)
    {
        _mapper = mapper;
    }

    public void AddRoute(IEndpointRouteBuilder app)
    {
        app.MapPut("api/order-items",
            
            [Authorize(Roles = BlazorShared.Authorization.Constants.Roles.ADMINISTRATORS, AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)] async
            (UpdateOrderStatuRequest request, IRepository<Order> itemRepository) =>
            {
                return await HandleAsync(request, itemRepository);
            })
            .Produces<UpdateOrderStatuResponse>()
            .WithTags("OrderItemEndpoints");
    }

    public async Task<IResult> HandleAsync(UpdateOrderStatuRequest request, IRepository<Order> orderRepository)
    {
        var response = new UpdateOrderStatuResponse(request.CorrelationId());

        var spec = new OrderWithItemsByIdSpecification
          (
             orderId: request.Id
          );

        var existingItem = await orderRepository.FirstOrDefaultAsync(spec, CancellationToken.None);

        if (existingItem == null)
        {
            return Results.NotFound();
        }

        // statu güncelle
        existingItem.UpdateStatus(request.OrderStatusId);

        await orderRepository.UpdateAsync(existingItem);

        response.Order = _mapper.Map<OrderDto>(existingItem);

        return Results.Ok(response);
    }
}
