namespace client
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.getWebshopNameBtn = new System.Windows.Forms.Button();
            this.getProductListBtn = new System.Windows.Forms.Button();
            this.productsDataGrid = new System.Windows.Forms.DataGridView();
            this.getProductInfoBtn = new System.Windows.Forms.Button();
            this.buyProductBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.productsDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // getWebshopNameBtn
            // 
            this.getWebshopNameBtn.Location = new System.Drawing.Point(12, 12);
            this.getWebshopNameBtn.Name = "getWebshopNameBtn";
            this.getWebshopNameBtn.Size = new System.Drawing.Size(111, 23);
            this.getWebshopNameBtn.TabIndex = 0;
            this.getWebshopNameBtn.Text = "Get webshop name";
            this.getWebshopNameBtn.UseVisualStyleBackColor = true;
            this.getWebshopNameBtn.Click += new System.EventHandler(this.getWebshopNameBtn_Click);
            // 
            // getProductListBtn
            // 
            this.getProductListBtn.Location = new System.Drawing.Point(12, 41);
            this.getProductListBtn.Name = "getProductListBtn";
            this.getProductListBtn.Size = new System.Drawing.Size(111, 23);
            this.getProductListBtn.TabIndex = 1;
            this.getProductListBtn.Text = "Get product list";
            this.getProductListBtn.UseMnemonic = false;
            this.getProductListBtn.UseVisualStyleBackColor = true;
            this.getProductListBtn.Click += new System.EventHandler(this.getProductListBtn_Click);
            // 
            // productsDataGrid
            // 
            this.productsDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.productsDataGrid.Location = new System.Drawing.Point(129, 12);
            this.productsDataGrid.Name = "productsDataGrid";
            this.productsDataGrid.Size = new System.Drawing.Size(463, 236);
            this.productsDataGrid.TabIndex = 2;
            // 
            // getProductInfoBtn
            // 
            this.getProductInfoBtn.AutoEllipsis = true;
            this.getProductInfoBtn.Location = new System.Drawing.Point(12, 70);
            this.getProductInfoBtn.Name = "getProductInfoBtn";
            this.getProductInfoBtn.Size = new System.Drawing.Size(111, 23);
            this.getProductInfoBtn.TabIndex = 3;
            this.getProductInfoBtn.Text = "Get product info";
            this.getProductInfoBtn.UseMnemonic = false;
            this.getProductInfoBtn.UseVisualStyleBackColor = true;
            this.getProductInfoBtn.Click += new System.EventHandler(this.getProductInfoBtn_Click);
            // 
            // buyProductBtn
            // 
            this.buyProductBtn.AutoEllipsis = true;
            this.buyProductBtn.Location = new System.Drawing.Point(12, 99);
            this.buyProductBtn.Name = "buyProductBtn";
            this.buyProductBtn.Size = new System.Drawing.Size(111, 23);
            this.buyProductBtn.TabIndex = 4;
            this.buyProductBtn.Text = "Buy product";
            this.buyProductBtn.UseMnemonic = false;
            this.buyProductBtn.UseVisualStyleBackColor = true;
            this.buyProductBtn.Click += new System.EventHandler(this.buyProductBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 262);
            this.Controls.Add(this.buyProductBtn);
            this.Controls.Add(this.getProductInfoBtn);
            this.Controls.Add(this.productsDataGrid);
            this.Controls.Add(this.getProductListBtn);
            this.Controls.Add(this.getWebshopNameBtn);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.productsDataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button getWebshopNameBtn;
        private System.Windows.Forms.Button getProductListBtn;
        private System.Windows.Forms.DataGridView productsDataGrid;
        private System.Windows.Forms.Button getProductInfoBtn;
        private System.Windows.Forms.Button buyProductBtn;
    }
}

