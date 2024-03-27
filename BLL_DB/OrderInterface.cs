using BLL.DTOModels;
using BLL.ServiceInterfaces;
using DAL;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DB
{
    public class OrderInterface : IOrderInterface
    {
        private readonly WebshopContext _context;

        public OrderInterface(WebshopContext context)
        {
            this._context = context;
        }

        public void CreateOrder(int userId)
        {
            var userIdParam = new SqlParameter("@UserId", userId);
            _context.Database.ExecuteSqlRaw("EXEC CreateOrderForUser @UserId", userIdParam);
        }

        /*
         CREATE PROCEDURE CreateOrderForUser
            @UserId INT
            AS
            BEGIN
                -- Tworzenie nowego zamówienia dla użytkownika
                DECLARE @OrderId INT;
                INSERT INTO Orders (UserId, Date, IsPaid)
                VALUES (@UserId, GETDATE(), 0);

                -- Pobieranie identyfikatora nowo utworzonego zamówienia
                SELECT @OrderId = SCOPE_IDENTITY();

                -- Dodawanie pozycji zamówienia dla produktów z koszyka użytkownika
                INSERT INTO OrderPositions (OrderId, ProductId)
                SELECT @OrderId, ProductId
                FROM BasketPositions
                WHERE UserId = @UserId;

                -- Czyszczenie koszyka użytkownika (opcjonalnie)
                DELETE FROM BasketPositions WHERE UserId = @UserId;
            END
*/

        public OrderResponseDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderResponseDTO> GetOrders()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderResponseDTO> GetOrdersByDate(DateTime date, bool descending = false)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderResponseDTO> GetOrdersByPrice(double price, bool descending = false)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderResponseDTO> GetOrdersByStatus(bool paid)
        {
            throw new NotImplementedException();
        }

        public void PayForOrder(int orderId, double amountPaid)
        {
            var orderIdParam = new SqlParameter("@OrderId", orderId);
            var amountPaidParam = new SqlParameter("@AmountPaid", (decimal)amountPaid);
            _context.Database.ExecuteSqlRaw("EXEC PayForOrder @OrderId, @AmountPaid", orderIdParam, amountPaidParam);
        }
        /*
         * CREATE PROCEDURE PayForOrder
                @OrderId INT,
                @AmountPaid DECIMAL(18, 2)
            AS
            BEGIN
                -- Aktualizacja informacji o zamówieniu
                UPDATE Orders
                SET AmountPaid = @AmountPaid,
                    IsPaid = CASE WHEN @AmountPaid >= TotalAmount THEN 1 ELSE 0 END
                WHERE Id = @OrderId;
            END

         */
    }
}
