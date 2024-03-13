using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOModels
{
    public class ProductResponseDTO
    {
        public string Name { get; }
        public double Price { get; }
        public string Image { get; }
        public bool IsActive { get; }
        public int? GroupId { get; }
        public IEnumerable<BasketPositionResponseDTO>? BasketPositions { get; }
        public ProductResponseDTO(string name, double price, string image, bool isActive, int? groupId, IEnumerable<BasketPositionResponseDTO>? basketPositions)
        {
            Name = name;
            Price = price;
            Image = image;
            IsActive = isActive;
            GroupId = groupId;
            BasketPositions = basketPositions;
        }
    }

    public class ProductRequestDTO
    {
        public int Id { get; }
        public string Name { get; }
        public double Price { get; }
        public string Image { get; }
        public bool IsActive { get; }
        public int? GroupId { get; }
        public IEnumerable<BasketPositionResponseDTO>? BasketPositions { get; }
        public ProductRequestDTO(int id, string name, double price, string image, bool isActive, int? groupId, IEnumerable<BasketPositionResponseDTO>? basketPositions)
        {
            Id = id;
            Name = name;
            Price = price;
            Image = image;
            IsActive = isActive;
            GroupId = groupId;
            BasketPositions = basketPositions;
        }
    }
}
