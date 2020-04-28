using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniProgram.Data;
using MiniProgram.Data.Repository;
using MniProgram.Web.ViewModel;

namespace MniProgram.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderRepository _orderRepository;

        public OrderController(OrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<ActionResult> GetOrderList()
        {
            var data = await _orderRepository.GetOrders();
            var result = data.Select(x => new OrderListViewModel
            {

            });
            return Ok();
        }
    }
}