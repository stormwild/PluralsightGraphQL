using CarvedRockWeb.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace CarvedRockWeb.Api.Services
{
    public class ProductRepository : IProductRepository
    {
        private readonly CarvedRockDbContext _ctx;

        public ProductRepository(CarvedRockDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync(CancellationToken token)
        {
            return await _ctx.Products.AsNoTracking().ToListAsync(token);
        }
    }
}
