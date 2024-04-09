namespace Microsoft.eShopWeb.PublicApi.OrderEndPoints;

public class CatalogItemOrderedDto
{
    public int CatalogItemId { get; private set; }
    public string ProductName { get; private set; }
    public string PictureUri { get; private set; }
}
