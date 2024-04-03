using System;
using BlazorShared.Attributes;

namespace BlazorShared.Models.Orders;

[Endpoint(Name = "order-status")]
public class OrderStatus : LookupData
{
    public Int16 Status { get; set; }
}
