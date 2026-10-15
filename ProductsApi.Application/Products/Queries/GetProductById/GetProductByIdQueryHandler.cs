using MediatR;
using ProductsApi.Application.Abstractions;
using ProductsApi.Application.Common;
using ProductsApi.Application.Products.ProductsDto;
using ProductsApi.Domain.Entities;
namespace ProductsApi.Application.Products.Queries.GetProductById
{
    public class GetProductByIdQueryHandler(IProductRepository repository)
    : IRequestHandler<GetProductByIdQuery, ProductDto>
    {
        public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken ct)
        {
            var product = await repository.GetByIdAsync(request.Id, ct)
                ?? throw new NotFoundException($"{nameof(Product)} is not found for id: {request.Id} " );

            return new ProductDto(product.Id, product.Name, product.Price);
        }
    }
}
