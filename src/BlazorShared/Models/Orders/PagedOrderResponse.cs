using System.Collections.Generic;

namespace BlazorShared.Models.Orders;
public class PagedOrderResponse
{
    public List<Order> Orders { get; set; } = [];
    public int PageCount { get; set; } = 0;
}
