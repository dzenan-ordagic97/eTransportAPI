namespace eTransport.WinUI.Forms
{
    partial class frmAddVehicleDetails
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
            this.lblHeight = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblVehicleDetails = new System.Windows.Forms.Label();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.lblWeight = new System.Windows.Forms.Label();
            this.txtWeight = new System.Windows.Forms.TextBox();
            this.lblLength = new System.Windows.Forms.Label();
            this.txtLength = new System.Windows.Forms.TextBox();
            this.lblWidth = new System.Windows.Forms.Label();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.lblPriceKM = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.materialContextMenuStrip1 = new MaterialSkin.Controls.MaterialContextMenuStrip();
            this.richTxtDescription = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // lblHeight
            // 
            this.lblHeight.AutoSize = true;
            this.lblHeight.Location = new System.Drawing.Point(257, 83);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(59, 13);
            this.lblHeight.TabIndex = 7;
            this.lblHeight.Text = "Max height";
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnAdd.Location = new System.Drawing.Point(304, 478);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(175, 47);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblVehicleDetails
            // 
            this.lblVehicleDetails.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblVehicleDetails.AutoSize = true;
            this.lblVehicleDetails.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVehicleDetails.Location = new System.Drawing.Point(327, 24);
            this.lblVehicleDetails.Name = "lblVehicleDetails";
            this.lblVehicleDetails.Size = new System.Drawing.Size(152, 26);
            this.lblVehicleDetails.TabIndex = 5;
            this.lblVehicleDetails.Text = "Vehicle details";
            // 
            // txtHeight
            // 
            this.txtHeight.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHeight.Location = new System.Drawing.Point(260, 99);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(277, 20);
            this.txtHeight.TabIndex = 4;
            // 
            // lblWeight
            // 
            this.lblWeight.AutoSize = true;
            this.lblWeight.Location = new System.Drawing.Point(257, 136);
            this.lblWeight.Name = "lblWeight";
            this.lblWeight.Size = new System.Drawing.Size(61, 13);
            this.lblWeight.TabIndex = 9;
            this.lblWeight.Text = "Max weight";
            // 
            // txtWeight
            // 
            this.txtWeight.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWeight.Location = new System.Drawing.Point(260, 152);
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.Size = new System.Drawing.Size(277, 20);
            this.txtWeight.TabIndex = 5;
            // 
            // lblLength
            // 
            this.lblLength.AutoSize = true;
            this.lblLength.Location = new System.Drawing.Point(257, 190);
            this.lblLength.Name = "lblLength";
            this.lblLength.Size = new System.Drawing.Size(59, 13);
            this.lblLength.TabIndex = 11;
            this.lblLength.Text = "Max length";
            // 
            // txtLength
            // 
            this.txtLength.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLength.Location = new System.Drawing.Point(260, 206);
            this.txtLength.Name = "txtLength";
            this.txtLength.Size = new System.Drawing.Size(277, 20);
            this.txtLength.TabIndex = 6;
            // 
            // lblWidth
            // 
            this.lblWidth.AutoSize = true;
            this.lblWidth.Location = new System.Drawing.Point(257, 241);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(55, 13);
            this.lblWidth.TabIndex = 13;
            this.lblWidth.Text = "Max width";
            // 
            // txtWidth
            // 
            this.txtWidth.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWidth.Location = new System.Drawing.Point(260, 257);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(277, 20);
            this.txtWidth.TabIndex = 7;
            // 
            // lblPriceKM
            // 
            this.lblPriceKM.AutoSize = true;
            this.lblPriceKM.Location = new System.Drawing.Point(257, 291);
            this.lblPriceKM.Name = "lblPriceKM";
            this.lblPriceKM.Size = new System.Drawing.Size(66, 13);
            this.lblPriceKM.TabIndex = 15;
            this.lblPriceKM.Text = "Price per km";
            // 
            // txtPrice
            // 
            this.txtPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPrice.Location = new System.Drawing.Point(260, 307);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(277, 20);
            this.txtPrice.TabIndex = 8;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(257, 344);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(108, 13);
            this.lblDescription.TabIndex = 17;
            this.lblDescription.Text = "Description (Optional)";
            // 
            // materialContextMenuStrip1
            // 
            this.materialContextMenuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialContextMenuStrip1.Depth = 0;
            this.materialContextMenuStrip1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialContextMenuStrip1.Name = "materialContextMenuStrip1";
            this.materialContextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // richTxtDescription
            // 
            this.richTxtDescription.Location = new System.Drawing.Point(260, 360);
            this.richTxtDescription.Name = "richTxtDescription";
            this.richTxtDescription.Size = new System.Drawing.Size(277, 96);
            this.richTxtDescription.TabIndex = 9;
            this.richTxtDescription.Text = "";
            // 
            // frmAddVehicleDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 561);
            this.Controls.Add(this.richTxtDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblPriceKM);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.lblWidth);
            this.Controls.Add(this.txtWidth);
            this.Controls.Add(this.lblLength);
            this.Controls.Add(this.txtLength);
            this.Controls.Add(this.lblWeight);
            this.Controls.Add(this.txtWeight);
            this.Controls.Add(this.lblHeight);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblVehicleDetails);
            this.Controls.Add(this.txtHeight);
            this.Name = "frmAddVehicleDetails";
            this.Text = "frmAddVehicleDetails";
            this.Load += new System.EventHandler(this.frmAddVehicleDetails_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHeight;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblVehicleDetails;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.Label lblWeight;
        private System.Windows.Forms.TextBox txtWeight;
        private System.Windows.Forms.Label lblLength;
        private System.Windows.Forms.TextBox txtLength;
        private System.Windows.Forms.Label lblWidth;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.Label lblPriceKM;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label lblDescription;
        private MaterialSkin.Controls.MaterialContextMenuStrip materialContextMenuStrip1;
        private System.Windows.Forms.RichTextBox richTxtDescription;
    }
}