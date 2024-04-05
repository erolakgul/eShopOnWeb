using System;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;

namespace Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate;
public class OrderStatus : BaseEntity, IAggregateRoot
{
    public Int16 Status { get; set; }
    public string? Name { get; set; }

    public OrderStatus(Int16 Stat,string Desc)
    {
        Status = Stat;
        Name = Desc;
    }

    private OrderStatus() { }
}
