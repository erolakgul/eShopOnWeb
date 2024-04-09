using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorShared.Interfaces.Orders;
using BlazorShared.Models.Orders;
using Microsoft.Extensions.Logging;

namespace BlazorAdmin.Services.Orders;

public class OrderService : IOrderService
{
    private readonly IOrderLookupDataService<OrderStatus> _orderStatusService;
    private readonly HttpService _httpService;
    private readonly ILogger<CatalogItemService> _logger;

    public OrderService(IOrderLookupDataService<OrderStatus> orderStatusService,
        HttpService httpService,
        ILogger<CatalogItemService> logger)
    {
        _orderStatusService = orderStatusService;
        _httpService = httpService;
        _logger = logger;
    }

    public async Task<Order> Edit(Order order)
    {
        return (await _httpService.HttpPut<EditOrderResult>("order-items", order)).Order;
    }

    public async Task<Order> GetById(int id)
    {
        var orderStatusListTask = _orderStatusService.List();
        var itemGetTask = _httpService.HttpGet<EditOrderResult>($"order-items/{id}");

        await Task.WhenAll(orderStatusListTask, itemGetTask);

        var orderStatus = orderStatusListTask.Result;

        var orderItem = itemGetTask.Result.Order;

        orderItem.OrderStatus = orderStatus.FirstOrDefault(b => b.Id == orderItem.OrderStatusId)?.Name;

        return orderItem;
    }

    public async Task<List<Order>> List()
    {
        _logger.LogInformation("Fetching order items from API.");

        #region lookup tan çek
        var orderStatusListTask = _orderStatusService.List();
        #endregion

        #region api den çek
        var itemListTask = _httpService.HttpGet<PagedOrderResponse>($"order-items"); 
        #endregion

        await Task.WhenAll(orderStatusListTask, itemListTask);

        var orderStatus = orderStatusListTask.Result;

        var orderList = itemListTask.Result.Orders;

        foreach (var item in orderList)
        {
            item.OrderStatus = orderStatus.FirstOrDefault(b => b.Id == item.OrderStatusId)?.Name;
            item.TotalPrice = item.Total();
        }

        return orderList;
    }
}
