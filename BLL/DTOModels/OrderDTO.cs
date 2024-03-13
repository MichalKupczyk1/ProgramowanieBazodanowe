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
        public DateTime Date { get; }

        public OrderRequestDTO(int id, int? userId, DateTime date)
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
        public OrderResponseDTO(int? userId, DateTime date)
        {
            UserId = userId;
            Date = date;
        }
    }
}
