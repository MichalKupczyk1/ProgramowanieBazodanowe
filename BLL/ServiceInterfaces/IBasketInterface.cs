using BLL.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ServiceInterfaces
{
    public interface IBasketInterface
    {
        public void AddProductToBasket(int basketId, int productId, int amount);
        public void ChangeTheAmountOfProductsInBasket(int basketId, int amount);
        public bool RemoveProductFromBasket(int basketId);
        public List<BasketPositionResponseDTO> GetBasketPositions();
        public BasketPositionResponseDTO GetById(int id);
    }
}
