using Model;
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

        public BasketPositionRequestDTO(BasketPosition basketPosition)
        {
            Id = basketPosition.Id;
            ProductId = basketPosition.ProductId;
            UserId = basketPosition.UserId;
            Amount = basketPosition.Amount;
        }
    }

    public class BasketPositionResponseDTO
    {
        public int? ProductId { get; }
        public int? UserId { get; }
        public int Amount { get; }

        public BasketPositionResponseDTO(BasketPosition basketPosition)
        {
            ProductId = basketPosition.ProductId;
            UserId = basketPosition.UserId;
            Amount = basketPosition.Amount;
        }
    }
}
