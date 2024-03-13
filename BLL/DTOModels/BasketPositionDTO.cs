using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOModels
{
    public class BasketPositionRequestDTO
    {
        public int Id { get; }
        public int? ProductId { get; }
        public int? UserId { get; }
        public int Amount { get; }

        public BasketPositionRequestDTO(int id, int? productId, int? userId, int amount)
        {
            Id = id;
            ProductId = productId;
            UserId = userId;
            Amount = amount;
        }
    }

    public class BasketPositionResponseDTO
    {
        public int ProductId { get; }
        public int UserId { get; }
        public int Amount { get; }

        public BasketPositionResponseDTO(int productId, int userId, int amount)
        {
            ProductId = productId;
            UserId = userId;
            Amount = amount;
        }
    }
}
