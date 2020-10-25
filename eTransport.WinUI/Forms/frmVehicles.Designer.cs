namespace eTransport.WinUI.Forms
{
    partial class frmVehicles
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btn_addVehicle = new MaterialSkin.Controls.MaterialFlatButton();
            this.lblError = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(13, 60);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(852, 424);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // btn_addVehicle
            // 
            this.btn_addVehicle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_addVehicle.AutoSize = true;
            this.btn_addVehicle.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_addVehicle.Depth = 0;
            this.btn_addVehicle.Icon = null;
            this.btn_addVehicle.Location = new System.Drawing.Point(758, 12);
            this.btn_addVehicle.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btn_addVehicle.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_addVehicle.Name = "btn_addVehicle";
            this.btn_addVehicle.Primary = false;
            this.btn_addVehicle.Size = new System.Drawing.Size(106, 36);
            this.btn_addVehicle.TabIndex = 5;
            this.btn_addVehicle.Text = "Add Vehicle";
            this.btn_addVehicle.UseVisualStyleBackColor = true;
            this.btn_addVehicle.Click += new System.EventHandler(this.btn_addVehicle_Click);
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblError.Location = new System.Drawing.Point(12, 24);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(185, 22);
            this.lblError.TabIndex = 6;
            this.lblError.Text = "No available vehicles!";
            this.lblError.Visible = false;
            // 
            // frmVehicles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 496);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.btn_addVehicle);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "frmVehicles";
            this.Text = "Vehicles";
            this.Load += new System.EventHandler(this.frmVehicles_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private MaterialSkin.Controls.MaterialFlatButton btn_addVehicle;
        private System.Windows.Forms.Label lblError;
    }
}