﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringProgram.Models.Responses
{
    public class AddOrderResponse : Response
    {
        public Order Order { get; set; }
    }
}
