using MediatR;
using Microsoft.AspNetCore.Mvc;
using shopco_API.Application.CQRS.Seller.Commands;
using shopco_API.Domain.Models.SellerModels;

namespace shopco_API.Controllers
{
    [ApiController]
    public class SellerController : Controller
    {
        public  IMediator mediator { get; set; }
        public SellerController(IMediator mediatr)
        {
            mediator = mediatr;
        }


        [Route("/seller/register")]
        [HttpPost]
        public async Task<RegisterSellerResponse> Create([FromForm] RegisterSellerRequest request)
        {
            return await mediator.Send(new RegisterSellerCommand(request));
        }
    }
}
