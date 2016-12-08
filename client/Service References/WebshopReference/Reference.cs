﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace client.WebshopReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Item", Namespace="http://schemas.datacontract.org/2004/07/WebshopContract")]
    [System.SerializableAttribute()]
    public partial class Item : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double PriceField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ProductIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int StockField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double Price {
            get {
                return this.PriceField;
            }
            set {
                if ((this.PriceField.Equals(value) != true)) {
                    this.PriceField = value;
                    this.RaisePropertyChanged("Price");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ProductId {
            get {
                return this.ProductIdField;
            }
            set {
                if ((object.ReferenceEquals(this.ProductIdField, value) != true)) {
                    this.ProductIdField = value;
                    this.RaisePropertyChanged("ProductId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Stock {
            get {
                return this.StockField;
            }
            set {
                if ((this.StockField.Equals(value) != true)) {
                    this.StockField = value;
                    this.RaisePropertyChanged("Stock");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="WebshopContract", ConfigurationName="WebshopReference.IWebshop", CallbackContract=typeof(client.WebshopReference.IWebshopCallback))]
    public interface IWebshop {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="WebshopContract/IWebshop/Connect")]
        void Connect();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="WebshopContract/IWebshop/Connect")]
        System.Threading.Tasks.Task ConnectAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="WebshopContract/IWebshop/GetWebshopName", ReplyAction="WebshopContract/IWebshop/GetWebshopNameResponse")]
        string GetWebshopName();
        
        [System.ServiceModel.OperationContractAttribute(Action="WebshopContract/IWebshop/GetWebshopName", ReplyAction="WebshopContract/IWebshop/GetWebshopNameResponse")]
        System.Threading.Tasks.Task<string> GetWebshopNameAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="WebshopContract/IWebshop/GetProductList", ReplyAction="WebshopContract/IWebshop/GetProductListResponse")]
        client.WebshopReference.Item[] GetProductList();
        
        [System.ServiceModel.OperationContractAttribute(Action="WebshopContract/IWebshop/GetProductList", ReplyAction="WebshopContract/IWebshop/GetProductListResponse")]
        System.Threading.Tasks.Task<client.WebshopReference.Item[]> GetProductListAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="WebshopContract/IWebshop/GetProductInfo", ReplyAction="WebshopContract/IWebshop/GetProductInfoResponse")]
        string GetProductInfo(string ProductId);
        
        [System.ServiceModel.OperationContractAttribute(Action="WebshopContract/IWebshop/GetProductInfo", ReplyAction="WebshopContract/IWebshop/GetProductInfoResponse")]
        System.Threading.Tasks.Task<string> GetProductInfoAsync(string ProductId);
        
        [System.ServiceModel.OperationContractAttribute(Action="WebshopContract/IWebshop/BuyProduct", ReplyAction="WebshopContract/IWebshop/BuyProductResponse")]
        bool BuyProduct(string ProductId);
        
        [System.ServiceModel.OperationContractAttribute(Action="WebshopContract/IWebshop/BuyProduct", ReplyAction="WebshopContract/IWebshop/BuyProductResponse")]
        System.Threading.Tasks.Task<bool> BuyProductAsync(string ProductId);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IWebshopCallback {
        
        [System.ServiceModel.OperationContractAttribute(Action="WebshopContract/IWebshop/NewClientConnected", ReplyAction="WebshopContract/IWebshop/NewClientConnectedResponse")]
        void NewClientConnected(int NumberOfConnectedClients);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="WebshopContract/IWebshop/ProductSold")]
        void ProductSold(client.WebshopReference.Item Product);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IWebshopChannel : client.WebshopReference.IWebshop, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WebshopClient : System.ServiceModel.DuplexClientBase<client.WebshopReference.IWebshop>, client.WebshopReference.IWebshop {
        
        public WebshopClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public WebshopClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public WebshopClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public WebshopClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public WebshopClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public void Connect() {
            base.Channel.Connect();
        }
        
        public System.Threading.Tasks.Task ConnectAsync() {
            return base.Channel.ConnectAsync();
        }
        
        public string GetWebshopName() {
            return base.Channel.GetWebshopName();
        }
        
        public System.Threading.Tasks.Task<string> GetWebshopNameAsync() {
            return base.Channel.GetWebshopNameAsync();
        }
        
        public client.WebshopReference.Item[] GetProductList() {
            return base.Channel.GetProductList();
        }
        
        public System.Threading.Tasks.Task<client.WebshopReference.Item[]> GetProductListAsync() {
            return base.Channel.GetProductListAsync();
        }
        
        public string GetProductInfo(string ProductId) {
            return base.Channel.GetProductInfo(ProductId);
        }
        
        public System.Threading.Tasks.Task<string> GetProductInfoAsync(string ProductId) {
            return base.Channel.GetProductInfoAsync(ProductId);
        }
        
        public bool BuyProduct(string ProductId) {
            return base.Channel.BuyProduct(ProductId);
        }
        
        public System.Threading.Tasks.Task<bool> BuyProductAsync(string ProductId) {
            return base.Channel.BuyProductAsync(ProductId);
        }
    }
}
