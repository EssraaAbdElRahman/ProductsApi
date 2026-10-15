using MediatR;
namespace ProductsApi.Application.Products.Commands.CreateProduct
{
    public record CreateProductCommand(string Name, decimal Price) : IRequest<int>;
}
