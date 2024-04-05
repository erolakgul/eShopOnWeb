using System.Collections.Generic;
using System.Text.Json.Serialization;
using BlazorShared.Interfaces;

namespace BlazorShared.Models.Orders;
public class OrderStatusResponse : ILookupDataResponse<OrderStatus>
{
    [JsonPropertyName("OrderStatus")]
    public List<OrderStatus> List { get; set; } =[];
}
