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
        public IEnumerable<ProductResponseDTO> GetProductsByName(string productName, bool descending = false);
        public IEnumerable<ProductResponseDTO> GetProductsByGroupName(string groupName, bool descending = false);
        public IEnumerable<ProductResponseDTO> GetProductsByGroupId(int groupId, bool descending = false);
        public IEnumerable<ProductResponseDTO> GetProductsByTheirStatus(bool isActive, bool descending = false);
        public void AddNewProduct(string name, double price, int? groupId);
        public bool RemoveProduct(int productId);
        public bool DeactivateProduct(int productId);
    }
}
