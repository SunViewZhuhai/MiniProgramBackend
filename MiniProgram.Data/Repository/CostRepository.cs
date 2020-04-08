using Microsoft.EntityFrameworkCore;
using MiniProgram.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniProgram.Data.Repository
{
    public class CostRepository
    {
        private readonly DbEntity _dbEntity;

        public CostRepository(DbEntity dbEntity)
        {
            _dbEntity = dbEntity;
        }

        public async Task<Cost> Add(Cost data)
        {
            _dbEntity.Costs.Add(data);
            var rows = await _dbEntity.SaveChangesAsync();
            if (rows == 0)
            {
                throw new Exception("Add cost data failed");
            }
            return data;
        }

        public async Task<bool> Update(Cost data)
        {
            var matchData = await _dbEntity.Costs.SingleOrDefaultAsync(x => x.Id == data.Id);
            if (matchData == null)
            {
                return false;
            }
            matchData.StatementDate = data.StatementDate;
            matchData.Amount = data.Amount;
            matchData.CategoryId = data.CategoryId;
            var rows = await _dbEntity.SaveChangesAsync();
            return rows != 0;
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var matchData = await _dbEntity.Costs.SingleOrDefaultAsync(x => x.Id == id);
                if (matchData == null)
                {
                    return false;
                }

                _dbEntity.Costs.Remove(matchData);
                var rows = await _dbEntity.SaveChangesAsync();
                return rows != 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }

        public async Task<IEnumerable<Cost>> Query(IEnumerable<int> userIds, IEnumerable<int> categoryIds, DateTime startDate, DateTime endDate)
        {
            
            if (!(userIds != null && userIds.Any()))
            {
                userIds = _dbEntity.Users.Select(x => x.Id).ToList();
            }
            if (!(categoryIds != null && categoryIds.Any()))
            {
                categoryIds = _dbEntity.CostCategories.Select(x => x.Id).ToList();
            }

            var result = await _dbEntity.Costs.Where(x =>
                userIds.Contains(x.UserId) && categoryIds.Contains(x.CategoryId) && startDate <= x.StatementDate &&
                endDate >= x.StatementDate).ToListAsync();
            return result;
        }
    }
}
