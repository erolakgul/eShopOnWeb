using System;

namespace BlazorShared.Models.Orders;
public class Order
{
    public int Id { get; set; }
    public string BuyerId { get;  set; }
    public DateTimeOffset OrderDate { get;  set; } = DateTimeOffset.Now;
    public int OrderStatusId { get; set; }
    public OrderStatus? OrderStatus { get; set; }
    public Address ShipToAddress { get;  set; }
}
