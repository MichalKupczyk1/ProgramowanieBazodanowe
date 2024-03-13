using BLL.DTOModels;
using BLL.ServiceInterfaces;
using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_EF
{
    public class ProductGroupInterface : IProductGroupInterface
    {
        private readonly WebshopContext dbContext;
        public ProductGroupInterface(WebshopContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public bool AddNewProductGroup(ProductGroupRequestDTO productGroup)
        {
            if (productGroup != null)
            {
                var parent = productGroup.ParentId.HasValue ? dbContext?.ProductGroups?.Where(x => x.Id == productGroup.ParentId.Value).FirstOrDefault() : null;
                var dbEntity = new ProductGroup() { Name = productGroup.Name, Parent = parent, ParentId = parent?.Id };
                dbContext?.Add(dbEntity);
                dbContext?.SaveChanges();
                return true;
            }
            return false;
        }

        public ProductGroupParentChildrenDTO GetChildrenByGroupId(int groupId)
        {
            var group = dbContext.ChildrenParentProductGroups?.FirstOrDefault(x => x.ParentId == groupId);

            if (group != null && group.Children?.Count() > 0)
            {
                var list = new List<ProductGroupResponseDTO>();
                foreach (var g in group.Children)
                {
                    list.Add(new ProductGroupResponseDTO(g.Id, group.ParentId, g.Name));
                }
                return new ProductGroupParentChildrenDTO(group.ParentId.Value, children: list);
            }
            return null;
        }

        public IEnumerable<ProductGroupResponseDTO> GetChildrenByGroupIdSortByName(int groupId, bool descending = false)
        {
            var list = GetChildrenByGroupId(groupId);
            if (list != null && list.Children?.Count() > 0)
                return descending ? list.Children.OrderByDescending(x => x.Name).ToList()
                    : list.Children.OrderBy(x => x.Name).ToList();
            return new List<ProductGroupResponseDTO>();
        }

        public IEnumerable<ProductGroupResponseDTO> GetParentsOnly()
        {
            var parents = dbContext.ProductGroups.Where(x => x.Parent == null).ToList();
            if (parents != null && parents?.Count() > 0)
            {
                var res = new List<ProductGroupResponseDTO>();
                foreach (var parent in parents)
                {
                    res.Add(new ProductGroupResponseDTO(parent.Id, null, parent.Name));
                }
                return res;
            }
            return new List<ProductGroupResponseDTO>();
        }

        public IEnumerable<ProductGroupResponseDTO> GetParentsOnlySortByName(bool descending = false)
        {
            var parents = GetParentsOnly();
            if (parents != null && parents?.Count() > 0)
                return descending ? parents.OrderByDescending(x => x.Name).ToList() : parents.OrderBy(x => x.Name).ToList();
            return new List<ProductGroupResponseDTO>();
        }
    }
}
