using MediatR;
using shopco_API.Application.Interfaces;
using shopco_API.Domain.Models.ProductModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopco_API.Application.CQRS.Products.Commands
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommand, AddProductResponse>
    {
        private ISellerService _service { get; set; }
        public AddProductCommandHandler(ISellerService service)
        {
            _service = service;
        }
        public async Task<AddProductResponse> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
           return await _service.AddProduct(request.request);
        }
    }
}
