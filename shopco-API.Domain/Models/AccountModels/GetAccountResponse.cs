using shopco_API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopco_API.Domain.Models.AccountModels
{
    public class GetAccountResponse
    {
       public int StatusCode { get; set; }
       public AccountResponse User { get; set; }
       public string Message { get; set; }
    }
}
