using System;

namespace Microsoft.eShopWeb.PublicApi.OrderEndPoints;

public class UpdateOrderStatuResponse : BaseResponse
{
    public UpdateOrderStatuResponse(Guid correlationId) : base(correlationId){}

    public UpdateOrderStatuResponse(){}

    public OrderDto Order { get; set; }
}
