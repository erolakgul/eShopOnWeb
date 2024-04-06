using System;
using System.Collections.Generic;

namespace Microsoft.eShopWeb.PublicApi.OrderEndPoints;

public class ListPagedOrderResponse : BaseResponse
{
    public ListPagedOrderResponse(Guid correlationId) : base(correlationId){}

    public ListPagedOrderResponse(){}

    public List<OrderDto> Orders { get; set; } = [];
    public int PageCount { get; set; }
}
