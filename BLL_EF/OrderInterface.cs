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

namespace BLL_EF
{
    public class OrderInterface : IOrderInterface
    {
        private readonly WebshopContext dbContext;
        public OrderInterface(WebshopContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void CreateOrder(int userId)
        {
            var user = dbContext.Users?.FirstOrDefault(x => x.Id == userId);
            if (user != null)
            {
                var order = new Order();
                var orderPositionIds = dbContext.BasketPositions?.Where(x => x.UserId == userId).Select(x => x.ProductId).ToList();
                if (orderPositionIds != null && orderPositionIds.Count() > 0)
                    order.Positions = dbContext.OrderPositions?.Where(x => orderPositionIds.Contains(x.Id)).ToList();
                order.Date = DateTime.Now;
                order.IsPaid = false;
                dbContext.Add(order);
                dbContext.SaveChanges();
            }
        }

        public OrderResponseDTO GetById(int id)
        {
            var order = dbContext.Orders?.FirstOrDefault(x => x.Id == id);
            if (order != null)
                return new OrderResponseDTO(order);
            return null;
        }

        public IEnumerable<OrderResponseDTO> GetOrders()
        {
            var orders = dbContext.Orders?.Select(x => new OrderResponseDTO(x)).ToList();
            return orders ?? new List<OrderResponseDTO>();
        }

        public IEnumerable<OrderResponseDTO> GetOrdersByDate(DateTime date, bool descending = false)
        {
            var orders = dbContext.Orders?.Where(x => x.Date == date).Select(x => new OrderResponseDTO(x));
            return orders != null ? (descending ? orders.OrderByDescending(x => x.Date).ToList() : orders.OrderBy(x => x.Date).ToList()) : new List<OrderResponseDTO>();
        }

        public IEnumerable<OrderResponseDTO> GetOrdersByPrice(double price, bool descending = false)
        {
            var orders = dbContext.Orders?.Where(x => x.Positions != null && x.Positions.Sum(y => y.Price) >= price).Select(x => new OrderResponseDTO(x));
            return orders != null ? (descending ? orders.OrderByDescending(x => x.Date).ToList() : orders.OrderBy(x => x.Date).ToList()) : new List<OrderResponseDTO>();
        }

        public IEnumerable<OrderResponseDTO> GetOrdersByStatus(bool paid)
        {
            var orders = dbContext.Orders?.Where(x => x.IsPaid == paid).Select(x => new OrderResponseDTO(x));
            return orders != null ? orders.ToList() : new List<OrderResponseDTO>();
        }

        public void PayForOrder(int orderId, double price)
        {
            var order = dbContext.Orders?.FirstOrDefault(x => x.Id == orderId);
            if (order != null && !order.IsPaid)
            {
                var priceToPay = order.Positions?.Select(x => x.Price).Sum();
                if (priceToPay == price)
                    order.IsPaid = true;
                else throw new ArgumentException("Podana cena nie jest równa cenie wszystkich produktów w zamówieniu");
            }
        }
    }
}
