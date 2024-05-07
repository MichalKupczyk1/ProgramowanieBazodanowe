﻿using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOModels
{
    public class ProductResponseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; init; }
        public string Image { get; init; }
        public bool IsActive { get; init; }
        public int? GroupId { get; init; }
        public IEnumerable<BasketPositionResponseDTO>? BasketPositions { get; }
        public ProductResponseDTO(int id, string name, double price, string image, bool isActive, int? groupId)
        {
            this.Id = id;
            this.Name = name;
            this.Price = price;
            this.Image = image;
            this.IsActive = isActive;
            this.GroupId = groupId;
        }
        public ProductResponseDTO(Product product, string name = "")
        {
            Id = product.Id;
            Name = name != "" ? name : product.Name;
            Price = product.Price;
            Image = product.Image;
            IsActive = product.IsActive;
            GroupId = product.GroupId;
            BasketPositions = product.BasketPositions != null ? ConvertBasketPositions(product.BasketPositions) : null;
        }

        public ProductResponseDTO(Product product)
        {
            Name = product.Name;
            Price = product.Price;
            Image = product.Image;
            IsActive = product.IsActive;
            GroupId = product.GroupId;
            BasketPositions = product.BasketPositions != null ? ConvertBasketPositions(product.BasketPositions) : null;
        }

        private IEnumerable<BasketPositionResponseDTO> ConvertBasketPositions(IEnumerable<BasketPosition> basketPositions)
        {
            List<BasketPositionResponseDTO> result = new List<BasketPositionResponseDTO>();
            foreach (var position in basketPositions)
            {
                result.Add(new BasketPositionResponseDTO(position));
            }
            return result;
        }
    }

    public class ProductRequestDTO
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public double Price { get; init; }
        public string Image { get; init; }
        public bool IsActive { get; init; }
        public int? GroupId { get; init; }
        public IEnumerable<BasketPositionResponseDTO>? BasketPositions { get; init; }
        public ProductRequestDTO() { }
        public ProductRequestDTO(Product product)
        {
            Id = product.Id;
            Name = product.Name;
            Price = product.Price;
            Image = product.Image;
            IsActive = product.IsActive;
            GroupId = product.GroupId;
        }
    }
}
