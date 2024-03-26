using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL;
using Model;
using BLL.ServiceInterfaces;

namespace Zad2PB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderInterface _orderInterface;

        public OrdersController(IOrderInterface orderInterface)
        {
            _orderInterface = orderInterface;
        }

        [HttpPost("GenerateOrder")]
        public void GenerateOrder(int userId)
        {
            _orderInterface.CreateOrder(userId);
        }

        [HttpPost("PayForOrder")]
        public void PayForOrder(int orderId, double price)
        {
            _orderInterface.PayForOrder(orderId, price);
        }
    }
}
