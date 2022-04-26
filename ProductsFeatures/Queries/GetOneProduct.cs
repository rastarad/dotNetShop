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
    public class GetOneProduct : IRequest<ProductDto>
    {
        public int Id { get; set; }
        public class GetOneProductHandler : IRequestHandler<GetOneProduct, ProductDto>
        {
            private readonly IProductsService productsService;

            public GetOneProductHandler(IProductsService productsService)
            {
                this.productsService = productsService;
            }

            public async Task<ProductDto> Handle(GetOneProduct query, CancellationToken cancellationToken)
            {
                return await productsService.GetProduct(query.Id);
            }
        }
    }
}
