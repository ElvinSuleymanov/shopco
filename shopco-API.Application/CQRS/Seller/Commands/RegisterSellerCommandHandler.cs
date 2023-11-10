using MediatR;
using shopco_API.Application.Interfaces;
using shopco_API.Domain.Models.SellerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopco_API.Application.CQRS.Seller.Commands
{
    public class RegisterSellerCommandHandler:IRequestHandler<RegisterSellerCommand,RegisterSellerResponse>
    {
        private readonly ISellerService _service;

        public RegisterSellerCommandHandler(ISellerService sellerService)
        {
            _service = sellerService;
        }

        public  async Task<RegisterSellerResponse> Handle(RegisterSellerCommand request, CancellationToken cancellationToken)
        {
            return await _service.Register(request.Request);
        }
    }
}
