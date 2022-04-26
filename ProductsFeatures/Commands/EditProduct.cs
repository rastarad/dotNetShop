using MediatR;
using Shop.ModelsDto;
using Shop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.ProductsFeatures.Commands
{
    public class EditProduct : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }

        public class EditProductHandler : IRequestHandler<EditProduct, int>
        {
            private readonly IProductsService productsService;

            public EditProductHandler(IProductsService productsService)
            {
                this.productsService = productsService;
            }

            public async Task<int> Handle(EditProduct command, CancellationToken cancellationToken)
            {
                var product = new ProductDto();
                product.Id = command.Id;
                product.Name = command.Name;
                product.Description = command.Description;
                product.Price = command.Price;
                product.CreateAt = DateTime.Now;

                return await productsService.EditProduct(product);
            }
        }
    }
}
