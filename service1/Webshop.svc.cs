using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WebshopContract;

namespace service
{


    public class Webshop : IWebshop
    {
        private List<Item> Products;

        public Webshop()
        {
            this.Products = new List<Item>();
            Products.Add(new Item("Toy", "Just a toy", 10.5, 5, false));
            Products.Add(new Item("Bike", "Bike with two wheels", 100, 10, false));
        }

        public bool BuyProduct(string ProductId)
        {
            Item product = Products.Find(p => p.ProductId == ProductId);
            if(product == null)
            {
                return false;
            }
            if(product.Stock > 1)
            {
                product.Stock--;
                return true;
            }
            return false;
        }

        public string GetProductInfo(string ProductId)
        {
            Item product = Products.Find(p => p.ProductId == ProductId);
            if (product == null)
            {
                return null;
            } else
            {
                return product.ProductInfo;
            }
        }

        public List<Item> GetProductList()
        {
            return this.Products;
        }

        public string GetWebshopName()
        {
            return "A webshop";
        }
    }
}
