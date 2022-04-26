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
    public class DeleteProduct : IRequest<int>
    {
        public int Id { get; set; }

        public class DeletePlayerHandler : IRequestHandler<DeleteProduct, int>
        {
            private readonly IProductsService productsService;

            public DeletePlayerHandler(IProductsService productsService)
            {
                this.productsService = productsService;
            }

            public async Task<int> Handle(DeleteProduct command, CancellationToken cancellationToken)
            {
               
                return await productsService.DeleteProduct(command.Id);
            }
        }
    }
}
