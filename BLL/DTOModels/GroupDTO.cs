using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOModels
{
    public class UserGroupRequestDTO
    {
        public int Id { get; }
        public string Name { get; }
        public IEnumerable<int>? UserIds { get; }
        public UserGroupRequestDTO(UserGroup userGroup)
        {
            Id = userGroup.Id;
            Name = userGroup.Name;
            UserIds = userGroup.Users?.Select(user => user.Id);
        }
    }

    public class UserGroupResponseDTO
    {
        public string Name { get; }
        public IEnumerable<int>? UserIds { get; }
        public UserGroupResponseDTO(UserGroup userGroup)
        {
            Name = userGroup.Name;
            UserIds = userGroup.Users?.Select(user => user.Id);
        }
    }

    public class ProductGroupRequestDTO
    {
        public int Id { get; }
        public int? ParentId { get; }
        public string Name { get; }
        public IEnumerable<int>? ChildrenIds { get; }
        public ProductGroupRequestDTO(ProductGroup productGroup)
        {
            Id = productGroup.Id;
            ParentId = productGroup.ParentId;
            Name = productGroup.Name;
        }
    }

    public class ProductGroupResponseDTO
    {
        public int GroupId { get; }
        public int? ParentId { get; }
        public string Name { get; }
        public ProductGroupResponseDTO(ProductGroup productGroup)
        {
            GroupId = productGroup.Id;
            ParentId = productGroup.ParentId;
            Name = productGroup.Name;
        }
    }

    public class ProductGroupParentChildrenDTO
    {
        public int ParentId { get; }
        public IEnumerable<ProductGroupResponseDTO>? Children { get; set; }
        public ProductGroupParentChildrenDTO(int parentId, IEnumerable<ProductGroupResponseDTO>? children)
        {
            ParentId = parentId;
            Children = children;
        }
    }
}
