using MediatR;
using shopco_API.Domain.Models.SellerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopco_API.Application.CQRS.Seller.Commands
{
    public class RegisterSellerCommand:IRequest<RegisterSellerResponse>
    {
        public RegisterSellerRequest Request { get; set; }
        public RegisterSellerCommand(RegisterSellerRequest req)
        {
            Request = req;
        }
    }
}
