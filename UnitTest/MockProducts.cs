using Moq;
using Shop.Models;
using Shop.ModelsDto;
using Shop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    public static class MockProducts
    {
        public static Mock<IProductsService> GetProductsService()
        {
            DateTime date = new DateTime(2022, 04, 21, 13, 30, 00);
            var products = new List<ProductDto>()
                {
                    new ProductDto() {CreateAt = date, Name = "Pudełko", Description = "Małe ładne pudełko", Price = 20 },
                    new ProductDto() {CreateAt = date, Name = "Kalosz", Description = "Duży gumowy kalosz", Price = 30 },

                };

            var mockProduct = new Mock<IProductsService>();
            mockProduct.Setup(r => r.GetProducts()).ReturnsAsync(products);

            return mockProduct;
        }
 
    }
}
