using System.Linq;
using Ardalis.Specification;
using Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate;

namespace Microsoft.eShopWeb.ApplicationCore.Specifications.Orders;
public class OrderWithItemsFilterSpecification : Specification<Order>
{
    public OrderWithItemsFilterSpecification(int? orderId)
    {
        Query.Include(x=> x.OrderItems)
             .Where(i => (!orderId.HasValue || i.Id == orderId));
    }
}
