using BLL.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ServiceInterfaces
{
    public interface IProductGroupInterface
    {
        public IEnumerable<ProductGroupResponseDTO> GetParentsOnly();
        public IEnumerable<ProductGroupResponseDTO> GetParentsOnlySortByName(bool descending = false);

        public ProductGroupParentChildrenDTO GetChildrenByGroupId(int groupId);
        public IEnumerable<ProductGroupResponseDTO> GetChildrenByGroupIdSortByName(int groupId, bool descending = false);
        public bool AddNewProductGroup(ProductGroupRequestDTO productGroup);
        public List<ProductGroupResponseDTO> GetProductGroups();
        public ProductGroupResponseDTO GetProductGroupById(int id);
    }
    public interface IUserGroupInterface
    {
    }
}
