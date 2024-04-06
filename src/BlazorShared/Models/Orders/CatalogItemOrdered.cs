﻿namespace BlazorShared.Models.Orders;

public class CatalogItemOrdered
{
    public int CatalogItemId { get;  set; }
    public string? ProductName { get;  set; }
    public string? PictureUri { get;  set; }
}
