using BLL.DTOModels;
using BLL.ServiceInterfaces;
using DAL;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DB
{
    public class OrderInterface : IOrderInterface
    {
        private readonly WebshopContext _context;

        public OrderInterface(WebshopContext context)
        {
            this._context = context;
        }

        public void CreateOrder(int userId)
        {
            var userIdParam = new SqlParameter("@UserId", userId);
            _context.Database.ExecuteSqlRaw("EXEC CreateOrderForUser @UserId", userIdParam);
        }

        public OrderResponseDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderResponseDTO> GetOrders()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderResponseDTO> GetOrdersByDate(DateTime date, bool descending = false)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderResponseDTO> GetOrdersByPrice(double price, bool descending = false)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderResponseDTO> GetOrdersByStatus(bool paid)
        {
            throw new NotImplementedException();
        }

        public void PayForOrder(int orderId, double amountPaid)
        {
            var orderIdParam = new SqlParameter("@OrderId", orderId);
            var amountPaidParam = new SqlParameter("@AmountPaid", (decimal)amountPaid);
            _context.Database.ExecuteSqlRaw("EXEC PayForOrder @OrderId, @AmountPaid", orderIdParam, amountPaidParam);
        }
    }
}
