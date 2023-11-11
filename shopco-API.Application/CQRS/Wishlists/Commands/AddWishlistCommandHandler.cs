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
    public class AddWishlistCommandHandler : IRequestHandler<AddWishlistCommand, AddWishlistResponse>
    {
        private IAccountService _service { get; set; }
        public AddWishlistCommandHandler(IAccountService service)
        {
            _service = service;

        }
        public async Task<AddWishlistResponse> Handle(AddWishlistCommand command,CancellationToken cancellationToken)
        {
            return await _service.AddToWishlist(command.Request);
        }
    }
}
