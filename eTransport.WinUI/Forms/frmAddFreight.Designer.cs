namespace eTransport.WinUI.Forms
{
    partial class frmAddFreight
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
            this.lblWidth = new System.Windows.Forms.Label();
            this.txtDistance = new System.Windows.Forms.TextBox();
            this.lblLength = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.lblWeight = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.cBVehicle = new System.Windows.Forms.ComboBox();
            this.lblVehicleType = new System.Windows.Forms.Label();
            this.txtTransportDate = new System.Windows.Forms.DateTimePicker();
            this.lblInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblWidth
            // 
            this.lblWidth.AutoSize = true;
            this.lblWidth.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWidth.Location = new System.Drawing.Point(352, 222);
            this.lblWidth.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(62, 19);
            this.lblWidth.TabIndex = 24;
            this.lblWidth.Text = "Distance";
            // 
            // txtDistance
            // 
            this.txtDistance.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDistance.Location = new System.Drawing.Point(356, 249);
            this.txtDistance.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDistance.Name = "txtDistance";
            this.txtDistance.Size = new System.Drawing.Size(368, 22);
            this.txtDistance.TabIndex = 19;
            // 
            // lblLength
            // 
            this.lblLength.AutoSize = true;
            this.lblLength.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLength.Location = new System.Drawing.Point(351, 159);
            this.lblLength.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLength.Name = "lblLength";
            this.lblLength.Size = new System.Drawing.Size(39, 19);
            this.lblLength.TabIndex = 23;
            this.lblLength.Text = "Price";
            // 
            // txtPrice
            // 
            this.txtPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPrice.Location = new System.Drawing.Point(356, 186);
            this.txtPrice.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(368, 22);
            this.txtPrice.TabIndex = 18;
            // 
            // lblWeight
            // 
            this.lblWeight.AutoSize = true;
            this.lblWeight.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWeight.Location = new System.Drawing.Point(351, 92);
            this.lblWeight.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWeight.Name = "lblWeight";
            this.lblWeight.Size = new System.Drawing.Size(99, 19);
            this.lblWeight.TabIndex = 22;
            this.lblWeight.Text = "Transport date";
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnAdd.Location = new System.Drawing.Point(425, 361);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(233, 58);
            this.btnAdd.TabIndex = 26;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // cBVehicle
            // 
            this.cBVehicle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cBVehicle.FormattingEnabled = true;
            this.cBVehicle.Location = new System.Drawing.Point(356, 308);
            this.cBVehicle.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cBVehicle.Name = "cBVehicle";
            this.cBVehicle.Size = new System.Drawing.Size(368, 24);
            this.cBVehicle.TabIndex = 28;
            // 
            // lblVehicleType
            // 
            this.lblVehicleType.AutoSize = true;
            this.lblVehicleType.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVehicleType.Location = new System.Drawing.Point(352, 281);
            this.lblVehicleType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVehicleType.Name = "lblVehicleType";
            this.lblVehicleType.Size = new System.Drawing.Size(101, 19);
            this.lblVehicleType.TabIndex = 27;
            this.lblVehicleType.Text = "Choose vehicle";
            // 
            // txtTransportDate
            // 
            this.txtTransportDate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTransportDate.Location = new System.Drawing.Point(356, 119);
            this.txtTransportDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTransportDate.Name = "txtTransportDate";
            this.txtTransportDate.Size = new System.Drawing.Size(368, 22);
            this.txtTransportDate.TabIndex = 29;
            // 
            // lblInfo
            // 
            this.lblInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.ForeColor = System.Drawing.Color.Teal;
            this.lblInfo.Location = new System.Drawing.Point(207, 25);
            this.lblInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(661, 20);
            this.lblInfo.TabIndex = 30;
            this.lblInfo.Text = "Info: Startup price and extra service price will be added automatically (if avail" +
    "able)";
            // 
            // frmAddFreight
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 519);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.txtTransportDate);
            this.Controls.Add(this.cBVehicle);
            this.Controls.Add(this.lblVehicleType);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblWidth);
            this.Controls.Add(this.txtDistance);
            this.Controls.Add(this.lblLength);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.lblWeight);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmAddFreight";
            this.Text = "Add freight";
            this.Load += new System.EventHandler(this.frmAddFreight_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblWidth;
        private System.Windows.Forms.TextBox txtDistance;
        private System.Windows.Forms.Label lblLength;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label lblWeight;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ComboBox cBVehicle;
        private System.Windows.Forms.Label lblVehicleType;
        private System.Windows.Forms.DateTimePicker txtTransportDate;
        private System.Windows.Forms.Label lblInfo;
    }
}