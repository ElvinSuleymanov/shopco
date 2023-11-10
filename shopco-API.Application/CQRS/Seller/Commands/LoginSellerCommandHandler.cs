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
    public class LoginSellerCommandHandler : IRequestHandler<LoginSellerCommand, LoginSellerResponse>
    {
        private ISellerService _service { get; set; }
        public LoginSellerCommandHandler(ISellerService service)
        {
            _service = service;
        }
        public async Task<LoginSellerResponse> Handle(LoginSellerCommand request, CancellationToken cancellationToken)
        {
           return await  _service.Login(request.Request);

        }
    }
}
