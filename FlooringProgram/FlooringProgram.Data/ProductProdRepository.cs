using FlooringProgram.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Models;
using System.IO;

namespace FlooringProgram.Data
{
    public class ProductProdRepository : IProductRepository
    {
        private string _filePath;

        public ProductProdRepository(string baseFilePath)
        {
            _filePath = baseFilePath + "Products.txt";
        }

        public List<Product> GetListOfProducts()
        {
            List<Product> products = CreateProductListFriomFile();

            return products;
        }

        public Product GetSingleProduct(string productType)
        {
            List<Product> products = CreateProductListFriomFile();

            foreach (var product in products)
            {
                if (productType == product.ProductType)
                {
                    return product;
                }
            }

            return null;
        }

        private List<Product> CreateProductListFriomFile()
        {
            List<Product> products = new List<Product>();

            if (File.Exists(_filePath))
            {
                using (StreamReader sr = new StreamReader(_filePath))
                {
                    sr.ReadLine();
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        Product singleProduct = new Product();

                        string[] columns = line.Split(',');

                        singleProduct.ProductType = columns[0];
                        singleProduct.CostPerSquareFoot = decimal.Parse(columns[1]);
                        singleProduct.LaborCostPerSquareFoot = decimal.Parse(columns[2]);

                        products.Add(singleProduct);
                    }
                }

                return products;
            }

            return null;
        }
    }
}
