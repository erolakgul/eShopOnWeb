using System.ComponentModel.DataAnnotations;

namespace Microsoft.eShopWeb.PublicApi.OrderEndPoints;

public class UpdateOrderStatuRequest :BaseRequest
{
    [Range(1, 10000)]
    public int Id { get; set; }
    [Range(1, 10000)]
    public int OrderStatusId { get; set; }
}
