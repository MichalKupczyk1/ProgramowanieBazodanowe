using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOModels
{
    public class OrderPositionRequestDTO
    {
        public int Id { get; }
        public int? UserId { get; }
        public int? OrderId { get; }
        public double Price { get; }
        public int Amount { get; }
        public OrderPositionRequestDTO(int id, int? userId, int? orderId, double price, int amount)
        {
            Id = id;
            UserId = userId;
            OrderId = orderId;
            Price = price;
            Amount = amount;
        }
    }

    public class OrderPositionResponseDTO
    {
        public int? UserId { get; }
        public int? OrderId { get; }
        public int Amount { get; }
        public double Price { get; }
        public OrderPositionResponseDTO(int? userId, int? orderId, int amount, double price)
        {
            UserId = userId;
            OrderId = orderId;
            Amount = amount;
            Price = price;
        }
    }
}
