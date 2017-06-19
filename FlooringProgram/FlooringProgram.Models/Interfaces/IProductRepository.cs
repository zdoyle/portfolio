﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringProgram.Models.Interfaces
{
    public interface IProductRepository
    {
        List<Product> GetListOfProducts();
        Product GetSingleProduct(string productType);
    }
}
