using BLL.DTOModels;
using BLL.ServiceInterfaces;
using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace BLL_DB
{
    public class ProductInterface : IProductInterface
    {
        public bool ActivateProduct(int productId)
        {
            throw new NotImplementedException();
        }

        public void AddNewProduct(string name, double price, int? groupId)
        {
            throw new NotImplementedException();
        }

        public int AddNewProduct(string name, string image, double price, int? groupId)
        {
            throw new NotImplementedException();
        }

        public bool AddProductToBasket(int productId, int basketId)
        {
            throw new NotImplementedException();
        }

        public bool DeactivateProduct(int productId)
        {
            throw new NotImplementedException();
        }

        public ProductResponseDTO GetProductById(int productId)
        {
            throw new NotImplementedException();
        }

        public List<ProductResponseDTO> GetProducts()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductResponseDTO> GetProductsByFilters(string name, int? groupId, bool? isActive, bool descending = false)
        {
            throw new NotImplementedException();
        }

        public bool RemoveProduct(int productId)
        {
            throw new NotImplementedException();
        }
    }
}
