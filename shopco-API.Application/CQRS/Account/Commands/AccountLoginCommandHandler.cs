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
    public class AccountLoginCommandHandler : IRequestHandler<AccountLoginCommand, LoginResponse>
    {
        public IAccountService _accountService { get; set; }
        public AccountLoginCommandHandler(IAccountService accountService)
        {
            _accountService = accountService;
        }
        public async Task<LoginResponse> Handle(AccountLoginCommand request, CancellationToken cancellationToken)
        {
            return await _accountService.LoginUser(request.Request);
        }
    }
}
