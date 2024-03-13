﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ServiceInterfaces
{
    public interface IBasketInterface
    {
        public void ChangeTheAmountOfProductsInBasket(int basketId, int productId, int amount);
        public bool RemoveProductFromBasket(int basketId, int productId);
    }
}
