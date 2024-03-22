using Model;
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
        public OrderPositionRequestDTO(OrderPosition orderPosition)
        {
            Id = orderPosition.Id;
            UserId = orderPosition.UserId;
            OrderId = orderPosition.OrderId;
            Price = orderPosition.Price;
            Amount = orderPosition.Amount;
        }
    }

    public class OrderPositionResponseDTO
    {
        public int? UserId { get; }
        public int? OrderId { get; }
        public int Amount { get; }
        public double Price { get; }
        public OrderPositionResponseDTO(OrderPosition orderPosition)
        {
            UserId = orderPosition.UserId;
            OrderId = orderPosition.OrderId;
            Amount = orderPosition.Amount;
            Price = orderPosition.Price;
        }
    }
}
