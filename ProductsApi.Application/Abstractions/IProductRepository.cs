using ProductsApi.Domain.Entities;

namespace ProductsApi.Application.Abstractions
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync(CancellationToken ct);
        Task<Product?> GetByIdAsync(int id, CancellationToken ct);
        Task AddAsync(Product product, CancellationToken ct);
        Task SaveChangesAsync(CancellationToken ct);
    }
}