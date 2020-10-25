namespace eTransport.WinUI
{
    partial class OneVehicle
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
            this.components = new System.ComponentModel.Container();
            this.pbVehicle = new System.Windows.Forms.PictureBox();
            this.lblModel = new System.Windows.Forms.Label();
            this.lblLicence = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this._licenceNumber = new System.Windows.Forms.Label();
            this._vehicleModel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbVehicle)).BeginInit();
            this.SuspendLayout();
            // 
            // pbVehicle
            // 
            this.pbVehicle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbVehicle.InitialImage = global::eTransport.WinUI.Properties.Resources.delivery;
            this.pbVehicle.Location = new System.Drawing.Point(14, 15);
            this.pbVehicle.Name = "pbVehicle";
            this.pbVehicle.Size = new System.Drawing.Size(408, 263);
            this.pbVehicle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbVehicle.TabIndex = 0;
            this.pbVehicle.TabStop = false;
            this.pbVehicle.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OneVehicle_Load);
            // 
            // lblModel
            // 
            this.lblModel.AutoSize = true;
            this.lblModel.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModel.Location = new System.Drawing.Point(10, 315);
            this.lblModel.Name = "lblModel";
            this.lblModel.Size = new System.Drawing.Size(61, 19);
            this.lblModel.TabIndex = 3;
            this.lblModel.Text = "Model:";
            // 
            // lblLicence
            // 
            this.lblLicence.AutoSize = true;
            this.lblLicence.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLicence.Location = new System.Drawing.Point(247, 315);
            this.lblLicence.Name = "lblLicence";
            this.lblLicence.Size = new System.Drawing.Size(69, 19);
            this.lblLicence.TabIndex = 4;
            this.lblLicence.Text = "Licence:";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // _licenceNumber
            // 
            this._licenceNumber.AutoSize = true;
            this._licenceNumber.Location = new System.Drawing.Point(322, 319);
            this._licenceNumber.Name = "_licenceNumber";
            this._licenceNumber.Size = new System.Drawing.Size(35, 13);
            this._licenceNumber.TabIndex = 8;
            this._licenceNumber.Text = "label1";
            // 
            // _vehicleModel
            // 
            this._vehicleModel.AutoSize = true;
            this._vehicleModel.Location = new System.Drawing.Point(77, 319);
            this._vehicleModel.Name = "_vehicleModel";
            this._vehicleModel.Size = new System.Drawing.Size(35, 13);
            this._vehicleModel.TabIndex = 9;
            this._vehicleModel.Text = "label2";
            // 
            // OneVehicle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this._vehicleModel);
            this.Controls.Add(this._licenceNumber);
            this.Controls.Add(this.lblLicence);
            this.Controls.Add(this.lblModel);
            this.Controls.Add(this.pbVehicle);
            this.Name = "OneVehicle";
            this.Size = new System.Drawing.Size(441, 355);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OneVehicle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbVehicle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbVehicle;
        private System.Windows.Forms.Label lblModel;
        private System.Windows.Forms.Label lblLicence;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label _licenceNumber;
        private System.Windows.Forms.Label _vehicleModel;
    }
}
