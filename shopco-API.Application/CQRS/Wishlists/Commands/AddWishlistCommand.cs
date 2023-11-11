using MediatR;
using shopco_API.Domain.Models.WishlistModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopco_API.Application.CQRS.Wishlists.Commands
{
    public class AddWishlistCommand:IRequest<AddWishlistResponse>
    {
        public AddWishlistRequest Request { get; set; } 
        public AddWishlistCommand(AddWishlistRequest req)
        {
            Request = req;
        }
    }
}
