using BLL.DTOModels;
using BLL.ServiceInterfaces;
using DAL;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace BLL_DB
{
    public class ProductInterface : IProductInterface
    {
        private readonly WebshopContext _context;

        public ProductInterface(WebshopContext _context)
        {
            this._context = _context;
        }

        public bool ActivateProduct(int productId)
        {
            var sql = "UPDATE Products " +
                      "SET IsActive = 1 " +
                      "WHERE Id = @ProductId";
            var parameter = new SqlParameter("@ProductId", productId);
            int rowsAffected = _context.Database.ExecuteSqlRaw(sql, parameter);
            return rowsAffected > 0;
        }

        public void AddNewProduct(string name, double price, int? groupId)
        {
            throw new NotImplementedException();
        }

        public int AddNewProduct(string name, string image, double price, int? groupId)
        {
            var sql = "INSERT INTO Products (Name, Image, Price, GroupId, IsActive) " +
                  "VALUES (@Name, @Image, @Price, @GroupId, 1);";

            var parameters = new[]
            {
            new SqlParameter("@Name", name),
            new SqlParameter("@Image", image),
            new SqlParameter("@Price", price),
            new SqlParameter("@GroupId", groupId)
        };
            return _context.Database.ExecuteSqlRaw(sql, parameters);
        }

        public bool AddProductToBasket(int productId, int basketId)
        {
            throw new NotImplementedException();
        }

        public bool DeactivateProduct(int productId)
        {
            var sql = "UPDATE Products " +
                      "SET IsActive = 0 " +
                      "WHERE Id = @ProductId";
            var parameter = new SqlParameter("@ProductId", productId);
            int rowsAffected = _context.Database.ExecuteSqlRaw(sql, parameter);
            return rowsAffected > 0;
        }

        public ProductResponseDTO GetProductById(int productId)
        {
            throw new NotImplementedException();
        }

        public List<ProductResponseDTO> GetProducts()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductResponseDTO> GetProductsByFilters(string name, int? groupId, bool? isActive, bool descending = false)
        {
            var connectionString = DbConnection.ConnectionString;

            var sql = "DECLARE @Hierarchy NVARCHAR(MAX); " +
                      "DECLARE @ProductId INT; " +
                      "SELECT @ProductId = p.Id " +
                      "FROM Products p " +
                      "WHERE 1=1 ";

            if (!string.IsNullOrWhiteSpace(name))
            {
                sql += "AND p.Name LIKE CONCAT('%', @Name, '%'); ";
            }

            if (groupId.HasValue)
            {
                sql += "AND p.GroupId = @GroupId; ";
            }

            sql += "EXEC dbo.GetGroupHierarchyProcedure @ProductId = @ProductId; " +
                   "SELECT p.Id, p.Name, p.Price, @Hierarchy AS GroupName " +
                   "FROM Products p " +
                   "WHERE 1=1 ";

            if (!string.IsNullOrWhiteSpace(name))
            {
                sql += "AND p.Name LIKE CONCAT('%', @Name, '%') ";
            }

            if (groupId.HasValue)
            {
                sql += "AND p.GroupId = @GroupId ";
            }

            if (isActive.HasValue)
            {
                sql += "AND p.IsActive = @IsActive ";
            }

            sql += descending ? "ORDER BY p.Name DESC;" : "ORDER BY p.Name;";

            var products = new List<ProductResponseDTO>();

            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand(sql, connection))
                {
                    if (!string.IsNullOrWhiteSpace(name))
                    {
                        command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = name;
                    }

                    if (groupId.HasValue)
                    {
                        command.Parameters.Add("@GroupId", SqlDbType.Int).Value = groupId.Value;
                    }

                    if (isActive.HasValue)
                    {
                        command.Parameters.Add("@IsActive", SqlDbType.Bit).Value = isActive.Value;
                    }

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var productId = reader.GetInt32(0);
                            var productName = reader.GetString(1);
                            var productPrice = reader.GetDouble(2);
                            var productGroupName = reader.GetString(3);

                            var product = new ProductResponseDTO(new Product { Id = productId, Name = productName, Price = (double)productPrice }, productGroupName);
                            products.Add(product);
                        }
                    }
                }
            }

            return products;
        }




        public bool RemoveProduct(int productId)
        {
            throw new NotImplementedException();
        }
    }
}
