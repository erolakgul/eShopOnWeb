using System;

namespace Microsoft.eShopWeb.PublicApi.OrderEndPoints;

public class GetByIdOrderResponse : BaseResponse
{
    public GetByIdOrderResponse(Guid correlationId) : base(correlationId){}

    public GetByIdOrderResponse(){ }

    public OrderDto Order { get; set; }
}
