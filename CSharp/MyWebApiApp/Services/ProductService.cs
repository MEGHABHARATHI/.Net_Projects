using MyWebApiApp.Models;
using Microsoft.EntityFrameworkCore;

namespace MyWebApiApp.Services
{
    public class ProductService
    {
        private readonly AppDbContext dbcontext;
        public ProductService(AppDbContext _dbcontext)
        {
            dbcontext = _dbcontext;
        }

        public async Task<List<Products>> GetAllProducts()
        {
            return await dbcontext.Product.ToListAsync();
        }

        public async Task<Products> GetProductById(int id)
        {
            return await dbcontext.Product.FindAsync(id);
        }
        public async Task<Products> AddProductAsync(Products Product)
        {
            dbcontext.Product.Add(Product);
            await dbcontext.SaveChangesAsync();
            return Product;
        }
    }
}
