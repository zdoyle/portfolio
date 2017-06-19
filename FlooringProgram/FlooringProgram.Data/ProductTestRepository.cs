using FlooringProgram.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Models;

namespace FlooringProgram.Data
{
    public class ProductTestRepository : IProductRepository
    {
        List<Product> products = new List<Product>();

        private static Product _product1 = new Product()
        {
            ProductType = "Carpet",
            LaborCostPerSquareFoot = 4.00M,
            CostPerSquareFoot = 2.50M
        };

        public ProductTestRepository()
        {
            products.Add(_product1);
        }

        public List<Product> GetListOfProducts()
        {
            return products;
        }

        public Product GetSingleProduct(string productType)
        {
            foreach (var product in products)
            {
                if (productType == product.ProductType)
                {
                    return product;
                }
            }

            return null;
        }
    }
}
