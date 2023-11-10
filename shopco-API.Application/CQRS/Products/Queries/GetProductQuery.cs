using MediatR;
using shopco_API.Domain.Models.ProductModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopco_API.Application.CQRS.Products.Queries
{
    public class GetProductQuery:IRequest<GetProductResponse>
    {
        public GetProductRequest Request {get;set;}
        public GetProductQuery(GetProductRequest req)
        {
            Request = req;
        }
    }
}
