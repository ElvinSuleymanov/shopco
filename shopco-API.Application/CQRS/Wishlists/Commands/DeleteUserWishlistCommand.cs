using MediatR;
using shopco_API.Domain.Models.WishlistModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopco_API.Application.CQRS.Wishlists.Commands
{
    public class DeleteUserWishlistCommand:IRequest<DeleteUserWishlistResponse>
    {
        public DeleteUserWishlistRequest Request { get; set; }  
        public DeleteUserWishlistCommand(DeleteUserWishlistRequest req)
        {
            Request = req;
        }
    }
}
