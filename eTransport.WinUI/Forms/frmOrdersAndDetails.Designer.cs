namespace eTransport.WinUI.Forms
{
    partial class frmOrdersAndDetails
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
            this.label3 = new System.Windows.Forms.Label();
            this.pBOrders = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblBusinessMail = new System.Windows.Forms.Label();
            this.txtStartLocation = new System.Windows.Forms.TextBox();
            this.lblCarrierName = new System.Windows.Forms.Label();
            this.panelDetails = new System.Windows.Forms.Panel();
            this.richTxtDescription = new System.Windows.Forms.RichTextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtWeight = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCargoName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtClient = new System.Windows.Forms.TextBox();
            this.txtEndDate = new System.Windows.Forms.TextBox();
            this.txtStartDate = new System.Windows.Forms.TextBox();
            this.txtEndLocation = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnDecline = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtExtraService = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pBOrders)).BeginInit();
            this.panelDetails.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(155, 179);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 46;
            this.label3.Text = "Client";
            // 
            // pBOrders
            // 
            this.pBOrders.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pBOrders.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pBOrders.Enabled = false;
            this.pBOrders.Image = global::eTransport.WinUI.Properties.Resources.delivery;
            this.pBOrders.Location = new System.Drawing.Point(256, 19);
            this.pBOrders.Name = "pBOrders";
            this.pBOrders.Size = new System.Drawing.Size(145, 86);
            this.pBOrders.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBOrders.TabIndex = 44;
            this.pBOrders.TabStop = false;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(155, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 43;
            this.label2.Text = "End date transport";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(155, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 41;
            this.label1.Text = "Start date transport";
            // 
            // lblBusinessMail
            // 
            this.lblBusinessMail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBusinessMail.AutoSize = true;
            this.lblBusinessMail.Location = new System.Drawing.Point(155, 64);
            this.lblBusinessMail.Name = "lblBusinessMail";
            this.lblBusinessMail.Size = new System.Drawing.Size(66, 13);
            this.lblBusinessMail.TabIndex = 39;
            this.lblBusinessMail.Text = "End location";
            // 
            // txtStartLocation
            // 
            this.txtStartLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStartLocation.Location = new System.Drawing.Point(158, 41);
            this.txtStartLocation.Name = "txtStartLocation";
            this.txtStartLocation.ReadOnly = true;
            this.txtStartLocation.Size = new System.Drawing.Size(363, 20);
            this.txtStartLocation.TabIndex = 36;
            // 
            // lblCarrierName
            // 
            this.lblCarrierName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCarrierName.AutoSize = true;
            this.lblCarrierName.Location = new System.Drawing.Point(155, 25);
            this.lblCarrierName.Name = "lblCarrierName";
            this.lblCarrierName.Size = new System.Drawing.Size(69, 13);
            this.lblCarrierName.TabIndex = 37;
            this.lblCarrierName.Text = "Start location";
            // 
            // panelDetails
            // 
            this.panelDetails.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panelDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDetails.Controls.Add(this.richTxtDescription);
            this.panelDetails.Controls.Add(this.lblDescription);
            this.panelDetails.Controls.Add(this.txtWidth);
            this.panelDetails.Controls.Add(this.label8);
            this.panelDetails.Controls.Add(this.txtHeight);
            this.panelDetails.Controls.Add(this.pBOrders);
            this.panelDetails.Controls.Add(this.label7);
            this.panelDetails.Controls.Add(this.txtWeight);
            this.panelDetails.Controls.Add(this.label6);
            this.panelDetails.Controls.Add(this.txtCargoName);
            this.panelDetails.Controls.Add(this.label5);
            this.panelDetails.Location = new System.Drawing.Point(6, 19);
            this.panelDetails.Name = "panelDetails";
            this.panelDetails.Size = new System.Drawing.Size(636, 382);
            this.panelDetails.TabIndex = 49;
            // 
            // richTxtDescription
            // 
            this.richTxtDescription.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.richTxtDescription.Location = new System.Drawing.Point(150, 281);
            this.richTxtDescription.Name = "richTxtDescription";
            this.richTxtDescription.ReadOnly = true;
            this.richTxtDescription.Size = new System.Drawing.Size(343, 60);
            this.richTxtDescription.TabIndex = 51;
            this.richTxtDescription.Text = "";
            // 
            // lblDescription
            // 
            this.lblDescription.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(147, 265);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(60, 13);
            this.lblDescription.TabIndex = 50;
            this.lblDescription.Text = "Description";
            // 
            // txtWidth
            // 
            this.txtWidth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWidth.Location = new System.Drawing.Point(150, 242);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.ReadOnly = true;
            this.txtWidth.Size = new System.Drawing.Size(363, 20);
            this.txtWidth.TabIndex = 44;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(147, 226);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 45;
            this.label8.Text = "Width";
            // 
            // txtHeight
            // 
            this.txtHeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHeight.Location = new System.Drawing.Point(150, 203);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.ReadOnly = true;
            this.txtHeight.Size = new System.Drawing.Size(363, 20);
            this.txtHeight.TabIndex = 42;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(147, 187);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 43;
            this.label7.Text = "Height";
            // 
            // txtWeight
            // 
            this.txtWeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWeight.Location = new System.Drawing.Point(150, 164);
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.ReadOnly = true;
            this.txtWeight.Size = new System.Drawing.Size(363, 20);
            this.txtWeight.TabIndex = 40;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(147, 148);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 41;
            this.label6.Text = "Weight";
            // 
            // txtCargoName
            // 
            this.txtCargoName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCargoName.Location = new System.Drawing.Point(150, 125);
            this.txtCargoName.Name = "txtCargoName";
            this.txtCargoName.ReadOnly = true;
            this.txtCargoName.Size = new System.Drawing.Size(363, 20);
            this.txtCargoName.TabIndex = 38;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(147, 109);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 39;
            this.label5.Text = "Name";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox1.Controls.Add(this.panelDetails);
            this.groupBox1.Location = new System.Drawing.Point(85, 307);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(648, 409);
            this.groupBox1.TabIndex = 52;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cargo";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox2.Controls.Add(this.txtExtraService);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtClient);
            this.groupBox2.Controls.Add(this.txtEndDate);
            this.groupBox2.Controls.Add(this.txtStartDate);
            this.groupBox2.Controls.Add(this.txtEndLocation);
            this.groupBox2.Controls.Add(this.lblCarrierName);
            this.groupBox2.Controls.Add(this.txtStartLocation);
            this.groupBox2.Controls.Add(this.lblBusinessMail);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(84, 31);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(643, 270);
            this.groupBox2.TabIndex = 53;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Reservation";
            // 
            // txtClient
            // 
            this.txtClient.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtClient.Location = new System.Drawing.Point(158, 195);
            this.txtClient.Name = "txtClient";
            this.txtClient.ReadOnly = true;
            this.txtClient.Size = new System.Drawing.Size(363, 20);
            this.txtClient.TabIndex = 52;
            // 
            // txtEndDate
            // 
            this.txtEndDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEndDate.Location = new System.Drawing.Point(158, 154);
            this.txtEndDate.Name = "txtEndDate";
            this.txtEndDate.ReadOnly = true;
            this.txtEndDate.Size = new System.Drawing.Size(363, 20);
            this.txtEndDate.TabIndex = 51;
            // 
            // txtStartDate
            // 
            this.txtStartDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStartDate.Location = new System.Drawing.Point(158, 117);
            this.txtStartDate.Name = "txtStartDate";
            this.txtStartDate.ReadOnly = true;
            this.txtStartDate.Size = new System.Drawing.Size(363, 20);
            this.txtStartDate.TabIndex = 50;
            // 
            // txtEndLocation
            // 
            this.txtEndLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEndLocation.Location = new System.Drawing.Point(158, 80);
            this.txtEndLocation.Name = "txtEndLocation";
            this.txtEndLocation.ReadOnly = true;
            this.txtEndLocation.Size = new System.Drawing.Size(363, 20);
            this.txtEndLocation.TabIndex = 49;
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button1.Location = new System.Drawing.Point(266, 738);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(135, 48);
            this.button1.TabIndex = 54;
            this.button1.Text = "Accept";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnDecline
            // 
            this.btnDecline.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnDecline.Enabled = false;
            this.btnDecline.Location = new System.Drawing.Point(435, 738);
            this.btnDecline.Name = "btnDecline";
            this.btnDecline.Size = new System.Drawing.Size(135, 48);
            this.btnDecline.TabIndex = 55;
            this.btnDecline.Text = "Decline";
            this.btnDecline.UseVisualStyleBackColor = true;
            this.btnDecline.Click += new System.EventHandler(this.btnDecline_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(155, 218);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 53;
            this.label4.Text = "Extra service";
            // 
            // txtExtraService
            // 
            this.txtExtraService.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtExtraService.Location = new System.Drawing.Point(158, 234);
            this.txtExtraService.Name = "txtExtraService";
            this.txtExtraService.ReadOnly = true;
            this.txtExtraService.Size = new System.Drawing.Size(363, 20);
            this.txtExtraService.TabIndex = 54;
            // 
            // frmOrdersAndDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(800, 815);
            this.Controls.Add(this.btnDecline);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmOrdersAndDetails";
            this.Text = "Orders with details";
            this.Load += new System.EventHandler(this.frmOrdersAndDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pBOrders)).EndInit();
            this.panelDetails.ResumeLayout(false);
            this.panelDetails.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pBOrders;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblBusinessMail;
        private System.Windows.Forms.TextBox txtStartLocation;
        private System.Windows.Forms.Label lblCarrierName;
        private System.Windows.Forms.Panel panelDetails;
        private System.Windows.Forms.RichTextBox richTxtDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtWeight;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCargoName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtClient;
        private System.Windows.Forms.TextBox txtEndDate;
        private System.Windows.Forms.TextBox txtStartDate;
        private System.Windows.Forms.TextBox txtEndLocation;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnDecline;
        private System.Windows.Forms.TextBox txtExtraService;
        private System.Windows.Forms.Label label4;
    }
}