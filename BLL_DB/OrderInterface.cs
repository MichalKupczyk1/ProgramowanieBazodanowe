using BLL.DTOModels;
using BLL.ServiceInterfaces;
using DAL;
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
        public void CreateOrder(int userId)
        {
            throw new NotImplementedException();
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

        public void PayForOrder(int orderId, double price)
        {
            throw new NotImplementedException();
        }
    }
}
