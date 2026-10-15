using MediatR;
using ProductsApi.Application.Products.ProductsDto;
namespace ProductsApi.Application.Products.Queries.GetProducts
{
    public record GetProductsQuery : IRequest<List<ProductDto>>;
}
