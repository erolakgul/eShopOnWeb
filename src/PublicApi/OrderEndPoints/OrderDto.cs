using BlazorShared.Models.Orders;
using System.Collections.Generic;
using System;

namespace Microsoft.eShopWeb.PublicApi.OrderEndPoints;

public class OrderDto
{
    public int Id { get; set; }
    public string BuyerId { get; set; }
    public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.Now;
    public int OrderStatusId { get; set; }
    public string OrderStatus { get; set; }
    public Address ShipToAddress { get; set; }
    public decimal TotalPrice { get; set; }

    public List<OrderItemDto> OrderItemDto { get; set; }
}
