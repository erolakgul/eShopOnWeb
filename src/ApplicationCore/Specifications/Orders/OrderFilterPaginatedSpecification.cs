using Ardalis.Specification;
using Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate;

namespace Microsoft.eShopWeb.ApplicationCore.Specifications.Orders;
public class OrderFilterPaginatedSpecification : Specification<Order>
{
    public OrderFilterPaginatedSpecification(int skip, int take, int? orderStatusId)
      : base()
    {
        if (take == 0)
        {
            take = int.MaxValue;
        }
        Query.Include(o => o.OrderItems) // Include extention ı lazy loading için ardalis te bu şekilde yönetiliri
            .Where(i => (!orderStatusId.HasValue || i.OrderStatusId == orderStatusId) )
            .Skip(skip).Take(take);
    }
}
