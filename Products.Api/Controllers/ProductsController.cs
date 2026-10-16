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
        private readonly ILogger<ProductsController> _logger;
        public ProductsController(ISender sender,ILogger<ProductsController> logger)
        {
            _sender = sender;
            _logger = logger;
        }
        [HttpGet]
        public async Task<ActionResult<List<ProductDto>>> GetAll(CancellationToken ct)
        {
            var products = await _sender.Send(new GetProductsQuery(), ct);

            if (products.Count == 0)
                _logger.LogInformation("GetAll returned an empty list");
            return Ok(products);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductDto>> GetById(int id, CancellationToken ct)
        {
            var product = await _sender.Send(new GetProductByIdQuery(id), ct);
          
            return Ok(product);
        }
        [HttpPost]
        public async Task<ActionResult<ProductDto>> Create(
            CreateProductRequest request, CancellationToken ct)
        {
            var id = await _sender.Send(new CreateProductCommand(request.Name, request.Price), ct);
            var created = await _sender.Send(new GetProductByIdQuery(id), ct);
           _logger.LogInformation("Returning 201 Created for product {ProductId}", id);

            return CreatedAtAction(nameof(GetById), new { id }, created);
        }
    }
}
