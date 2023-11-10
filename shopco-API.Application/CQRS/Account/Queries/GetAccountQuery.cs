using MediatR;
using shopco_API.Domain.Models.AccountModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopco_API.Application.CQRS.Account.Queries
{
    public class GetAccountQuery:IRequest<GetAccountResponse>
    {
         
        public GetAccountRequest Request { get; set; }  
        public GetAccountQuery(GetAccountRequest req)
        {
            
            Request = req;
        }
    }
}
