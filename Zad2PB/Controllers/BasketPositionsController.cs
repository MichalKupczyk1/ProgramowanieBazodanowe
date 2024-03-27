using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL;
using Model;
using BLL.ServiceInterfaces;

namespace Zad2PB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketPositionsController : ControllerBase
    {
        private readonly IBasketInterface _basketInterface;

        public BasketPositionsController(IBasketInterface basketInterface)
        {
            this._basketInterface = basketInterface;
        }

        [HttpPost("AddProductToBasket")]
        public void AddProductToBasket(int productId, int basketId, int amount)
        {
            _basketInterface.AddProductToBasket(basketId, productId, amount);
        }

        [HttpGet("RemoveProductFromBasket")]
        public bool RemoveProductFromBasket(int basketId)
        {
            return _basketInterface.RemoveProductFromBasket(basketId);
        }

        [HttpPost("ChangeTheAmountOfProductsInBasket")]
        public void ChangeTheAmountOfProductsInBasket(int productId, int basketId, int amount)
        {
            _basketInterface.ChangeTheAmountOfProductsInBasket(basketId, amount);
        }
    }
}
