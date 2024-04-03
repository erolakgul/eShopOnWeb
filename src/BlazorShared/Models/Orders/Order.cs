using System;
using System.Collections.Generic;

namespace BlazorShared.Models.Orders;
public class Order
{
    public int Id { get; set; }
    public string BuyerId { get;  set; }
    public DateTimeOffset OrderDate { get;  set; } = DateTimeOffset.Now;
    public int OrderStatusId { get; set; }
    public string OrderStatus { get; set; }
    public Address ShipToAddress { get;  set; }
    public decimal TotalPrice { get; set; }
     
    public List<OrderItems> OrderItems { get; set; }

    public decimal Total()
    {
        var total = 0m;
        foreach (var item in OrderItems)
        {
            total += item.UnitPrice * item.Units;
        }
        return total;
    }
}
