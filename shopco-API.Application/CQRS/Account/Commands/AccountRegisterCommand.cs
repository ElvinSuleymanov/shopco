using MediatR;
using shopco_API.Domain.Models.AccountModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopco_API.Application.CQRS.Account.Commands
{
    public class AccountRegisterCommand:IRequest<RegisterResponse>
    {
        public RegisterRequest Request { get; set; }
        public AccountRegisterCommand(RegisterRequest request)
        {
            Request = request;
        }
    }
}
