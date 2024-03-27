using BLL.DTOModels;
using BLL.ServiceInterfaces;
using DAL;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DB
{
    public class BasketInterface : IBasketInterface
    {
        private readonly WebshopContext _context;
        public BasketInterface(WebshopContext context)
        {
            _context = context;
        }

        public void AddProductToBasket(int basketId, int productId, int amount)
        {
            var sql = @"
            IF EXISTS (SELECT 1 FROM BasketPositions WHERE Id = @Id AND ProductId = @ProductId)
            BEGIN
                UPDATE BasketPositions
                SET Amount = Amount + @Amount
                WHERE Id = @Id AND ProductId = @ProductId
            END
            ELSE
            BEGIN
                INSERT INTO BasketPositions (Id, ProductId, Amount)
                VALUES (@Id, @ProductId, @Amount)
            END";

            var parameters = new[]
            {
            new SqlParameter("@Id", basketId),
            new SqlParameter("@ProductId", productId),
            new SqlParameter("@Amount", amount)
        };

            _context.Database.ExecuteSqlRaw(sql, parameters);
        }

        public void ChangeTheAmountOfProductsInBasket(int basketId, int amount)
        {
            var sql = @"
            UPDATE BasketPositions
            SET Amount = @Amount
            WHERE Id = @Id";

            var parameters = new[]
            {
            new SqlParameter("@Id", basketId),
            new SqlParameter("@Amount", amount)
        };

            _context.Database.ExecuteSqlRaw(sql, parameters);
        }

        public bool RemoveProductFromBasket(int basketId)
        {
            var sql = @"
            UPDATE BasketPositions
            SET ProductId = NULL,
                Amount = 0
            WHERE Id = @Id";

            var parameter = new SqlParameter("@Id", basketId);
            int rowsAffected = _context.Database.ExecuteSqlRaw(sql, parameter);
            return rowsAffected > 0;
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
