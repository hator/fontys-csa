using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WebshopContract
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract(Namespace="WebshopContract", CallbackContract = typeof(IWebshopCallback))]
    public interface IWebshop
    {
        [OperationContract(IsOneWay = true)]
        void Connect();

        [OperationContract]
        string GetWebshopName();

        [OperationContract]
        List<Item> GetProductList();

        [OperationContract]
        string GetProductInfo(string ProductId);

        [OperationContract]
        bool BuyProduct(string ProductId);
    }

    public interface IWebshopCallback
    {
        [OperationContract]
        void NewClientConnected(int NumberOfConnectedClients);

        [OperationContract(IsOneWay = true)]
        void ProductSold(Item Product);
    }

    [DataContract]
    public class Item
    {
        public Item(string ProductId, string ProductInfo, double Price, int Stock, bool OnSale)
        {
            this.ProductId = ProductId;
            this.ProductInfo = ProductInfo;
            this.Price = Price;
            this.Stock = Stock;
            this.OnSale = OnSale;
        }

        public string ProductInfo { get; set; }
        public bool OnSale { get; set; }

        // contract members
        [DataMember]
        public string ProductId { get; set; }

        [DataMember]
        public double Price { get; set; }

        [DataMember]
        public int Stock { get; set; }
    }
}
