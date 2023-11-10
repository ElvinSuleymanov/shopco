using shopco_API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopco_API.Domain.Models.ProductModels
{
    public class GetProductResponse
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get => StatusCode == 200 ? "Operation Finished Successfully" : "Operation Failed"; }
        public List<Product> Products { get; set; }
    }
}
