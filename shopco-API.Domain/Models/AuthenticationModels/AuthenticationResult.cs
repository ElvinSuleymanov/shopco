using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopco_API.Domain.Models.AuthenticationModels
{
    public  class AuthenticationResult
    {
        public int StatusCode { get; set; } 
        public string StatusMessage { get; set; }
        public bool isSuccess { get; set; }   
    }
}
