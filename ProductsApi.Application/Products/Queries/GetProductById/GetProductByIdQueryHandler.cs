using MediatR;
using Microsoft.Extensions.Logging;
using ProductsApi.Application.Abstractions;
using ProductsApi.Application.Common;
using ProductsApi.Application.Products.ProductsDto;
using ProductsApi.Domain.Entities;
namespace ProductsApi.Application.Products.Queries.GetProductById
{
    public class GetProductByIdQueryHandler(IProductRepository repository
          , ILogger<GetProductByIdQueryHandler> logger)
    : IRequestHandler<GetProductByIdQuery, ProductDto>
    {
        public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken ct)
        {

            var product = await repository.GetByIdAsync(request.Id, ct);
            if (product == null)
            {
                logger.LogWarning("Product with Id {ProductId} was not found", request.Id);
                throw new NotFoundException($"{nameof(Product)} is not found for id: {request.Id} ");
            }


            return new ProductDto(product.Id, product.Name, product.Price);
        }
    }
}
