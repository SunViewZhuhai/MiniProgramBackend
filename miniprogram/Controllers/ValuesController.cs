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
        private readonly OrderRepository _orderRepository;

        public ValuesController(DbEntity dbEntity, OrderRepository orderRepository)
        {
            _dbEntity = dbEntity;
            _orderRepository = orderRepository;
        }

        
    }
}
