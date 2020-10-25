namespace eTransport.WinUI.Forms
{
    partial class frmVehicleAndDetails
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
            this.txtYear = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLicencePlate = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtVehicleType = new System.Windows.Forms.TextBox();
            this.lblBusinessMail = new System.Windows.Forms.Label();
            this.txtVehicleModel = new System.Windows.Forms.TextBox();
            this.lblCarrierName = new System.Windows.Forms.Label();
            this.txtSeating = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTrunk = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.richTxtDescription = new System.Windows.Forms.RichTextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtLength = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtWeight = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.dtmYear = new System.Windows.Forms.DateTimePicker();
            this.comboBoxModel = new System.Windows.Forms.ComboBox();
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.lblPictureUpdate = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pBVehicle)).BeginInit();
            this.SuspendLayout();
            // 
            // pBVehicle
            // 
            this.pBVehicle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pBVehicle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pBVehicle.Enabled = false;
            this.pBVehicle.Image = global::eTransport.WinUI.Properties.Resources.delivery;
            this.pBVehicle.Location = new System.Drawing.Point(293, 28);
            this.pBVehicle.Margin = new System.Windows.Forms.Padding(4);
            this.pBVehicle.Name = "pBVehicle";
            this.pBVehicle.Size = new System.Drawing.Size(193, 105);
            this.pBVehicle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBVehicle.TabIndex = 30;
            this.pBVehicle.TabStop = false;
            this.pBVehicle.Click += new System.EventHandler(this.pBVehicle_Click);
            // 
            // txtYear
            // 
            this.txtYear.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtYear.Location = new System.Drawing.Point(217, 315);
            this.txtYear.Margin = new System.Windows.Forms.Padding(4);
            this.txtYear.Name = "txtYear";
            this.txtYear.ReadOnly = true;
            this.txtYear.Size = new System.Drawing.Size(296, 22);
            this.txtYear.TabIndex = 28;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(213, 295);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 17);
            this.label2.TabIndex = 29;
            this.label2.Text = "Year of manufacture";
            // 
            // txtLicencePlate
            // 
            this.txtLicencePlate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLicencePlate.Location = new System.Drawing.Point(217, 267);
            this.txtLicencePlate.Margin = new System.Windows.Forms.Padding(4);
            this.txtLicencePlate.Name = "txtLicencePlate";
            this.txtLicencePlate.ReadOnly = true;
            this.txtLicencePlate.Size = new System.Drawing.Size(296, 22);
            this.txtLicencePlate.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(213, 247);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 17);
            this.label1.TabIndex = 27;
            this.label1.Text = "Licence plate";
            // 
            // txtVehicleType
            // 
            this.txtVehicleType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVehicleType.Location = new System.Drawing.Point(217, 219);
            this.txtVehicleType.Margin = new System.Windows.Forms.Padding(4);
            this.txtVehicleType.Name = "txtVehicleType";
            this.txtVehicleType.ReadOnly = true;
            this.txtVehicleType.Size = new System.Drawing.Size(296, 22);
            this.txtVehicleType.TabIndex = 24;
            // 
            // lblBusinessMail
            // 
            this.lblBusinessMail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBusinessMail.AutoSize = true;
            this.lblBusinessMail.Location = new System.Drawing.Point(213, 199);
            this.lblBusinessMail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBusinessMail.Name = "lblBusinessMail";
            this.lblBusinessMail.Size = new System.Drawing.Size(85, 17);
            this.lblBusinessMail.TabIndex = 25;
            this.lblBusinessMail.Text = "Vehicle type";
            // 
            // txtVehicleModel
            // 
            this.txtVehicleModel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVehicleModel.Location = new System.Drawing.Point(217, 171);
            this.txtVehicleModel.Margin = new System.Windows.Forms.Padding(4);
            this.txtVehicleModel.Name = "txtVehicleModel";
            this.txtVehicleModel.ReadOnly = true;
            this.txtVehicleModel.Size = new System.Drawing.Size(296, 22);
            this.txtVehicleModel.TabIndex = 22;
            // 
            // lblCarrierName
            // 
            this.lblCarrierName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCarrierName.AutoSize = true;
            this.lblCarrierName.Location = new System.Drawing.Point(213, 151);
            this.lblCarrierName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCarrierName.Name = "lblCarrierName";
            this.lblCarrierName.Size = new System.Drawing.Size(96, 17);
            this.lblCarrierName.TabIndex = 23;
            this.lblCarrierName.Text = "Vehicle model";
            // 
            // txtSeating
            // 
            this.txtSeating.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSeating.Location = new System.Drawing.Point(217, 363);
            this.txtSeating.Margin = new System.Windows.Forms.Padding(4);
            this.txtSeating.Name = "txtSeating";
            this.txtSeating.ReadOnly = true;
            this.txtSeating.Size = new System.Drawing.Size(296, 22);
            this.txtSeating.TabIndex = 32;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(213, 343);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 17);
            this.label3.TabIndex = 33;
            this.label3.Text = "Seating capacity";
            // 
            // txtTrunk
            // 
            this.txtTrunk.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTrunk.Location = new System.Drawing.Point(217, 411);
            this.txtTrunk.Margin = new System.Windows.Forms.Padding(4);
            this.txtTrunk.Name = "txtTrunk";
            this.txtTrunk.ReadOnly = true;
            this.txtTrunk.Size = new System.Drawing.Size(296, 22);
            this.txtTrunk.TabIndex = 34;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(213, 391);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 17);
            this.label4.TabIndex = 35;
            this.label4.Text = "Trunk volume";
            // 
            // richTxtDescription
            // 
            this.richTxtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTxtDescription.Location = new System.Drawing.Point(217, 761);
            this.richTxtDescription.Margin = new System.Windows.Forms.Padding(4);
            this.richTxtDescription.Name = "richTxtDescription";
            this.richTxtDescription.ReadOnly = true;
            this.richTxtDescription.Size = new System.Drawing.Size(299, 73);
            this.richTxtDescription.TabIndex = 51;
            this.richTxtDescription.Text = "";
            // 
            // lblDescription
            // 
            this.lblDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(213, 741);
            this.lblDescription.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(146, 17);
            this.lblDescription.TabIndex = 50;
            this.lblDescription.Text = "Description (Optional)";
            // 
            // txtPrice
            // 
            this.txtPrice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPrice.Location = new System.Drawing.Point(217, 713);
            this.txtPrice.Margin = new System.Windows.Forms.Padding(4);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.ReadOnly = true;
            this.txtPrice.Size = new System.Drawing.Size(299, 22);
            this.txtPrice.TabIndex = 46;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(213, 693);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(87, 17);
            this.label9.TabIndex = 47;
            this.label9.Text = "Price per km";
            // 
            // txtWidth
            // 
            this.txtWidth.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWidth.Location = new System.Drawing.Point(217, 665);
            this.txtWidth.Margin = new System.Windows.Forms.Padding(4);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.ReadOnly = true;
            this.txtWidth.Size = new System.Drawing.Size(299, 22);
            this.txtWidth.TabIndex = 44;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(213, 645);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 17);
            this.label8.TabIndex = 45;
            this.label8.Text = "Width";
            // 
            // txtLength
            // 
            this.txtLength.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLength.Location = new System.Drawing.Point(217, 617);
            this.txtLength.Margin = new System.Windows.Forms.Padding(4);
            this.txtLength.Name = "txtLength";
            this.txtLength.ReadOnly = true;
            this.txtLength.Size = new System.Drawing.Size(299, 22);
            this.txtLength.TabIndex = 42;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(213, 597);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 17);
            this.label7.TabIndex = 43;
            this.label7.Text = "Length";
            // 
            // txtWeight
            // 
            this.txtWeight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWeight.Location = new System.Drawing.Point(217, 569);
            this.txtWeight.Margin = new System.Windows.Forms.Padding(4);
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.ReadOnly = true;
            this.txtWeight.Size = new System.Drawing.Size(299, 22);
            this.txtWeight.TabIndex = 40;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(213, 549);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 17);
            this.label6.TabIndex = 41;
            this.label6.Text = "Weight";
            // 
            // txtHeight
            // 
            this.txtHeight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHeight.Location = new System.Drawing.Point(217, 521);
            this.txtHeight.Margin = new System.Windows.Forms.Padding(4);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.ReadOnly = true;
            this.txtHeight.Size = new System.Drawing.Size(299, 22);
            this.txtHeight.TabIndex = 38;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(213, 501);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 17);
            this.label5.TabIndex = 39;
            this.label5.Text = "Height";
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(350, 856);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(233, 58);
            this.btnDelete.TabIndex = 38;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnEdit.Location = new System.Drawing.Point(97, 856);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(4);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(233, 58);
            this.btnEdit.TabIndex = 39;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSave.Location = new System.Drawing.Point(97, 856);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(233, 58);
            this.btnSave.TabIndex = 40;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Visible = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dtmYear
            // 
            this.dtmYear.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtmYear.Location = new System.Drawing.Point(217, 315);
            this.dtmYear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtmYear.Name = "dtmYear";
            this.dtmYear.Size = new System.Drawing.Size(296, 22);
            this.dtmYear.TabIndex = 41;
            this.dtmYear.Visible = false;
            // 
            // comboBoxModel
            // 
            this.comboBoxModel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxModel.FormattingEnabled = true;
            this.comboBoxModel.Location = new System.Drawing.Point(216, 172);
            this.comboBoxModel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxModel.Name = "comboBoxModel";
            this.comboBoxModel.Size = new System.Drawing.Size(297, 24);
            this.comboBoxModel.TabIndex = 43;
            this.comboBoxModel.Visible = false;
            // 
            // comboBoxType
            // 
            this.comboBoxType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Location = new System.Drawing.Point(216, 220);
            this.comboBoxType.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(297, 24);
            this.comboBoxType.TabIndex = 44;
            this.comboBoxType.Visible = false;
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(306, 460);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(138, 25);
            this.label11.TabIndex = 53;
            this.label11.Text = "Vehicle details";
            // 
            // lblPictureUpdate
            // 
            this.lblPictureUpdate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblPictureUpdate.AutoSize = true;
            this.lblPictureUpdate.Font = new System.Drawing.Font("Microsoft YaHei", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPictureUpdate.Location = new System.Drawing.Point(289, 4);
            this.lblPictureUpdate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPictureUpdate.Name = "lblPictureUpdate";
            this.lblPictureUpdate.Size = new System.Drawing.Size(174, 20);
            this.lblPictureUpdate.TabIndex = 54;
            this.lblPictureUpdate.Text = "Picture (click to update) ";
            this.lblPictureUpdate.Visible = false;
            // 
            // frmVehicleAndDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(801, 1031);
            this.Controls.Add(this.lblPictureUpdate);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.richTxtDescription);
            this.Controls.Add(this.comboBoxType);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.comboBoxModel);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.dtmYear);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtWidth);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.txtLength);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtTrunk);
            this.Controls.Add(this.txtWeight);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtSeating);
            this.Controls.Add(this.txtHeight);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pBVehicle);
            this.Controls.Add(this.txtYear);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtLicencePlate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtVehicleType);
            this.Controls.Add(this.lblBusinessMail);
            this.Controls.Add(this.txtVehicleModel);
            this.Controls.Add(this.lblCarrierName);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmVehicleAndDetails";
            this.Text = "Vehicle with details";
            this.Load += new System.EventHandler(this.frmVehicleAndDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pBVehicle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pBVehicle;
        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLicencePlate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtVehicleType;
        private System.Windows.Forms.Label lblBusinessMail;
        private System.Windows.Forms.TextBox txtVehicleModel;
        private System.Windows.Forms.Label lblCarrierName;
        private System.Windows.Forms.TextBox txtSeating;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTrunk;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtLength;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtWeight;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox richTxtDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DateTimePicker dtmYear;
        private System.Windows.Forms.ComboBox comboBoxModel;
        private System.Windows.Forms.ComboBox comboBoxType;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblPictureUpdate;
    }
}