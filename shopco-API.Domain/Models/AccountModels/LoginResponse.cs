using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopco_API.Domain.Models.AccountModels
{
    public class LoginResponse
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public string JwtToken { get; set; }    
    }
}
