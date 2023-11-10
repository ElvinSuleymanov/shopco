using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopco_API.Domain.Models.SellerModels
{
    public class LoginSellerRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
