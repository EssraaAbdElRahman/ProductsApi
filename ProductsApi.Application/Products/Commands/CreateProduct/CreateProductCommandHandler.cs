using MediatR;
using ProductsApi.Application.Abstractions;
using ProductsApi.Domain.Entities;
namespace ProductsApi.Application.Products.Commands.CreateProduct
{

    public class CreateProductCommandHandler(IProductRepository repository)
        : IRequestHandler<CreateProductCommand, int>
    {
        public async Task<int> Handle(CreateProductCommand request, CancellationToken ct)
        {
            var product = Product.Create(request.Name, request.Price);

            await repository.AddAsync(product, ct);
            await repository.SaveChangesAsync(ct);

            return product.Id;
        }
    }
}