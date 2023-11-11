using MediatR;
using shopco_API.Application.Interfaces;
using shopco_API.Domain.Models.WishlistModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopco_API.Application.CQRS.Wishlists.Commands
{
    public class DeleteUserWishlistCommandHandler : IRequestHandler<DeleteUserWishlistCommand, DeleteUserWishlistResponse>
    {
        private IAccountService _service { get; set; }
        public DeleteUserWishlistCommandHandler(IAccountService service)
        {
            _service = service;
        }
        public async Task<DeleteUserWishlistResponse> Handle(DeleteUserWishlistCommand request, CancellationToken cancellationToken)
        {
           return await _service.DeleteUserWishlist(request.Request);
        }
    }
}
