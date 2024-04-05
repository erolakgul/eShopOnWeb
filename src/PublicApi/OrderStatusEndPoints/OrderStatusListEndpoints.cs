using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using Microsoft.Extensions.Logging;
using MinimalApi.Endpoint;

namespace Microsoft.eShopWeb.PublicApi.OrderStatusEndPoints;

/// <summary>
/// List Order Status
/// </summary>
public class OrderStatusListEndpoints : IEndpoint<IResult, IRepository<OrderStatus>>
{
    private readonly IMapper _mapper;
    private ILogger<OrderStatusListEndpoints> _logger;

    public OrderStatusListEndpoints(IMapper mapper, ILogger<OrderStatusListEndpoints> logger)
    {
        _mapper = mapper;
        _logger = logger;
    }

    public void AddRoute(IEndpointRouteBuilder app)
    {
        app.MapGet("api/order-status",
            async (IRepository<OrderStatus> orderStatusRepository) =>
            {
                return await HandleAsync(orderStatusRepository);
            })
            .Produces<ListOrderStatusResponse>()
            .WithTags("OrderStatusEndpoints");
    }

    public async Task<IResult> HandleAsync(IRepository<OrderStatus> orderStatusRepository)
    {
        var response = new ListOrderStatusResponse();

        var items = await orderStatusRepository.ListAsync();

        response.OrderStatus.AddRange(items.Select(_mapper.Map<OrderStatusDto>));

        return Results.Ok(response);
    }
}
