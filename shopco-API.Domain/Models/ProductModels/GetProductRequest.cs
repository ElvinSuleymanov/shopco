﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopco_API.Domain.Models.ProductModels
{
    public class GetProductRequest
    {
        public int SellerId { get; set; }
        public int? ProductId { get; set; }
    }
}
