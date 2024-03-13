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
        public UserGroupRequestDTO(int id, string name, IEnumerable<int>? userIds)
        {
            Id = id;
            Name = name;
            UserIds = userIds;
        }
    }

    public class UserGroupResponseDTO
    {
        public string Name { get; }
        public IEnumerable<int>? UserIds { get; }
        public UserGroupResponseDTO(string name, IEnumerable<int>? userIds)
        {
            Name = name;
            UserIds = userIds;
        }
    }

    public class ProductGroupRequestDTO
    {
        public int Id { get; }
        public int? ParentId { get; }
        public string Name { get; }
        public IEnumerable<int>? ChildrenIds { get; }
        public ProductGroupRequestDTO(int id, int? parentId, string name, IEnumerable<int>? childrenIds)
        {
            Id = id;
            ParentId = parentId;
            Name = name;
            ChildrenIds = childrenIds;
        }
    }

    public class ProductGroupResponseDTO
    {
        public int GroupId { get; }
        public int? ParentId { get; }
        public string Name { get; }
        public ProductGroupResponseDTO(int groupId, int? parentId, string name)
        {
            GroupId = groupId;
            ParentId = parentId;
            Name = name;
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
