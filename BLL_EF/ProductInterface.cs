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

        public IEnumerable<ProductResponseDTO> GetProductsByFilters(string? name, int? groupId, bool? isActive, bool descending = false)
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
                            basketPositions.Add(new BasketPositionResponseDTO(position));
                    }
                    res.Add(new ProductResponseDTO(product, GetProductNameWithParents(product.Name, product.GroupId)));
                }
            }
            return res;
        }

        private IQueryable<Product>? ReturnQueryAfterFiltering(string? name, int? groupId, bool? isActive)
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

        public List<ProductResponseDTO> GetProducts()
        {
            throw new NotImplementedException();
        }

        int IProductInterface.AddNewProduct(string name, string image, double price, int? groupId)
        {
            if (price <= 0.0)
                throw new ArgumentException("Cena musi być większa od 0");
            var product = new Product() { Name = name, Price = price, GroupId = groupId, IsActive = true, Image = image };
            dbContext?.Add(product);
            dbContext?.SaveChanges();
            return product.Id;
        }
        public ProductResponseDTO GetProductById(int productId)
        {
            throw new NotImplementedException();
        }

        public bool ActivateProduct(int productId)
        {
            var product = dbContext.Products?.FirstOrDefault(x => x.Id == productId);
            if (product != null)
            {
                if (!product.IsActive)
                {
                    product.IsActive = true;
                    dbContext.Update(product);
                    dbContext.SaveChanges();
                }
                return true;
            }
            return false;
        }

        public bool AddProductToBasket(int productId, int basketId)
        {
            var product = dbContext.Products?.FirstOrDefault(x => x.Id == productId);
            var basket = dbContext.BasketPositions?.FirstOrDefault(x => x.Id == basketId);
            if (product != null && basket != null)
            {
                if (product.BasketPositions != null)
                    product.BasketPositions.Append(basket);
                else
                {
                    product.BasketPositions = new List<BasketPosition>();
                    product.BasketPositions.Append(basket);
                }

                basket.Product = product;
                basket.ProductId = productId;

                dbContext.Update(basket);
                dbContext.Update(product);
                dbContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
