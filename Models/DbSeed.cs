using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class DbSeed
    {
        private readonly ProductsDbContext dbContext;

        public DbSeed(ProductsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Seed()
        {
            if (dbContext.Database.CanConnect())
            {
                if (!dbContext.Products.Any())
                {
                    var products = GetProducts();
                    dbContext.Products.AddRange(products);
                    dbContext.SaveChanges();
                }
            }
        }
            private IEnumerable<Product> GetProducts()
            {
            DateTime date = new DateTime(2022,04,21,13,30,00);
            var products = new List<Product>()
                {
                    new Product() {CreateAt = date, Name = "Pudełko", Description = "Małe ładne pudełko", Price = 20 },
                    new Product() {CreateAt = date, Name = "Kalosz", Description = "Duży gumowy kalosz", Price = 30 },
                    new Product() {CreateAt = date, Name = "Gumka", Description = "Mała gumka do ścierania", Price = 5 },
                    new Product() {CreateAt = date, Name = "Ołówek", Description = "Nowy zielony ołówek", Price = 5 },
                    new Product() {CreateAt = date, Name = "Długopis", Description = "Ma wymienny wkład", Price = 7 },
                    new Product() {CreateAt = date, Name = "Lampka", Description = "Dodatkowo kolorowe żarówki", Price = 40 },
                    new Product() {CreateAt = date, Name = "Myszka", Description = "Niezbędna do komputera", Price = 50 },
                    new Product() { CreateAt = date, Name = "Pinezka", Description = "Opakowanie ma 50 sztuk", Price = 20 },
                    new Product() {CreateAt = date, Name = "Kubek", Description = "Na ściance ma ładny widok", Price = 15 },
                    new Product() {CreateAt = date, Name = "Kartki", Description = "Opakowanie ma 100 sztuk", Price = 20 }

                };

            return products;
            }
    }
}
