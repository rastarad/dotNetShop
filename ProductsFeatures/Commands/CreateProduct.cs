using MediatR;
using Shop.Models;
using Shop.ModelsDto;
using Shop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.ProductsFeatures.Commands
{
    public class CreateProduct : IRequest<Product>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }

        public class CreateProductHandler : IRequestHandler<CreateProduct, Product>
        {
            private readonly IProductsService productsService;

            public CreateProductHandler(IProductsService productsService)
            {
                this.productsService = productsService;
            }

            public async Task<Product> Handle(CreateProduct command, CancellationToken cancellationToken)
            {
                var product = new CreateProductDto()
                {
                    Name = command.Name,
                    Description = command.Description,
                    Price = command.Price
                };
                var result = await productsService.CreateProduct(product);
                return result;
            }
        }
    }
}
