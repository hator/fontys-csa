using shipping_client.WebshopReference;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace shipping_client
{
    public partial class Form1 : Form, IShippingCallback
    {
        private ShippingClient shippingClient;
        private List<Order> orders = new List<Order>();

        public Form1()
        {
            InitializeComponent();
            InstanceContext context = new InstanceContext(this);
            shippingClient = new ShippingClient(context);

            shippingClient.ConnectShipping();

            InitializeOrdersDataGrid();
        }

        private IBindingList getOrdersBinding()
        {
            BindingList<Order> ordersBinding = new BindingList<Order>(orders);
            ordersBinding.AllowRemove = true;
            return ordersBinding;
        }

        private void InitializeOrdersDataGrid()
        {            
            ordersDataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            LoadOrders();
        }

        private void LoadOrders()
        {
            orders = shippingClient.GetOrderList().ToList();
            ordersDataGrid.DataSource = getOrdersBinding();
            ReorderColumns();
        }

        private void ReorderColumns()
        {
            ordersDataGrid.Columns["OrderId"].DisplayIndex = 0;
            ordersDataGrid.Columns["ProductId"].DisplayIndex = 1;
            ordersDataGrid.Columns["Moment"].DisplayIndex = 2;
        }

        private void shipBtn_Click(object sender, EventArgs e)
        {
            Order order = GetSelectedOrder();
            if(order != null)
            {
                bool result = shippingClient.ShipOrder(order.OrderId);
                if(result)
                {
                    orders.Remove(order);
                    ordersDataGrid.DataSource = getOrdersBinding();
                    ordersDataGrid.Invalidate();
                }
                else
                {
                    MessageBox.Show( "Error shipping " + order.OrderId
                                   , "Error"
                                   , MessageBoxButtons.OK
                                   , MessageBoxIcon.Error
                                   );
                }
            }
        }

        private Order GetSelectedOrder()
        {
            if (ordersDataGrid.SelectedRows.Count == 1)
            {
                Order selectedOrder = (Order)ordersDataGrid.SelectedRows[0].DataBoundItem;
                return selectedOrder;
            }
            return null;
        }
        
        public void NewOrder(Order Order)
        {
            orders.Add(Order);
            ordersDataGrid.DataSource = getOrdersBinding();
            ordersDataGrid.Invalidate();
        }
    }
}
