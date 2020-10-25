namespace eTransport.WinUI.Forms
{
    partial class frmAddVehicle
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
            this.pBVehicle = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtBoxYear = new System.Windows.Forms.DateTimePicker();
            this.txtBoxTrunk = new System.Windows.Forms.TextBox();
            this.lblTrunk = new System.Windows.Forms.Label();
            this.txtBoxSeat = new System.Windows.Forms.TextBox();
            this.lblSeat = new System.Windows.Forms.Label();
            this.lblYearProduction = new System.Windows.Forms.Label();
            this.txtBoxLicencePlate = new System.Windows.Forms.TextBox();
            this.lblLicencePlate = new System.Windows.Forms.Label();
            this.btnVehicleModel = new System.Windows.Forms.Button();
            this.cBVehicleModel = new System.Windows.Forms.ComboBox();
            this.lblVehicleModel = new System.Windows.Forms.Label();
            this.btnAddVehicleType = new System.Windows.Forms.Button();
            this.cBVehicleType = new System.Windows.Forms.ComboBox();
            this.lblVehicleType = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnVehicleDetails = new System.Windows.Forms.Button();
            this.btnSaveVehicle = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnRemove = new System.Windows.Forms.Button();
            this.richTxtDescription = new System.Windows.Forms.RichTextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.txtLength = new System.Windows.Forms.TextBox();
            this.txtWeight = new System.Windows.Forms.TextBox();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblPriceKM = new System.Windows.Forms.Label();
            this.lblWidth = new System.Windows.Forms.Label();
            this.lblLength = new System.Windows.Forms.Label();
            this.lblWeight = new System.Windows.Forms.Label();
            this.lblHeight = new System.Windows.Forms.Label();
            this.btn_save_top = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pBVehicle)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pBVehicle
            // 
            this.pBVehicle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pBVehicle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pBVehicle.Image = global::eTransport.WinUI.Properties.Resources.delivery;
            this.pBVehicle.Location = new System.Drawing.Point(222, 17);
            this.pBVehicle.Name = "pBVehicle";
            this.pBVehicle.Size = new System.Drawing.Size(145, 86);
            this.pBVehicle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBVehicle.TabIndex = 0;
            this.pBVehicle.TabStop = false;
            this.pBVehicle.Click += new System.EventHandler(this.pBVehicle_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.Controls.Add(this.txtBoxYear);
            this.panel1.Controls.Add(this.txtBoxTrunk);
            this.panel1.Controls.Add(this.lblTrunk);
            this.panel1.Controls.Add(this.txtBoxSeat);
            this.panel1.Controls.Add(this.lblSeat);
            this.panel1.Controls.Add(this.lblYearProduction);
            this.panel1.Controls.Add(this.txtBoxLicencePlate);
            this.panel1.Controls.Add(this.lblLicencePlate);
            this.panel1.Controls.Add(this.btnVehicleModel);
            this.panel1.Controls.Add(this.cBVehicleModel);
            this.panel1.Controls.Add(this.lblVehicleModel);
            this.panel1.Controls.Add(this.btnAddVehicleType);
            this.panel1.Controls.Add(this.cBVehicleType);
            this.panel1.Controls.Add(this.lblVehicleType);
            this.panel1.Location = new System.Drawing.Point(15, 109);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(578, 243);
            this.panel1.TabIndex = 1;
            // 
            // txtBoxYear
            // 
            this.txtBoxYear.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtBoxYear.Location = new System.Drawing.Point(175, 123);
            this.txtBoxYear.Name = "txtBoxYear";
            this.txtBoxYear.Size = new System.Drawing.Size(230, 20);
            this.txtBoxYear.TabIndex = 14;
            // 
            // txtBoxTrunk
            // 
            this.txtBoxTrunk.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtBoxTrunk.Location = new System.Drawing.Point(175, 198);
            this.txtBoxTrunk.Name = "txtBoxTrunk";
            this.txtBoxTrunk.Size = new System.Drawing.Size(230, 20);
            this.txtBoxTrunk.TabIndex = 13;
            // 
            // lblTrunk
            // 
            this.lblTrunk.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTrunk.AutoSize = true;
            this.lblTrunk.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrunk.Location = new System.Drawing.Point(26, 197);
            this.lblTrunk.Name = "lblTrunk";
            this.lblTrunk.Size = new System.Drawing.Size(93, 19);
            this.lblTrunk.TabIndex = 12;
            this.lblTrunk.Text = "Trunk volume";
            // 
            // txtBoxSeat
            // 
            this.txtBoxSeat.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtBoxSeat.Location = new System.Drawing.Point(175, 161);
            this.txtBoxSeat.Name = "txtBoxSeat";
            this.txtBoxSeat.Size = new System.Drawing.Size(230, 20);
            this.txtBoxSeat.TabIndex = 11;
            // 
            // lblSeat
            // 
            this.lblSeat.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblSeat.AutoSize = true;
            this.lblSeat.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeat.Location = new System.Drawing.Point(26, 160);
            this.lblSeat.Name = "lblSeat";
            this.lblSeat.Size = new System.Drawing.Size(110, 19);
            this.lblSeat.TabIndex = 10;
            this.lblSeat.Text = "Seating capacity";
            // 
            // lblYearProduction
            // 
            this.lblYearProduction.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblYearProduction.AutoSize = true;
            this.lblYearProduction.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYearProduction.Location = new System.Drawing.Point(26, 125);
            this.lblYearProduction.Name = "lblYearProduction";
            this.lblYearProduction.Size = new System.Drawing.Size(137, 19);
            this.lblYearProduction.TabIndex = 8;
            this.lblYearProduction.Text = "Year of Manufacture";
            // 
            // txtBoxLicencePlate
            // 
            this.txtBoxLicencePlate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtBoxLicencePlate.Location = new System.Drawing.Point(175, 94);
            this.txtBoxLicencePlate.Name = "txtBoxLicencePlate";
            this.txtBoxLicencePlate.Size = new System.Drawing.Size(230, 20);
            this.txtBoxLicencePlate.TabIndex = 7;
            // 
            // lblLicencePlate
            // 
            this.lblLicencePlate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblLicencePlate.AutoSize = true;
            this.lblLicencePlate.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLicencePlate.Location = new System.Drawing.Point(26, 95);
            this.lblLicencePlate.Name = "lblLicencePlate";
            this.lblLicencePlate.Size = new System.Drawing.Size(89, 19);
            this.lblLicencePlate.TabIndex = 6;
            this.lblLicencePlate.Text = "Licence plate";
            // 
            // btnVehicleModel
            // 
            this.btnVehicleModel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnVehicleModel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVehicleModel.Location = new System.Drawing.Point(439, 57);
            this.btnVehicleModel.Name = "btnVehicleModel";
            this.btnVehicleModel.Size = new System.Drawing.Size(112, 23);
            this.btnVehicleModel.TabIndex = 5;
            this.btnVehicleModel.Text = "Add vehicle model";
            this.btnVehicleModel.UseVisualStyleBackColor = true;
            this.btnVehicleModel.Click += new System.EventHandler(this.btnVehicleModel_Click);
            // 
            // cBVehicleModel
            // 
            this.cBVehicleModel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cBVehicleModel.FormattingEnabled = true;
            this.cBVehicleModel.Location = new System.Drawing.Point(175, 57);
            this.cBVehicleModel.Name = "cBVehicleModel";
            this.cBVehicleModel.Size = new System.Drawing.Size(230, 21);
            this.cBVehicleModel.TabIndex = 4;
            // 
            // lblVehicleModel
            // 
            this.lblVehicleModel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblVehicleModel.AutoSize = true;
            this.lblVehicleModel.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVehicleModel.Location = new System.Drawing.Point(26, 57);
            this.lblVehicleModel.Name = "lblVehicleModel";
            this.lblVehicleModel.Size = new System.Drawing.Size(95, 19);
            this.lblVehicleModel.TabIndex = 3;
            this.lblVehicleModel.Text = "Vehicle model";
            // 
            // btnAddVehicleType
            // 
            this.btnAddVehicleType.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAddVehicleType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddVehicleType.Location = new System.Drawing.Point(439, 18);
            this.btnAddVehicleType.Name = "btnAddVehicleType";
            this.btnAddVehicleType.Size = new System.Drawing.Size(112, 23);
            this.btnAddVehicleType.TabIndex = 2;
            this.btnAddVehicleType.Text = "Add vehicle type";
            this.btnAddVehicleType.UseVisualStyleBackColor = true;
            this.btnAddVehicleType.Click += new System.EventHandler(this.btnAddVehicleType_Click);
            // 
            // cBVehicleType
            // 
            this.cBVehicleType.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cBVehicleType.FormattingEnabled = true;
            this.cBVehicleType.Location = new System.Drawing.Point(175, 18);
            this.cBVehicleType.Name = "cBVehicleType";
            this.cBVehicleType.Size = new System.Drawing.Size(230, 21);
            this.cBVehicleType.TabIndex = 1;
            // 
            // lblVehicleType
            // 
            this.lblVehicleType.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblVehicleType.AutoSize = true;
            this.lblVehicleType.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVehicleType.Location = new System.Drawing.Point(26, 20);
            this.lblVehicleType.Name = "lblVehicleType";
            this.lblVehicleType.Size = new System.Drawing.Size(84, 19);
            this.lblVehicleType.TabIndex = 0;
            this.lblVehicleType.Text = "Vehicle type";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.pBVehicle);
            this.groupBox1.Location = new System.Drawing.Point(98, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(599, 367);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Vehicle";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnVehicleDetails);
            this.groupBox2.Location = new System.Drawing.Point(98, 385);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(599, 54);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Vehicle details";
            // 
            // btnVehicleDetails
            // 
            this.btnVehicleDetails.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnVehicleDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVehicleDetails.Location = new System.Drawing.Point(58, 19);
            this.btnVehicleDetails.Name = "btnVehicleDetails";
            this.btnVehicleDetails.Size = new System.Drawing.Size(489, 23);
            this.btnVehicleDetails.TabIndex = 0;
            this.btnVehicleDetails.Text = "Add vehicle details";
            this.btnVehicleDetails.UseVisualStyleBackColor = true;
            this.btnVehicleDetails.Click += new System.EventHandler(this.btnVehicleDetails_Click);
            // 
            // btnSaveVehicle
            // 
            this.btnSaveVehicle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSaveVehicle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveVehicle.Location = new System.Drawing.Point(156, 757);
            this.btnSaveVehicle.Name = "btnSaveVehicle";
            this.btnSaveVehicle.Size = new System.Drawing.Size(490, 23);
            this.btnSaveVehicle.TabIndex = 1;
            this.btnSaveVehicle.Text = "Save";
            this.btnSaveVehicle.UseVisualStyleBackColor = true;
            this.btnSaveVehicle.Visible = false;
            this.btnSaveVehicle.Click += new System.EventHandler(this.btnSaveVehicle_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnRemove);
            this.panel2.Controls.Add(this.richTxtDescription);
            this.panel2.Controls.Add(this.txtPrice);
            this.panel2.Controls.Add(this.txtWidth);
            this.panel2.Controls.Add(this.txtLength);
            this.panel2.Controls.Add(this.txtWeight);
            this.panel2.Controls.Add(this.txtHeight);
            this.panel2.Controls.Add(this.lblDescription);
            this.panel2.Controls.Add(this.lblPriceKM);
            this.panel2.Controls.Add(this.lblWidth);
            this.panel2.Controls.Add(this.lblLength);
            this.panel2.Controls.Add(this.lblWeight);
            this.panel2.Controls.Add(this.lblHeight);
            this.panel2.Location = new System.Drawing.Point(98, 445);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(599, 306);
            this.panel2.TabIndex = 4;
            this.panel2.Visible = false;
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRemove.Location = new System.Drawing.Point(473, 278);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 30;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // richTxtDescription
            // 
            this.richTxtDescription.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.richTxtDescription.Location = new System.Drawing.Point(147, 181);
            this.richTxtDescription.Name = "richTxtDescription";
            this.richTxtDescription.ReadOnly = true;
            this.richTxtDescription.Size = new System.Drawing.Size(401, 92);
            this.richTxtDescription.TabIndex = 29;
            this.richTxtDescription.Text = "";
            // 
            // txtPrice
            // 
            this.txtPrice.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPrice.Location = new System.Drawing.Point(147, 148);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.ReadOnly = true;
            this.txtPrice.Size = new System.Drawing.Size(399, 20);
            this.txtPrice.TabIndex = 28;
            // 
            // txtWidth
            // 
            this.txtWidth.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtWidth.Location = new System.Drawing.Point(147, 118);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.ReadOnly = true;
            this.txtWidth.Size = new System.Drawing.Size(399, 20);
            this.txtWidth.TabIndex = 27;
            // 
            // txtLength
            // 
            this.txtLength.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtLength.Location = new System.Drawing.Point(147, 86);
            this.txtLength.Name = "txtLength";
            this.txtLength.ReadOnly = true;
            this.txtLength.Size = new System.Drawing.Size(399, 20);
            this.txtLength.TabIndex = 26;
            // 
            // txtWeight
            // 
            this.txtWeight.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtWeight.Location = new System.Drawing.Point(147, 51);
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.ReadOnly = true;
            this.txtWeight.Size = new System.Drawing.Size(399, 20);
            this.txtWeight.TabIndex = 25;
            // 
            // txtHeight
            // 
            this.txtHeight.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtHeight.Location = new System.Drawing.Point(147, 20);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.ReadOnly = true;
            this.txtHeight.Size = new System.Drawing.Size(399, 20);
            this.txtHeight.TabIndex = 24;
            // 
            // lblDescription
            // 
            this.lblDescription.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(33, 181);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(108, 13);
            this.lblDescription.TabIndex = 23;
            this.lblDescription.Text = "Description (Optional)";
            // 
            // lblPriceKM
            // 
            this.lblPriceKM.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPriceKM.AutoSize = true;
            this.lblPriceKM.Location = new System.Drawing.Point(33, 151);
            this.lblPriceKM.Name = "lblPriceKM";
            this.lblPriceKM.Size = new System.Drawing.Size(66, 13);
            this.lblPriceKM.TabIndex = 22;
            this.lblPriceKM.Text = "Price per km";
            // 
            // lblWidth
            // 
            this.lblWidth.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblWidth.AutoSize = true;
            this.lblWidth.Location = new System.Drawing.Point(33, 121);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(55, 13);
            this.lblWidth.TabIndex = 21;
            this.lblWidth.Text = "Max width";
            // 
            // lblLength
            // 
            this.lblLength.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblLength.AutoSize = true;
            this.lblLength.Location = new System.Drawing.Point(35, 89);
            this.lblLength.Name = "lblLength";
            this.lblLength.Size = new System.Drawing.Size(59, 13);
            this.lblLength.TabIndex = 20;
            this.lblLength.Text = "Max length";
            // 
            // lblWeight
            // 
            this.lblWeight.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblWeight.AutoSize = true;
            this.lblWeight.Location = new System.Drawing.Point(33, 54);
            this.lblWeight.Name = "lblWeight";
            this.lblWeight.Size = new System.Drawing.Size(61, 13);
            this.lblWeight.TabIndex = 19;
            this.lblWeight.Text = "Max weight";
            // 
            // lblHeight
            // 
            this.lblHeight.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblHeight.AutoSize = true;
            this.lblHeight.Location = new System.Drawing.Point(33, 23);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(59, 13);
            this.lblHeight.TabIndex = 18;
            this.lblHeight.Text = "Max height";
            // 
            // btn_save_top
            // 
            this.btn_save_top.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_save_top.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_save_top.Location = new System.Drawing.Point(156, 445);
            this.btn_save_top.Name = "btn_save_top";
            this.btn_save_top.Size = new System.Drawing.Size(490, 23);
            this.btn_save_top.TabIndex = 5;
            this.btn_save_top.Text = "Save";
            this.btn_save_top.UseVisualStyleBackColor = true;
            this.btn_save_top.Click += new System.EventHandler(this.btn_save_top_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(41, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 19);
            this.label1.TabIndex = 15;
            this.label1.Text = "Picture (click to add) ->";
            // 
            // frmAddVehicle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(800, 792);
            this.Controls.Add(this.btn_save_top);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnSaveVehicle);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmAddVehicle";
            this.Text = "Add vehicle";
            this.Load += new System.EventHandler(this.frmAddVehicle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pBVehicle)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pBVehicle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnVehicleModel;
        private System.Windows.Forms.ComboBox cBVehicleModel;
        private System.Windows.Forms.Label lblVehicleModel;
        private System.Windows.Forms.Button btnAddVehicleType;
        private System.Windows.Forms.ComboBox cBVehicleType;
        private System.Windows.Forms.Label lblVehicleType;
        private System.Windows.Forms.Label lblYearProduction;
        private System.Windows.Forms.Label lblLicencePlate;
        private System.Windows.Forms.TextBox txtBoxTrunk;
        private System.Windows.Forms.Label lblTrunk;
        private System.Windows.Forms.TextBox txtBoxSeat;
        private System.Windows.Forms.Label lblSeat;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnVehicleDetails;
        private System.Windows.Forms.Button btnSaveVehicle;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblPriceKM;
        private System.Windows.Forms.Label lblWidth;
        private System.Windows.Forms.Label lblLength;
        private System.Windows.Forms.Label lblWeight;
        private System.Windows.Forms.Label lblHeight;
        private System.Windows.Forms.RichTextBox richTxtDescription;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.TextBox txtLength;
        private System.Windows.Forms.TextBox txtWeight;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.Button btn_save_top;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.DateTimePicker txtBoxYear;
        private System.Windows.Forms.TextBox txtBoxLicencePlate;
        private System.Windows.Forms.Label label1;
    }
}