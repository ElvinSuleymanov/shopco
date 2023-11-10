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
        public async Task<RegisterSellerResponse> Register([FromForm] RegisterSellerRequest request)
        {
            return await mediator.Send(new RegisterSellerCommand(request));
        }

        [Route("/seller/login")]
        [HttpPost]
        public async Task<LoginSellerResponse> Login([FromForm] LoginSellerRequest request)
        {
            return await mediator.Send(new LoginSellerCommand(request));
        }
    }
}
