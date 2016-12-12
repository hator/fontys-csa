using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WebshopContract;

namespace service
{

    [ServiceBehavior( InstanceContextMode = InstanceContextMode.Single
                    , ConcurrencyMode = ConcurrencyMode.Reentrant
                    )
    ]
    public class Webshop : IWebshop, IShipping
    {
        private List<Item> Products;
        private List<IWebshopCallback> ClientCallbacks = new List<IWebshopCallback>();
        private List<IShippingCallback> ShippingCallbacks = new List<IShippingCallback>();
        private List<Order> Orders = new List<Order>();

        public Webshop()
        {
            this.Products = new List<Item>();
            Products.Add(new Item("Toy", "Just a toy", 10.5, 5, false));
            Products.Add(new Item("Bike", "Bike with two wheels", 100, 10, false));
        }

        public void Connect()
        {
            IWebshopCallback clientCallback = OperationContext.Current.GetCallbackChannel<IWebshopCallback>();
            ClientCallbacks.Add(clientCallback);
            int currentClientCount = ClientCallbacks.Count();
            foreach(IWebshopCallback cc in ClientCallbacks)
            {
                cc.NewClientConnected(currentClientCount);
            }
            
        }

        public bool BuyProduct(string ProductId)
        {
            IWebshopCallback currentClient = OperationContext.Current.GetCallbackChannel<IWebshopCallback>();
            Item product = Products.Find(p => p.ProductId == ProductId);
            if(product != null && product.Stock >= 1)
            {
                product.Stock--;
                Order order = new Order(product.ProductId, currentClient);
                Orders.Add(order);

                foreach(IShippingCallback sc in ShippingCallbacks)
                {
                    sc.NewOrder(order);
                }

                foreach(IWebshopCallback cc in ClientCallbacks)
                {
                    // Notify all _other_ clients
                    if (cc != currentClient)
                    {
                        cc.ProductSold(product);
                    }
                }
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
            }
            else
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

        public List<Order> GetOrderList()
        {
            return Orders;
        }

        public bool ShipOrder(int OrderId)
        {
            Order order = Orders.Find(o => o.OrderId == OrderId);

            if (order != null)
            {
                Orders.Remove(order);
                order.WebshopCallback.OrderShipped(order);
                return true;
            }
            return false;
        }

        public void ConnectShipping()
        {
            IShippingCallback shippingCallback = OperationContext.Current.GetCallbackChannel<IShippingCallback>();
            ShippingCallbacks.Add(shippingCallback);
        }
    }
}
