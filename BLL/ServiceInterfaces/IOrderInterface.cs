using BLL.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ServiceInterfaces
{
    public interface IOrderInterface
    {
        public void CreateOrder(int userId, IEnumerable<int>? basketPositionIds);
        public void PayForOrder(int orderId, double price);
        public OrderResponseDTO GetById(int id);
        public IEnumerable<OrderResponseDTO> GetOrders();
        public IEnumerable<OrderResponseDTO> GetOrdersByDate(DateTime date, bool descending = false);
        public IEnumerable<OrderResponseDTO> GetOrdersById(int orderId, bool descending = false);
        public IEnumerable<OrderResponseDTO> GetOrdersByPrice(double price, bool descending = false);
        public IEnumerable<OrderResponseDTO> GetOrdersByStatus(bool paid, bool descending = false);
    }
}
