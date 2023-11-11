using MediatR;
using Microsoft.AspNetCore.Mvc;
using shopco_API.Application.CQRS.Wishlists.Commands;
using shopco_API.Application.CQRS.Wishlists.Queries;
using shopco_API.Domain.Models.WishlistModels;

namespace shopco_API.Controllers
{
    [ApiController]
    public class WishlistController : Controller
    {
        private IMediator _mediator { get; set; }
        public WishlistController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [Route("/wishlist/add")]
        [HttpPost]
        public async Task<AddWishlistResponse> AddToUsersWishlist([FromQuery] AddWishlistRequest req)
        {
            return await _mediator.Send(new AddWishlistCommand(req));
        }
        [Route("/wishlist/read")]
        [HttpGet]
        public async Task<GetUserWishlistResponse> GetWishlist([FromQuery] GetUserWishlistRequest req)
        {
            return await _mediator.Send(new  GetWishlistQuery(req));
        }

        [Route("/wishlist/delete")]
        [HttpDelete]
        public async Task<DeleteUserWishlistResponse> DeleteWishlist([FromQuery] DeleteUserWishlistRequest req)
        {
            return await _mediator.Send(new DeleteUserWishlistCommand(req));
        }
    }
}
