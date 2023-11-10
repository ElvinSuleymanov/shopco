using MediatR;
using shopco_API.Domain.Models.AccountModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopco_API.Application.CQRS.Account.Commands
{
    public class AccountLoginCommand:IRequest<LoginResponse>
    {
        public LoginRequest Request { get; set; }
        public AccountLoginCommand(LoginRequest req)
        {
            Request = req;

        }
    }
}
