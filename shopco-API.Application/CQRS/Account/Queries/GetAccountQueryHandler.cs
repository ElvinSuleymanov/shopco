using MediatR;
using shopco_API.Application.Interfaces;
using shopco_API.Domain.Models.AccountModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopco_API.Application.CQRS.Account.Queries
{
    public class GetAccountQueryHandler:IRequestHandler<GetAccountQuery,GetAccountResponse>
    {
        public IAccountService accountServices { get; set; }
        public GetAccountQueryHandler(IAccountService service)
        {
            accountServices = service;
        }

        public async Task<GetAccountResponse> Handle(GetAccountQuery request, CancellationToken cancellationToken)
        {
              return await accountServices.GetUserById(request.Request.Id);
        }
    }
}
