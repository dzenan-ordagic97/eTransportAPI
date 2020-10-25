namespace eTransport.WinUI
{
    partial class OneReservation
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtStartLocation = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtStartDate = new System.Windows.Forms.TextBox();
            this.txtEndLocation = new System.Windows.Forms.TextBox();
            this.txtEndDate = new System.Windows.Forms.TextBox();
            this.txtClient = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnEnd = new System.Windows.Forms.Button();
            this.lblExtraService = new System.Windows.Forms.Label();
            this.txtExtraService = new System.Windows.Forms.TextBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.lblPayed = new System.Windows.Forms.Label();
            this.txtPayed = new System.Windows.Forms.TextBox();
            this.txtExtraService2 = new System.Windows.Forms.TextBox();
            this.lblExtraService2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtStartLocation
            // 
            this.txtStartLocation.Location = new System.Drawing.Point(15, 65);
            this.txtStartLocation.Name = "txtStartLocation";
            this.txtStartLocation.ReadOnly = true;
            this.txtStartLocation.Size = new System.Drawing.Size(131, 20);
            this.txtStartLocation.TabIndex = 0;
            this.txtStartLocation.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Start location";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "End location";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(172, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "Expected start on";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(172, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 18);
            this.label4.TabIndex = 7;
            this.label4.Text = "Expected end on";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(89, 232);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(137, 34);
            this.button1.TabIndex = 8;
            this.button1.Text = "View details";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtStartDate
            // 
            this.txtStartDate.Location = new System.Drawing.Point(175, 65);
            this.txtStartDate.Name = "txtStartDate";
            this.txtStartDate.ReadOnly = true;
            this.txtStartDate.Size = new System.Drawing.Size(131, 20);
            this.txtStartDate.TabIndex = 9;
            this.txtStartDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtEndLocation
            // 
            this.txtEndLocation.Location = new System.Drawing.Point(15, 109);
            this.txtEndLocation.Name = "txtEndLocation";
            this.txtEndLocation.ReadOnly = true;
            this.txtEndLocation.Size = new System.Drawing.Size(131, 20);
            this.txtEndLocation.TabIndex = 10;
            this.txtEndLocation.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtEndDate
            // 
            this.txtEndDate.Location = new System.Drawing.Point(175, 109);
            this.txtEndDate.Name = "txtEndDate";
            this.txtEndDate.ReadOnly = true;
            this.txtEndDate.Size = new System.Drawing.Size(131, 20);
            this.txtEndDate.TabIndex = 11;
            this.txtEndDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtClient
            // 
            this.txtClient.Location = new System.Drawing.Point(89, 21);
            this.txtClient.Name = "txtClient";
            this.txtClient.ReadOnly = true;
            this.txtClient.Size = new System.Drawing.Size(141, 20);
            this.txtClient.TabIndex = 13;
            this.txtClient.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(134, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 18);
            this.label5.TabIndex = 12;
            this.label5.Text = "Client";
            // 
            // btnEnd
            // 
            this.btnEnd.Location = new System.Drawing.Point(89, 232);
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(137, 34);
            this.btnEnd.TabIndex = 14;
            this.btnEnd.Text = "End freight";
            this.btnEnd.UseVisualStyleBackColor = true;
            this.btnEnd.Visible = false;
            this.btnEnd.Click += new System.EventHandler(this.btnEnd_Click);
            // 
            // lblExtraService
            // 
            this.lblExtraService.AutoSize = true;
            this.lblExtraService.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExtraService.Location = new System.Drawing.Point(12, 132);
            this.lblExtraService.Name = "lblExtraService";
            this.lblExtraService.Size = new System.Drawing.Size(93, 18);
            this.lblExtraService.TabIndex = 16;
            this.lblExtraService.Text = "Extra service";
            this.lblExtraService.Visible = false;
            // 
            // txtExtraService
            // 
            this.txtExtraService.Location = new System.Drawing.Point(15, 153);
            this.txtExtraService.Name = "txtExtraService";
            this.txtExtraService.ReadOnly = true;
            this.txtExtraService.Size = new System.Drawing.Size(129, 20);
            this.txtExtraService.TabIndex = 17;
            this.txtExtraService.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtExtraService.Visible = false;
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrice.Location = new System.Drawing.Point(172, 132);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(42, 18);
            this.lblPrice.TabIndex = 18;
            this.lblPrice.Text = "Price";
            this.lblPrice.Visible = false;
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(175, 153);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.ReadOnly = true;
            this.txtPrice.Size = new System.Drawing.Size(131, 20);
            this.txtPrice.TabIndex = 19;
            this.txtPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPrice.Visible = false;
            // 
            // lblPayed
            // 
            this.lblPayed.AutoSize = true;
            this.lblPayed.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPayed.Location = new System.Drawing.Point(134, 176);
            this.lblPayed.Name = "lblPayed";
            this.lblPayed.Size = new System.Drawing.Size(57, 18);
            this.lblPayed.TabIndex = 20;
            this.lblPayed.Text = "Payed?";
            this.lblPayed.Visible = false;
            // 
            // txtPayed
            // 
            this.txtPayed.Location = new System.Drawing.Point(95, 197);
            this.txtPayed.Name = "txtPayed";
            this.txtPayed.ReadOnly = true;
            this.txtPayed.Size = new System.Drawing.Size(131, 20);
            this.txtPayed.TabIndex = 21;
            this.txtPayed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPayed.Visible = false;
            // 
            // txtExtraService2
            // 
            this.txtExtraService2.Location = new System.Drawing.Point(95, 153);
            this.txtExtraService2.Name = "txtExtraService2";
            this.txtExtraService2.ReadOnly = true;
            this.txtExtraService2.Size = new System.Drawing.Size(129, 20);
            this.txtExtraService2.TabIndex = 23;
            this.txtExtraService2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblExtraService2
            // 
            this.lblExtraService2.AutoSize = true;
            this.lblExtraService2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExtraService2.Location = new System.Drawing.Point(111, 132);
            this.lblExtraService2.Name = "lblExtraService2";
            this.lblExtraService2.Size = new System.Drawing.Size(93, 18);
            this.lblExtraService2.TabIndex = 22;
            this.lblExtraService2.Text = "Extra service";
            // 
            // OneReservation
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.txtExtraService2);
            this.Controls.Add(this.lblExtraService2);
            this.Controls.Add(this.txtPayed);
            this.Controls.Add(this.lblPayed);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.txtExtraService);
            this.Controls.Add(this.lblExtraService);
            this.Controls.Add(this.btnEnd);
            this.Controls.Add(this.txtClient);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtEndDate);
            this.Controls.Add(this.txtEndLocation);
            this.Controls.Add(this.txtStartDate);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtStartLocation);
            this.Name = "OneReservation";
            this.Size = new System.Drawing.Size(324, 279);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtStartLocation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtStartDate;
        private System.Windows.Forms.TextBox txtEndLocation;
        private System.Windows.Forms.TextBox txtEndDate;
        private System.Windows.Forms.TextBox txtClient;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnEnd;
        private System.Windows.Forms.Label lblExtraService;
        private System.Windows.Forms.TextBox txtExtraService;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label lblPayed;
        private System.Windows.Forms.TextBox txtPayed;
        private System.Windows.Forms.TextBox txtExtraService2;
        private System.Windows.Forms.Label lblExtraService2;
    }
}
