using Microsoft.EntityFrameworkCore;
using MiniProgram.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniProgram.Data.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DbEntity _dbEntity;

        public OrderRepository(DbEntity dbEntity)
        {
            _dbEntity = dbEntity;
        }

        public async Task<IEnumerable<Order>> GetOrders()
        {
            return await _dbEntity.Orders.ToListAsync();
        }

        public async Task<Order> AddOrder(Order data)
        {
            _dbEntity.Orders.Add(data);
            var rows = await _dbEntity.SaveChangesAsync();
            if (rows == 0)
            {
                throw new Exception("Add cost data failed.");
            }
            return data;
        }

        public async Task<Order> UpdateOrder(Order data)
        {
            var matchData = await _dbEntity.Orders.SingleOrDefaultAsync(x => x.Id == data.Id);
            if (matchData == null)
            {
                throw new Exception("Order is not exist.");
            }
            matchData.OrderDate = data.OrderDate;
            matchData.Amount = data.Amount;
            matchData.PrepayerId = data.PrepayerId;
            var rows = await _dbEntity.SaveChangesAsync();
            if (rows >= 0)
            {
                return data;
            }
            throw new ApplicationException();
        }

        public async Task<bool> DeleteOrder(int id)
        {
            try
            {
                var matchData = await _dbEntity.Orders.SingleOrDefaultAsync(x => x.Id == id);
                if (matchData == null)
                {
                    return false;
                }

                _dbEntity.Orders.Remove(matchData);
                var rows = await _dbEntity.SaveChangesAsync();
                return rows != 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }

        public async Task<OrderItem> AddOrderItem(OrderItem data)
        {
            _dbEntity.OrderItems.Add(data);
            var rows = await _dbEntity.SaveChangesAsync();
            if (rows == 0)
            {
                throw new Exception("Add cost data failed.");
            }
            return data;
        }

        public async Task<OrderItem> UpdateOrderItem(OrderItem data)
        {
            var matchData = await _dbEntity.OrderItems.SingleOrDefaultAsync(x => x.Id == data.Id);
            if (matchData == null)
            {
                throw new Exception("Order is not exist.");
            }

            matchData.CategoryId = data.CategoryId;
            matchData.ConsumerId = data.ConsumerId;
            matchData.IsPay = data.IsPay;
            matchData.OrderItemName = data.OrderItemName;
            matchData.OrderId = data.OrderId;
            matchData.Price = data.Price;

            var rows = await _dbEntity.SaveChangesAsync();
            if (rows >= 0)
            {
                return data;
            }
            throw new ApplicationException();
        }

        public async Task<bool> DeleteOrderItem(int id)
        {
            var matchData = await _dbEntity.OrderItems.SingleOrDefaultAsync(x => x.Id == id);
            if (matchData == null)
            {
                return false;
            }

            _dbEntity.OrderItems.Remove(matchData);
            var rows = await _dbEntity.SaveChangesAsync();
            return rows != 0;
        }

        public async Task<IEnumerable<OrderItemCategory>> GetOrderItemCategories()
        {
            return await _dbEntity.OrderItemCategories.ToListAsync();
        }
    }
}
