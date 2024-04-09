using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorShared.Models.Orders;

namespace BlazorShared.Interfaces.Orders;
public interface IOrderService
{
    Task<Order> Edit(Order order);
    Task<Order> GetById(int id);
    Task<List<Order>> List();
}
