using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shop.Models;
using Shop.ModelsDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Services
{
    public interface IProductsService
    {
        Task<ProductDto> GetProduct(int Id);
        Task<IEnumerable<ProductDto>> GetProducts();
        Task<Product> CreateProduct(CreateProductDto productDto);
        Task<int> DeleteProduct(int id);
        Task<int> EditProduct(ProductDto productDto);
    }

    public class ProductsService : IProductsService
    {
        private readonly ProductsDbContext dbContext;
        private readonly IMapper mapper;

        public ProductsService(ProductsDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<ProductDto> GetProduct(int id)
        {
            var product = await dbContext.Products.FirstOrDefaultAsync(product => product.Id == id);
            if(product is null)
            {
                return null;
            }
            var result = mapper.Map<ProductDto>(product);
            return result;
        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            var products = await dbContext.Products.ToListAsync();
            var result = mapper.Map<List<ProductDto>>(products);
            return result;
        }

        public async Task<Product> CreateProduct(CreateProductDto productDto)
        {
            var product = mapper.Map<Product>(productDto);
            product.CreateAt = DateTime.Now;
            dbContext.Products.Add(product);
            await dbContext.SaveChangesAsync();
            return product;
        }
        public async Task<int> DeleteProduct(int id)
        {
            var product = mapper.Map<Product>( await dbContext.Products.FirstOrDefaultAsync(product => product.Id == id));
            dbContext.Products.Remove(product);
            return await dbContext.SaveChangesAsync();
        }

        public async Task<int> EditProduct(ProductDto productDto)
        {

            dbContext.Products.Update(mapper.Map<Product>(productDto));
            return await dbContext.SaveChangesAsync();
        }
    }

}
