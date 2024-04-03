using System.Collections.Generic;

namespace BlazorShared.Models.Orders;
public class OrderHeadResponse
{
    public List<Order> Orders { get; set; } = new();
}
