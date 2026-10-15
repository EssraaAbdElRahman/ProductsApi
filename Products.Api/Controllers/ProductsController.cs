using MediatR;
using Microsoft.AspNetCore.Mvc;
using Products.Api.Contracts;
using ProductsApi.Application.Products.Commands.CreateProduct;
using ProductsApi.Application.Products.ProductsDto;
using ProductsApi.Application.Products.Queries.GetProductById;
using ProductsApi.Application.Products.Queries.GetProducts;

namespace Products.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ISender _sender;
        public ProductsController(ISender sender)
        {
            _sender = sender;
        }
        [HttpGet]
        public async Task<ActionResult<List<ProductDto>>> GetAll(CancellationToken ct)
       => Ok(await _sender.Send(new GetProductsQuery(), ct));

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductDto>> GetById(int id, CancellationToken ct)
            => Ok(await _sender.Send(new GetProductByIdQuery(id), ct));

        [HttpPost]
        public async Task<ActionResult<ProductDto>> Create(
            CreateProductRequest request, CancellationToken ct)
        {
            var id = await _sender.Send(new CreateProductCommand(request.Name, request.Price), ct);
            var created = await _sender.Send(new GetProductByIdQuery(id), ct);

            return CreatedAtAction(nameof(GetById), new { id }, created);
        }
    }
}
