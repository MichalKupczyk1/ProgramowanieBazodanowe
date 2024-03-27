using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class WebshopContext : DbContext
    {
        public DbSet<ChildrenParentProductGroup>? ChildrenParentProductGroups { get; set; }
        public DbSet<BasketPosition>? BasketPositions { get; set; }
        public DbSet<Order>? Orders { get; set; }
        public DbSet<OrderPosition>? OrderPositions { get; set; }
        public DbSet<Product>? Products { get; set; }
        public DbSet<ProductGroup>? ProductGroups { get; set; }
        public DbSet<User>? Users { get; set; }
        public DbSet<UserGroup>? UserGroups { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DbConnection.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
               .HasMany(x => x.BasketPositions)
               .WithOne()
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ChildrenParentProductGroup>()
                .HasMany(x => x.Children)
                .WithOne()
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<ChildrenParentProductGroup>()
                .HasOne(x => x.Parent)
                .WithMany()
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<UserGroup>()
                .HasMany(x => x.Users)
                .WithOne(x => x.UserGroup)
                .OnDelete(DeleteBehavior.SetNull);

            base.OnModelCreating(modelBuilder);
        }
    }

    public static class DbConnection
    {
        public static string ConnectionString => @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=sqldb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
    }
}