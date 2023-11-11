using MediatR;
using shopco_API.Domain.Models.WishlistModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopco_API.Application.CQRS.Wishlists.Queries
{
    public class GetWishlistQuery:IRequest<GetUserWishlistResponse>
    {
        public GetUserWishlistRequest Request { get; set; } 
        public GetWishlistQuery(GetUserWishlistRequest req)
        {
            Request = req;

        }
    }
}
