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
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderRepository _orderRepository;

        public OrderController(OrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpGet("GetOrderList")]
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

        [HttpGet("AddOrder")]
        public async Task<ActionResult> AddOrder(OrderListViewModel data)
        {
            var order = new Order
            {
                Amount = data.Amount,
                OrderDate = data.OrderDate,
                PrepayerId = data.PrepayerId
            };
            var result = await _orderRepository.Add(order);
            data.Id = result.Id;
            return Ok(data);
        }

        [HttpGet("UpdateOrder")]
        public async Task<ActionResult> UpdateOrder(OrderListViewModel data)
        {
            var order = new Order
            {
                Id = data.Id,
                Amount = data.Amount,
                OrderDate = data.OrderDate,
                PrepayerId = data.PrepayerId
            };
            var result = await _orderRepository.Update(order);
            return Ok(data);
        }

        [HttpGet("DeleteOrder")]
        public async Task<ActionResult> DeleteOrder(int orderId)
        {
            var result = await _orderRepository.Delete(orderId);
            return Ok(result);
        }



        [HttpGet("AddOrderDetail")]
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

        [HttpGet("UpdateOrderDetail")]
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

        [HttpGet("DeleteOrder")]
        public async Task<ActionResult> DeleteOrderDetail(int orderId)
        {
            var result = await _orderRepository.DeleteOrderItem(orderId);
            return Ok(result);
        }
    }
}