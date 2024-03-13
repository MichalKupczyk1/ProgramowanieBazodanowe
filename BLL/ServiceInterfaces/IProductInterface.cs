using BLL.DTOModels;
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
        public void AddNewProduct(string name, double price, int? groupId);
        public bool RemoveProduct(int productId);
        public bool DeactivateProduct(int productId);
    }
}
