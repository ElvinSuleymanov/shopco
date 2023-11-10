using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopco_API.Domain.Models.SellerModels
{
    public class LoginSellerResponse
    {
        public int Status { get; set; } 
        public string StatusMessage { get; set; }
        public string JwtToken { get; set; }    
    }
}
