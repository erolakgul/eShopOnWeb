using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorShared.Models.Orders;

namespace BlazorShared.Interfaces.Orders;
public interface IOrderService
{
    Task<List<Order>> List();
}
