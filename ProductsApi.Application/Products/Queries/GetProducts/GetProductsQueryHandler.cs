using MediatR;
using ProductsApi.Application.Abstractions;
using ProductsApi.Application.Products.ProductsDto;

namespace ProductsApi.Application.Products.Queries.GetProducts
{
    public class GetProductsQueryHandler(IProductRepository repository)
     : IRequestHandler<GetProductsQuery, List<ProductDto>>
    {
        public async Task<List<ProductDto>> Handle(GetProductsQuery request, CancellationToken ct)
        {
            var products = await repository.GetAllAsync(ct);
            return products.Select(p => new ProductDto(p.Id, p.Name, p.Price)).ToList();
        }
    }
}
 