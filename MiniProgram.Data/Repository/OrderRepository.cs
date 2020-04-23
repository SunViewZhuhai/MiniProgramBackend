using Microsoft.EntityFrameworkCore;
using MiniProgram.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniProgram.Data.Repository
{
    public class OrderRepository
    {
        private readonly DbEntity _dbEntity;

        public OrderRepository(DbEntity dbEntity)
        {
            _dbEntity = dbEntity;
        }

        public async Task<Order> Add(Order data)
        {
            _dbEntity.Orders.Add(data);
            var rows = await _dbEntity.SaveChangesAsync();
            if (rows == 0)
            {
                throw new Exception("Add cost data failed");
            }
            return data;
        }

        public async Task<bool> Update(Order data)
        {
            var matchData = await _dbEntity.Orders.SingleOrDefaultAsync(x => x.Id == data.Id);
            if (matchData == null)
            {
                return false;
            }
            matchData.OrderDate = data.OrderDate;
            matchData.Amount = data.Amount;
            matchData.PrepayerId = data.PrepayerId;
            var rows = await _dbEntity.SaveChangesAsync();
            return rows != 0;
        }

        public async Task<bool> Delete(int id)
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

    }
}
