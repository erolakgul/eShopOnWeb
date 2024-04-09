namespace Microsoft.eShopWeb.PublicApi.OrderEndPoints;

public class GetByIdOrderRequest : BaseRequest
{
    public int OrderId { get; init; }

    public GetByIdOrderRequest(int orderId)
    {
        OrderId = orderId;
    }
}
