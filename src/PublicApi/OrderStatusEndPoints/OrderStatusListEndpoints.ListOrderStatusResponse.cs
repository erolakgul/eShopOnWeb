using System;
using System.Collections.Generic;

namespace Microsoft.eShopWeb.PublicApi.OrderStatusEndPoints;

public class ListOrderStatusResponse : BaseResponse
{
    public ListOrderStatusResponse(Guid correlationId) : base(correlationId) { }

    public ListOrderStatusResponse() { }

    public List<OrderStatusDto> OrderStatus { get; set; } = [];
}
