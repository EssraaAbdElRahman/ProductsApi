using MediatR;
using Microsoft.Extensions.Logging;
using ProductsApi.Application.Abstractions;
using ProductsApi.Domain.Entities;
namespace ProductsApi.Application.Products.Commands.CreateProduct
{

    public class CreateProductCommandHandler(IProductRepository repository
        , ILogger<CreateProductCommandHandler> logger)
        : IRequestHandler<CreateProductCommand, int>
    {
        public async Task<int> Handle(CreateProductCommand request, CancellationToken ct)
        {

            logger.LogInformation("Creating product {ProductName} with price {Price}",
                request.Name, request.Price);

            var product = Product.Create(request.Name, request.Price);


            await repository.AddAsync(product, ct);
            await repository.SaveChangesAsync(ct);
            logger.LogInformation("Product created with Id {ProductId}", product.Id);
            return product.Id;
        }
    }
}