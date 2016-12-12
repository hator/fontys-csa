using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WebshopContract
{
    [ServiceContract(Namespace = "server", CallbackContract = typeof(IShippingCallback))]
    public interface IShipping
    {
        [OperationContract(IsOneWay = true)]
        void ConnectShipping();

        [OperationContract]
        List<Order> GetOrderList();

        [OperationContract]
        bool ShipOrder(int OrderId);
    }

    public interface IShippingCallback
    {
        [OperationContract(IsOneWay = true)]
        void NewOrder(Order Order);
    }

    [DataContract]
    public class Order
    {
        static int NextOrderId = 1;

        [DataMember]
        public int OrderId { get; set; }

        [DataMember]
        public string ProductId { get; set; }

        [DataMember]
        public DateTime Moment { get; set; }

        public IWebshopCallback WebshopCallback { get; set; }

        public Order(int OrderId, string ProductId, DateTime Moment, IWebshopCallback WebshopCallback)
        {
            this.OrderId = OrderId;
            this.ProductId = ProductId;
            this.Moment = Moment;
            this.WebshopCallback = WebshopCallback;
        }

        public Order(string ProductId, IWebshopCallback WebshopCallback)
            : this(NextOrderId++
                  , ProductId
                  , DateTime.Now
                  , WebshopCallback
                  )
        {
        }
    }
}
