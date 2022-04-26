using MediatR;
using Shop.ModelsDto;
using Shop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.ProductsFeatures.Queries
{
    public class GetAllProducts : IRequest<IEnumerable<ProductDto>>
    {
        public class GetAllProductsHandler : IRequestHandler<GetAllProducts, IEnumerable<ProductDto>>
        {
            private readonly IProductsService productsService;

            public GetAllProductsHandler(IProductsService productsService)
            {
                this.productsService = productsService;
            }

            public async Task<IEnumerable<ProductDto>> Handle(GetAllProducts query, CancellationToken cancellationToken)
            {
                return await productsService.GetProducts();
            }
        }
    }
}
