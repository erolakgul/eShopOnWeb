using Ardalis.Specification;
using Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate;

namespace Microsoft.eShopWeb.ApplicationCore.Specifications.Orders;
public class OrderFilterSpecification : Specification<Order>
{
    public OrderFilterSpecification(int? orderStatusId)
    {
        Query.Where(i => (!orderStatusId.HasValue || i.OrderStatusId == orderStatusId));
    }
}
