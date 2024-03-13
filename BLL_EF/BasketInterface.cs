using BLL.ServiceInterfaces;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_EF
{
    public class BasketInterface : IBasketInterface
    {
        private readonly WebshopContext dbContext;
        public BasketInterface(WebshopContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void AddProductToBasket(int basketId, int productId, int amount)
        {
            var product = dbContext.Products?.FirstOrDefault(x => x.Id == productId);
            var basket = dbContext.BasketPositions?.FirstOrDefault(x => x.Id == basketId);
            if (product != null && product.IsActive && basket != null && amount > 0)
            {
                basket.Product = product;
                basket.Amount = amount;
                dbContext.Update(basket);
                dbContext.SaveChanges();
            }
        }

        public void ChangeTheAmountOfProductsInBasket(int basketId, int amount)
        {
            var basket = dbContext.BasketPositions?.FirstOrDefault(x => x.Id == basketId);
            if (basket != null && amount > 0)
            {
                basket.Amount = amount;
                dbContext.Update(basket);
                dbContext.SaveChanges();
            }
        }

        public bool RemoveProductFromBasket(int basketId)
        {
            var basket = dbContext.BasketPositions?.FirstOrDefault(x => x.Id == basketId);
            if (basket != null)
            {
                dbContext.Remove(basket);
                dbContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
