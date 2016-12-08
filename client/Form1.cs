using client.WebshopReference;
using System;
using System.Windows.Forms;

namespace client
{
    public partial class Form1 : Form
    {
        private WebshopReference.WebshopClient webshop;

        public Form1()
        {
            InitializeComponent();
            webshop = new WebshopReference.WebshopClient();

            InitializeProductDataGrid();
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
            string productId = GetSelectedProductId();
            if(productId != null)
            {
                string productInfo = webshop.GetProductInfo(productId);
                MessageBox.Show(productInfo, "Product Info: " + productId);
            }
        }

        private void buyProductBtn_Click(object sender, EventArgs e)
        {
            string productId = GetSelectedProductId();
            if (webshop.BuyProduct(productId))
            {
                MessageBox.Show(productId + " bought successfuly!");
            }
            else
            {
                MessageBox.Show("Error buying " + productId, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            RefreshProductList();
        }

        private string GetSelectedProductId()
        {
            if (productsDataGrid.SelectedRows.Count == 1)
            {
                Item selectedItem = (Item)productsDataGrid.SelectedRows[0].DataBoundItem;
                return selectedItem.ProductId;
            }
            return null;
        }

        private void RefreshProductList()
        {
            Item[] items = webshop.GetProductList();
            productsDataGrid.DataSource = items;

            ReorderColumns();
        }
    }
}
