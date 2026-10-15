using MediatR;
using ProductsApi.Application.Products.ProductsDto;
namespace ProductsApi.Application.Products.Queries.GetProductById
{
    public record GetProductByIdQuery(int Id) : IRequest<ProductDto>;

}
