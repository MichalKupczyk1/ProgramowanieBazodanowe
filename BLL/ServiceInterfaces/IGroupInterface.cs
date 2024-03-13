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
        public IEnumerable<ProductGroupResponseDTO> GetChildrenByGroupId(int groupId);
        public IEnumerable<ProductGroupResponseDTO> GetChildrenByGroupIdSortByName(int groupId, bool descending = false);
        public bool AddNewProductGroup(ProductGroupRequestDTO productGroup);
    }
    public interface IUserGroupInterface
    {
        public bool UserLogIn(string username, string password);
        public bool UserLogOut(int UserId);
    }
}
