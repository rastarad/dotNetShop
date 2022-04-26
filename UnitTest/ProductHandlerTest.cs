using AutoMapper;
using Moq;
using Shop.Mapper;
using Shop.Models;
using Shop.ModelsDto;
using Shop.ProductsFeatures.Queries;
using Shop.Services;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using static Shop.ProductsFeatures.Queries.GetAllProducts;

namespace UnitTest
{

    public class ProductHandlerTest
    {
        private readonly Mock<IProductsService> mockProducts;

        public ProductHandlerTest()
        {
            mockProducts = MockProducts.GetProductsService();
        }

        [Fact]
        public async Task GetAllProducts_Returns_The_Type_Of_Products()
        {
            var handler = new GetAllProductsHandler(mockProducts.Object);
            var result = await handler.Handle(new GetAllProducts(), CancellationToken.None);
            result.ShouldBeOfType<List<ProductDto>>();
        }
    }
}
