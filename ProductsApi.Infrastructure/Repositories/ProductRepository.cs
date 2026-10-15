using Microsoft.EntityFrameworkCore;
using ProductsApi.Application.Abstractions;
using ProductsApi.Domain.Entities;
using ProductsApi.Infrastructure.Persistence;
namespace ProductsApi.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _db;
        public ProductRepository(AppDbContext db)
        {
            _db = db;
        }
        public Task<List<Product>> GetAllAsync(CancellationToken ct)
            => _db.Products.AsNoTracking().OrderBy(p => p.Id).ToListAsync(ct);

        public Task<Product?> GetByIdAsync(int id, CancellationToken ct)
            => _db.Products.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id, ct);

        public async Task AddAsync(Product product, CancellationToken ct)
            => await _db.Products.AddAsync(product, ct);

        public Task SaveChangesAsync(CancellationToken ct)
            => _db.SaveChangesAsync(ct);
    }
}
