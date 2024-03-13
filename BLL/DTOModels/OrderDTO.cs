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

        public OrderRequestDTO(int id, int? userId, bool isPaid, DateTime date)
        {
            Id = id;
            UserId = userId;
            Date = date;
        }
    }

    public class OrderResponseDTO
    {
        public int? UserId { get; }
        public DateTime Date { get; }
        public bool IsPaid { get; }
        public OrderResponseDTO(int? userId, bool isPaid, DateTime date)
        {
            UserId = userId;
            Date = date;
            IsPaid = isPaid;
        }
    }
}
