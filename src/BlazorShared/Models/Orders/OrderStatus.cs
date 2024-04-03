using System;

namespace BlazorShared.Models.Orders;
public class OrderStatus
{
    public int Id { get; set; }
    public Int16 Status { get; set; }
    public string Description { get; set; }
}
