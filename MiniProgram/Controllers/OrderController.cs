using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniProgram.Data;
using MiniProgram.Data.Model;
using MiniProgram.Data.Repository;
using MniProgram.Web.ViewModel;

namespace MniProgram.Web.Controllers
{
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpGet]
        [Route("api/Order/GetOrderList")]
        public async Task<ActionResult> GetOrderList()
        {
            var data = await _orderRepository.GetOrders();
            var result = data.Select(x => new OrderListViewModel
            {
                Id = x.Id,
                Amount = x.Amount,
                OrderDate = x.OrderDate,
                PrepayerId = x.PrepayerId,
                orderDetailViewModels = x.OrderItems.Select(y => new OrderDetailViewModel
                {
                    Id = y.Id,
                    CategoryId = y.CategoryId,
                    ConsumerId = y.ConsumerId,
                    OrderId = y.OrderId,
                    OrderItemName = y.OrderItemName,
                    Price = y.Price,
                    IsPay = y.IsPay
                }).ToList()
            });
            return Ok(result);
        }

        [HttpPost]
        [Route("api/Order/AddOrder")]
        public async Task<ActionResult> AddOrder(OrderListViewModel data)
        {
            var order = new Order
            {
                Amount = data.Amount,
                OrderDate = data.OrderDate,
                PrepayerId = data.PrepayerId
            };
            var result = await _orderRepository.AddOrder(order);
            data.Id = result.Id;
            return Ok(data);
        }

        [HttpPost]
        [Route("api/Order/UpdateOrder")]
        public async Task<ActionResult> UpdateOrder(OrderListViewModel data)
        {
            var order = new Order
            {
                Id = data.Id,
                Amount = data.Amount,
                OrderDate = data.OrderDate,
                PrepayerId = data.PrepayerId
            };
            var result = await _orderRepository.UpdateOrder(order);
            return Ok(data);
        }

        [HttpPost]
        [Route("api/Order/DeleteOrder/{orderId}")]
        public async Task<ActionResult> DeleteOrder(int orderId)
        {
            var result = await _orderRepository.DeleteOrder(orderId);
            return Ok(result);
        }



        [HttpPost]
        [Route("api/OrderDetail/AddOrderDetail")]
        public async Task<ActionResult> AddOrderDetail(OrderDetailViewModel data)
        {
            var orderDetail = new OrderItem
            {
                CategoryId = data.CategoryId,
                ConsumerId = data.ConsumerId,
                OrderId = data.OrderId,
                OrderItemName = data.OrderItemName,
                Price = data.Price,
                IsPay = data.IsPay
            };
            var result = await _orderRepository.AddOrderItem(orderDetail);
            data.Id = result.Id;
            return Ok(data);
        }

        [HttpPost]
        [Route("api/OrderDetail/UpdateOrderDetail")]
        public async Task<ActionResult> UpdateOrderDetail(OrderDetailViewModel data)
        {
            var orderDetail = new OrderItem
            {
                Id = data.Id,
                CategoryId = data.CategoryId,
                ConsumerId = data.ConsumerId,
                OrderId = data.OrderId,
                OrderItemName = data.OrderItemName,
                Price = data.Price,
                IsPay = data.IsPay
            };
            var result = await _orderRepository.UpdateOrderItem(orderDetail);
            return Ok(data);
        }

        [HttpPost]
        [Route("api/OrderDetail/DeleteOrderDetail/{orderDetailId}")]
        public async Task<ActionResult> DeleteOrderDetail(int orderDetailId)
        {
            var result = await _orderRepository.DeleteOrderItem(orderDetailId);
            return Ok(result);
        }

        [HttpGet]
        [Route("api/ItemCategory")]
        public async Task<ActionResult> GetItemCategory()
        {
            var result = await _orderRepository.GetOrderItemCategories();
            var viewModel = result.Select(x => new
            {
                x.Id, x.Category
            });
            return Ok(viewModel);
        }
    }
}