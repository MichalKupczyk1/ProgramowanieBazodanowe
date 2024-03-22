using BLL.DTOModels;
using BLL.ServiceInterfaces;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DB
{
    public class BasketInterface : IBasketInterface
    {
        public void AddProductToBasket(int basketId, int productId, int amount)
        {
            throw new NotImplementedException();
        }

        public void ChangeTheAmountOfProductsInBasket(int basketId, int amount)
        {
            throw new NotImplementedException();
        }

        public bool RemoveProductFromBasket(int basketId)
        {
            throw new NotImplementedException();
        }

        public List<BasketPositionResponseDTO> GetBasketPositions()
        {
            throw new NotImplementedException();
        }

        public BasketPositionResponseDTO GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
