using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        }

        private void getWebshopNameBtn_Click(object sender, EventArgs e)
        {
            string name = webshop.GetWebshopName();

            ((Button)sender).Text = name;
        }
    }
}
