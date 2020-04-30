using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MiniProgram.Data.Model;

namespace MiniProgram.Data.Repository
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetOrders();
        Task<Order> AddOrder(Order data);
        Task<Order> UpdateOrder(Order data);
        Task<bool> DeleteOrder(int id);

        Task<OrderItem> AddOrderItem(OrderItem data);
        Task<OrderItem> UpdateOrderItem(OrderItem data);
        Task<bool> DeleteOrderItem(int id);

    }
}
