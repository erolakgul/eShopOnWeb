namespace Microsoft.eShopWeb.PublicApi.OrderEndPoints;

public class OrderItemDto
{
    public int Id { get; set; }
    public decimal UnitPrice { get; set; }
    public int Units { get; set; }
    public CatalogItemOrderedDto ItemOrdered { get; set; }
}
