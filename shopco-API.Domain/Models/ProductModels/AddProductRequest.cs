using Microsoft.AspNetCore.Http;
using shopco_API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopco_API.Domain.Models.ProductModels
{
    public class AddProductRequest
    {
        public int SellerId { get; set; }
        public int CategorieId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public IFormFile ProductPhoto { get; set; }
    }
}
