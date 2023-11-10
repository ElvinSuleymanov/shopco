using MediatR;
using Microsoft.AspNetCore.Mvc;
using shopco_API.Application.CQRS.Account.Queries;
using shopco_API.Application.CQRS.Products.Commands;
using shopco_API.Application.CQRS.Products.Queries;
using shopco_API.Domain.Models.ProductModels;

namespace shopco_API.Controllers
{
    [ApiController]
    public class ProductController : Controller
    {

        public IMediator Mediator { get => _mediator ?? HttpContext.RequestServices.GetRequiredService<IMediator>(); }
        private readonly IMediator _mediator;
        public ILogger<ProductController> logger { get; set; }

        public ProductController(IMediator mediator, ILogger<ProductController> log)
        {
            logger = log;
            _mediator = mediator;

        }
        [HttpPost]
        [Route("/products/add")]
        public async Task<AddProductResponse> AddProduct([FromForm] AddProductRequest request)
        {
            return await Mediator.Send(new AddProductCommand(request));
        }
        [HttpGet]
        [Route("/products/get")]
        public async Task<GetProductResponse> GetProductById([FromQuery] GetProductRequest request)
        {
            return await Mediator.Send(new GetProductQuery(request));
        }

    }
}
