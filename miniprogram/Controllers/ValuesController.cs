using System;
using Microsoft.AspNetCore.Mvc;
using MiniProgram.Data;
using MiniProgram.Data.Model;
using MiniProgram.Data.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MiniProgram.ViewModel;

namespace MiniProgram.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        private readonly DbEntity _dbEntity;
        private readonly CostRepository _costRepository;

        public ValuesController(DbEntity dbEntity, CostRepository costRepository)
        {
            _dbEntity = dbEntity;
            _costRepository = costRepository;
        }

        [HttpPost("query")]
        public async Task<IEnumerable<CostViewModel>> Get(CostQueryViewModel viewModel)
        {
            var result = await _costRepository.Query(viewModel.UserIds, viewModel.CategoryIds, viewModel.StartDate, viewModel.EndDate);
            return result.Select(Transform);
        }


        [HttpPost]
        public async Task<CostViewModel> Post(CostViewModel viewModel)
        {
            var data = new Cost
            {
                StatementDate = viewModel.StatementDate,
                Amount = viewModel.Amount,
                CategoryId = viewModel.CategoryId,
                UserId = viewModel.UserId
            };
            var result = await _costRepository.Add(data);
            return Transform(result);
        }

        [HttpPut]
        public async Task Put(CostViewModel viewModel)
        {
            var data = new Cost
            {
                Id = viewModel.Id,
                StatementDate = viewModel.StatementDate,
                Amount = viewModel.Amount,
                CategoryId = viewModel.CategoryId,
                UserId = viewModel.UserId
            };
            var result = await _costRepository.Update(data);
            Response.StatusCode = result ? 200 : 400;
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            var result = await _costRepository.Delete(id);
            Response.StatusCode = result ? 200 : 400;
        }

        private CostViewModel Transform(Cost data)
        {
            var viewModel = new CostViewModel
            {
                Id = data.Id,
                Amount = data.Amount,
                StatementDate = data.StatementDate,
                UserId = data.UserId,
                CategoryId = data.CategoryId
            };
            return viewModel;
        }
    }
}
