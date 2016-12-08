using client.WebshopReference;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Windows.Forms;

namespace client
{
    public partial class Form1 : Form, IWebshopCallback
    {
        private WebshopReference.WebshopClient webshop;

        public Form1()
        {
            InitializeComponent();
            InstanceContext instanceContext = new InstanceContext(this);
            webshop = new WebshopClient(instanceContext);

            InitializeProductDataGrid();

            webshop.Connect();
        }

        private void InitializeProductDataGrid()
        {
            productsDataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void getWebshopNameBtn_Click(object sender, EventArgs e)
        {
            string name = webshop.GetWebshopName();

            ((Button)sender).Text = name;
        }

        private void getProductListBtn_Click(object sender, EventArgs e)
        {
            RefreshProductList();
        }


        private void ReorderColumns()
        {
            productsDataGrid.Columns["ProductId"].DisplayIndex = 0;
            productsDataGrid.Columns["Price"].DisplayIndex = 1;
            productsDataGrid.Columns["Stock"].DisplayIndex = 2;
            productsDataGrid.Columns["ProductId"].HeaderText = "Product ID";
        }

        private void getProductInfoBtn_Click(object sender, EventArgs e)
        {
            Item product = GetSelectedProduct();
            if (product != null)
            {
                string productId = product.ProductId;
                string productInfo = webshop.GetProductInfo(productId);
                MessageBox.Show(productInfo, "Product Info: " + productId);
            }
        }

        private void buyProductBtn_Click(object sender, EventArgs e)
        {
            Item product = GetSelectedProduct();
            if (product != null)
            {
                string productId = product.ProductId;
                if (webshop.BuyProduct(productId))
                {
                    MessageBox.Show(productId + " bought successfuly!");
                    product.Stock--;
                    productsDataGrid.Invalidate();
                }
                else
                {
                    MessageBox.Show( "Error buying " + productId
                                   , "Error"
                                   , MessageBoxButtons.OK
                                   , MessageBoxIcon.Error
                                   );
                }
            }
        }

        private Item GetSelectedProduct()
        {
            if (productsDataGrid.SelectedRows.Count == 1)
            {
                Item selectedItem = (Item)productsDataGrid.SelectedRows[0].DataBoundItem;
                return selectedItem;
            }
            return null;
        }

        public void NewClientConnected(int NumberOfConnectedClients)
        {
            Text = "Connected clients: " + NumberOfConnectedClients;
        }

        public void ProductSold(Item Product)
        {
            if (productsDataGrid.DataSource != null)
            {
                Item[] items = (Item[])productsDataGrid.DataSource;
                List<Item> itemList = new List<Item>(items);
                Item myItem = itemList.Find(i => i.ProductId == Product.ProductId);
                if(myItem != null)
                {
                    myItem.Stock--;
                    productsDataGrid.Invalidate();
                }
                else
                {
                    RefreshProductList();
                }
            }
        }

        private void RefreshProductList()
        {
            Item[] items = webshop.GetProductList();
            productsDataGrid.DataSource = items;

            ReorderColumns();
        }
    }
}
