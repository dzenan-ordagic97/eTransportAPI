namespace eTransport.WinUI.Forms
{
    partial class frmAddCity
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
            this.label1 = new System.Windows.Forms.Label();
            this._flowLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtPostal = new System.Windows.Forms.TextBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.txtCityName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblExtraServices = new System.Windows.Forms.Label();
            this.cBCountry = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(239, 295);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 19);
            this.label1.TabIndex = 26;
            this.label1.Text = "Available cities";
            // 
            // _flowLayout
            // 
            this._flowLayout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._flowLayout.Location = new System.Drawing.Point(-4, 362);
            this._flowLayout.Margin = new System.Windows.Forms.Padding(133, 4, 4, 4);
            this._flowLayout.Name = "_flowLayout";
            this._flowLayout.Size = new System.Drawing.Size(725, 697);
            this._flowLayout.TabIndex = 25;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnAdd.Location = new System.Drawing.Point(194, 233);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(233, 58);
            this.btnAdd.TabIndex = 24;
            this.btnAdd.Text = "Save";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtPostal
            // 
            this.txtPostal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPostal.Location = new System.Drawing.Point(261, 185);
            this.txtPostal.Margin = new System.Windows.Forms.Padding(4);
            this.txtPostal.Name = "txtPostal";
            this.txtPostal.Size = new System.Drawing.Size(119, 22);
            this.txtPostal.TabIndex = 22;
            // 
            // lblPrice
            // 
            this.lblPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(257, 165);
            this.lblPrice.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(94, 16);
            this.lblPrice.TabIndex = 23;
            this.lblPrice.Text = "Postal number";
            // 
            // txtCityName
            // 
            this.txtCityName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCityName.Location = new System.Drawing.Point(261, 137);
            this.txtCityName.Margin = new System.Windows.Forms.Padding(4);
            this.txtCityName.Name = "txtCityName";
            this.txtCityName.Size = new System.Drawing.Size(119, 22);
            this.txtCityName.TabIndex = 21;
            // 
            // lblName
            // 
            this.lblName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(257, 117);
            this.lblName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(67, 16);
            this.lblName.TabIndex = 20;
            this.lblName.Text = "City name";
            // 
            // lblExtraServices
            // 
            this.lblExtraServices.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblExtraServices.AutoSize = true;
            this.lblExtraServices.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExtraServices.Location = new System.Drawing.Point(295, 9);
            this.lblExtraServices.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblExtraServices.Name = "lblExtraServices";
            this.lblExtraServices.Size = new System.Drawing.Size(50, 26);
            this.lblExtraServices.TabIndex = 19;
            this.lblExtraServices.Text = "City";
            // 
            // cBCountry
            // 
            this.cBCountry.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cBCountry.FormattingEnabled = true;
            this.cBCountry.Location = new System.Drawing.Point(261, 87);
            this.cBCountry.Margin = new System.Windows.Forms.Padding(4);
            this.cBCountry.Name = "cBCountry";
            this.cBCountry.Size = new System.Drawing.Size(119, 24);
            this.cBCountry.TabIndex = 27;
            this.cBCountry.SelectionChangeCommitted += new System.EventHandler(this.cBCountry_SelectionChangeCommitted);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(257, 68);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(289, 16);
            this.label2.TabIndex = 28;
            this.label2.Text = "Country name (Choose to show available cities)";
            // 
            // lblInfo
            // 
            this.lblInfo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.ForeColor = System.Drawing.Color.Teal;
            this.lblInfo.Location = new System.Drawing.Point(190, 326);
            this.lblInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(234, 20);
            this.lblInfo.TabIndex = 29;
            this.lblInfo.Text = "Info: Click the city to update";
            // 
            // frmAddCity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(732, 816);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cBCountry);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._flowLayout);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtPostal);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.txtCityName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblExtraServices);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmAddCity";
            this.Text = "Add city";
            this.Load += new System.EventHandler(this.frmAddCity_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel _flowLayout;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtPostal;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.TextBox txtCityName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblExtraServices;
        private System.Windows.Forms.ComboBox cBCountry;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblInfo;
    }
}