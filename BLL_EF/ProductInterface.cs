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

namespace BLL_EF
{
    public class ProductInterface : IProductInterface
    {
        private readonly WebshopContext dbContext;
        public ProductInterface(WebshopContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void AddNewProduct(string name, double price, int? groupId)
        {
            if (price <= 0.0)
                throw new ArgumentException("Cena musi być większa od 0");
            var product = new Product() { Name = name, Price = price, GroupId = groupId, IsActive = true };
            dbContext?.Add(product);
            dbContext?.SaveChanges();
        }

        public IEnumerable<ProductResponseDTO> GetProductsByFilters(string name, int? groupId, bool? isActive, bool descending = false)
        {
            var query = ReturnQueryAfterFiltering(name, groupId, isActive);
            if (query != null)
            {
                var resProducts = query.ToList();
                var res = ReturnProductResponseDTOList(resProducts);

                return descending ? res.OrderByDescending(x => x.Name).ToList() : res.OrderBy(x => x.Name).ToList();
            }
            return new List<ProductResponseDTO>();
        }

        private string GetProductNameWithParents(string productName, int? groupId)
        {
            var parentGroups = "";

            while (groupId.HasValue)
            {
                var group = dbContext.ProductGroups?.FirstOrDefault(x => x.Id == groupId.Value);
                if (group != null)
                {
                    parentGroups = parentGroups.Insert(0, group.Name + "/");
                    groupId = group.ParentId;
                }
                else
                    groupId = null;

            };
            return parentGroups + productName;
        }

        private List<ProductResponseDTO> ReturnProductResponseDTOList(List<Product>? resProducts)
        {
            var res = new List<ProductResponseDTO>();
            if (resProducts != null && resProducts?.Count() > 0)
            {
                foreach (var product in resProducts)
                {
                    var basketPositions = new List<BasketPositionResponseDTO>();
                    if (product.BasketPositions != null && product.BasketPositions?.Count() > 0)
                    {
                        foreach (var position in product.BasketPositions)
                            basketPositions.Add(new BasketPositionResponseDTO(position.ProductId, position.UserId, position.Amount));
                    }
                    res.Add(new ProductResponseDTO(GetProductNameWithParents(product.Name, product.GroupId), product.Price, product.Image, product.IsActive, product.GroupId, basketPositions));
                }
            }
            return res;
        }

        private IQueryable<Product>? ReturnQueryAfterFiltering(string name, int? groupId, bool? isActive)
        {
            var query = dbContext.Products?.AsQueryable();
            if (query != null)
            {
                if (name != null && name != "")
                {
                    name = name.ToUpper();
                    query = query.Where(x => x.Name.ToUpper().Contains(name)
                    || (x.Group != null && x.Group.Name.ToUpper().Contains(name)));
                }

                if (groupId.HasValue)
                    query = query.Where(x => x.GroupId.HasValue && x.GroupId == groupId);
                if (isActive.HasValue)
                    query = query.Where(x => x.IsActive == isActive.Value);
            }
            return query;
        }

        public bool RemoveProduct(int productId)
        {
            var product = dbContext.Products?.FirstOrDefault(x => x.Id == productId);
            if (product != null)
            {
                if (CheckIfCanBeDeactivatedOrRemoved(productId))
                {
                    dbContext.Remove(product);
                    dbContext.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public bool DeactivateProduct(int productId)
        {
            var product = dbContext.Products?.FirstOrDefault(x => x.Id == productId);
            if (product != null)
            {
                if (CheckIfCanBeDeactivatedOrRemoved(productId))
                {
                    product.IsActive = false;
                    dbContext.Update(product);
                    dbContext.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        private bool CheckIfCanBeDeactivatedOrRemoved(int productId)
        {
            var isNotInOrder = !dbContext.Orders?.Any(x => x.Positions != null && x.Positions.Any(y => y.Id == productId) && !x.IsPaid) ?? true;
            var isNotInBasket = !dbContext.BasketPositions?.Any(x => x.ProductId == productId) ?? true;
            return isNotInBasket && isNotInOrder;
        }
    }
}
