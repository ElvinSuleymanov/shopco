using MediatR;
using shopco_API.Application.Interfaces;
using shopco_API.Domain.Models.ProductModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopco_API.Application.CQRS.Products.Queries
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, GetProductResponse>
    {
   
        private ISellerService _service { get; set; }
        public GetProductQueryHandler(ISellerService service)
        {
            _service = service;
        }
        public async Task<GetProductResponse> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            return await _service.GetProductById(request.Request);
        }
    }
}
