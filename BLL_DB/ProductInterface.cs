using BLL.DTOModels;
using BLL.ServiceInterfaces;
using DAL;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.Data;
using System.Reflection.PortableExecutable;
using Model;

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
            var productIdParam = new SqlParameter("@ProductId", productId);
            var basketIdParam = new SqlParameter("@BasketId", basketId);
            _context.Database.ExecuteSqlRaw("EXEC AddProductToBasket @ProductId @BasketId", productIdParam, basketIdParam);
            return true;
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
            List<ProductResponseDTO> products = new List<ProductResponseDTO>();

            var connectionString = DbConnection.ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var sqlQuery = "SELECT p.Id, p.Name, p.Price, p.Image, p.IsActive, p.GroupId, g.Name AS GroupName " +
                                  "FROM Products p LEFT JOIN ProductGroups g ON p.GroupId = g.Id " +
                                  "WHERE 1=1";

                if (!string.IsNullOrWhiteSpace(name))
                    sqlQuery += " AND (p.Name LIKE '%' + @name + '%' OR g.Name LIKE '%' + @name + '%')";
                if (groupId.HasValue)
                    sqlQuery += " AND p.GroupId = @groupId";
                if (isActive.HasValue)
                    sqlQuery += " AND p.IsActive = @isActive";

                if (descending)
                    sqlQuery += " ORDER BY p.Name DESC";
                else
                    sqlQuery += " ORDER BY p.Name ASC";

                SqlCommand command = new SqlCommand(sqlQuery, connection);

                command.Parameters.AddWithValue("@name", name ?? "");
                command.Parameters.AddWithValue("@groupId", groupId ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@isActive", isActive ?? (object)DBNull.Value);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var id = reader.GetInt32(reader.GetOrdinal("Id"));
                        var productName = reader.GetString(reader.GetOrdinal("Name"));
                        var price = reader.GetDouble(reader.GetOrdinal("Price"));
                        var image = reader.GetString(reader.GetOrdinal("Image"));
                        var productIsActive = reader.GetBoolean(reader.GetOrdinal("IsActive"));
                        var productGroupId = reader.IsDBNull(reader.GetOrdinal("GroupId")) ? null : (int?)reader.GetInt32(reader.GetOrdinal("GroupId"));

                        products.Add(new ProductResponseDTO(id, productName, price, image, productIsActive, productGroupId));
                    }
                }

                foreach (var product in products)
                {
                    command = new SqlCommand("GetProductsHierarchyAsString", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ProductId", product.Id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var hierarchia = reader.GetString(0);
                            if (hierarchia != null)
                                product.Name = hierarchia;
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
