using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PartyScoreAPI.Models;

namespace PartyScoreAPI.Repository
{
    public class ProductsRepository
    {
        static List<Product> products = new List<Product>()
        {
            new Product { Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1 },
            new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M },
            new Product { Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M }
        };

        const string QRCODE="ZZBZTDR";
        const string WIFI_MAC = "bc:54:fc:11:51:26";
        public List<Product> Products { get => products; set => products = value; }

        public bool AddProduct(Product value)
        {
            if (value != null)
            {
                products.Add(value);
                return true;
            }
            else
            {
                return false;
            }
        }

        public Product FindProductById(int id)
        {
            var product = products.FirstOrDefault((p) => p.Id == id);
            return product;

        }

        public bool CheckIn(string code, string wifiMac)
        {
            bool result = false;
            if (code.Equals(QRCODE) || wifiMac.Equals(WIFI_MAC))
            {
                result = true;
            }
            return result;
        }

    }
}