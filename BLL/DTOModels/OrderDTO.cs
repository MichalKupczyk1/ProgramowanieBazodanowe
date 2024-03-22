using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOModels
{
    public class OrderRequestDTO
    {
        public int Id { get; }
        public int? UserId { get; }
        public bool IsPaid { get; }
        public DateTime Date { get; }

        public OrderRequestDTO(Order order)
        {
            Id = order.Id;
            UserId = order.UserId;
            IsPaid = order.IsPaid;
            Date = order.Date;
        }
    }

    public class OrderResponseDTO
    {
        public int? UserId { get; }
        public DateTime Date { get; }
        public bool IsPaid { get; }
        public OrderResponseDTO(Order order)
        {
            UserId = order.UserId;
            IsPaid = order.IsPaid;
            Date = order.Date;
        }
    }
}
