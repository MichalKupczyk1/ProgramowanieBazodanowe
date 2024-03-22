using BLL.DTOModels;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ServiceInterfaces
{
    public interface IProductInterface
    {
        public IEnumerable<ProductResponseDTO> GetProductsByFilters(string name, int? groupId, bool? isActive, bool descending = false);
        public int AddNewProduct(string name, string image, double price, int? groupId);
        public bool RemoveProduct(int productId);
        public bool DeactivateProduct(int productId);
        public bool ActivateProduct(int productId);
        public bool AddProductToBasket(int productId, int basketId);
        public List<ProductResponseDTO> GetProducts();
        public ProductResponseDTO GetProductById(int productId);
    }
}
