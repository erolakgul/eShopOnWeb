using System;

namespace Microsoft.eShopWeb.PublicApi.OrderStatusEndPoints;

public class OrderStatusDto
{
    public int Id { get; set; }
    public Int16 Status { get; set; }
    public string Name { get; set; }
}
