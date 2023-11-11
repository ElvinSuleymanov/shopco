using MediatR;
using shopco_API.Application.Interfaces;
using shopco_API.Domain.Models.WishlistModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopco_API.Application.CQRS.Wishlists.Queries
{
    public class GetWishlistQueryHandler:IRequestHandler<GetWishlistQuery, GetUserWishlistResponse>
    {
        private IAccountService _service { get; set; }
        public GetWishlistQueryHandler(IAccountService service)
        {
            _service = service;

        }
        public async Task<GetUserWishlistResponse> Handle(GetWishlistQuery query,CancellationToken cancellation)
        {
            return await _service.GetUserWishlist(query.Request);
        }
    }
}
