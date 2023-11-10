using MediatR;
using shopco_API.Domain.Models.ProductModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopco_API.Application.CQRS.Products.Commands
{
    public class AddProductCommand:IRequest<AddProductResponse>
    {
        public AddProductRequest request { get; set; }
        public AddProductCommand(AddProductRequest req)
        {
            request = req;
        }
    }
}
