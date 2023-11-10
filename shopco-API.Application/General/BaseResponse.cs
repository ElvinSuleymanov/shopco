using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopco_API.Application.General
{
    public class BaseResponse
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get => StatusCode == 200 ? "Operation Finished Successfully" : "Operation Failed"; }

      
    }
}
