namespace eTransport.WinUI.Forms
{
    partial class frmAddCountry
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
            this.txtAcronym = new System.Windows.Forms.TextBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.txtCountryName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblExtraServices = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(272, 308);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 19);
            this.label1.TabIndex = 18;
            this.label1.Text = "Available countries";
            // 
            // _flowLayout
            // 
            this._flowLayout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._flowLayout.Location = new System.Drawing.Point(2, 359);
            this._flowLayout.Margin = new System.Windows.Forms.Padding(133, 4, 4, 4);
            this._flowLayout.Name = "_flowLayout";
            this._flowLayout.Size = new System.Drawing.Size(808, 762);
            this._flowLayout.TabIndex = 17;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnAdd.Location = new System.Drawing.Point(239, 246);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(233, 58);
            this.btnAdd.TabIndex = 16;
            this.btnAdd.Text = "Save";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtAcronym
            // 
            this.txtAcronym.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAcronym.Location = new System.Drawing.Point(253, 170);
            this.txtAcronym.Margin = new System.Windows.Forms.Padding(4);
            this.txtAcronym.Name = "txtAcronym";
            this.txtAcronym.Size = new System.Drawing.Size(218, 22);
            this.txtAcronym.TabIndex = 14;
            // 
            // lblPrice
            // 
            this.lblPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(249, 150);
            this.lblPrice.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(61, 16);
            this.lblPrice.TabIndex = 15;
            this.lblPrice.Text = "Acronym";
            // 
            // txtCountryName
            // 
            this.txtCountryName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCountryName.Location = new System.Drawing.Point(253, 122);
            this.txtCountryName.Margin = new System.Windows.Forms.Padding(4);
            this.txtCountryName.Name = "txtCountryName";
            this.txtCountryName.Size = new System.Drawing.Size(218, 22);
            this.txtCountryName.TabIndex = 13;
            // 
            // lblName
            // 
            this.lblName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(249, 102);
            this.lblName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(90, 16);
            this.lblName.TabIndex = 12;
            this.lblName.Text = "Country name";
            // 
            // lblExtraServices
            // 
            this.lblExtraServices.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblExtraServices.AutoSize = true;
            this.lblExtraServices.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExtraServices.Location = new System.Drawing.Point(326, 27);
            this.lblExtraServices.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblExtraServices.Name = "lblExtraServices";
            this.lblExtraServices.Size = new System.Drawing.Size(88, 26);
            this.lblExtraServices.TabIndex = 11;
            this.lblExtraServices.Text = "Country";
            // 
            // lblInfo
            // 
            this.lblInfo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.ForeColor = System.Drawing.Color.Teal;
            this.lblInfo.Location = new System.Drawing.Point(224, 335);
            this.lblInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(266, 20);
            this.lblInfo.TabIndex = 19;
            this.lblInfo.Text = "Info: Click the country to update";
            // 
            // frmAddCountry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(801, 859);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._flowLayout);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtAcronym);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.txtCountryName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblExtraServices);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmAddCountry";
            this.Text = "Add country";
            this.Load += new System.EventHandler(this.frmAddCountry_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel _flowLayout;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtAcronym;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.TextBox txtCountryName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblExtraServices;
        private System.Windows.Forms.Label lblInfo;
    }
}