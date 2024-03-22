using BLL.DTOModels;
using BLL.ServiceInterfaces;
using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DB
{
    public class ProductGroupInterface : IProductGroupInterface
    {
        public bool AddNewProductGroup(ProductGroupRequestDTO productGroup)
        {
            throw new NotImplementedException();
        }

        public ProductGroupParentChildrenDTO GetChildrenByGroupId(int groupId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductGroupResponseDTO> GetChildrenByGroupIdSortByName(int groupId, bool descending = false)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductGroupResponseDTO> GetParentsOnly()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductGroupResponseDTO> GetParentsOnlySortByName(bool descending = false)
        {
            throw new NotImplementedException();
        }

        public ProductGroupResponseDTO GetProductGroupById(int id)
        {
            throw new NotImplementedException();
        }

        public List<ProductGroupResponseDTO> GetProductGroups()
        {
            throw new NotImplementedException();
        }
    }
}
