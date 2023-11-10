using MediatR;
using shopco_API.Application.Interfaces;
using shopco_API.Domain.Models.AccountModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopco_API.Application.CQRS.Account.Commands
{
    public class AccountRegisterCommandHandler : IRequestHandler<AccountRegisterCommand, RegisterResponse>
    {
        private IAccountService _accountService { get; set; }
        public AccountRegisterCommandHandler(IAccountService _services)
        {
            _accountService = _services;
        }
        public async Task<RegisterResponse> Handle(AccountRegisterCommand request, CancellationToken cancellationToken)
        {
            await _accountService.RegisterUser(request.Request);
            return new RegisterResponse();
        }
    }
}
