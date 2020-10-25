namespace eTransport.WinUI
{
    partial class OneEditVehicle
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
            this._vehicleImage = new System.Windows.Forms.PictureBox();
            this._vehicleName = new System.Windows.Forms.Label();
            this.btnRemove = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._vehicleImage)).BeginInit();
            this.SuspendLayout();
            // 
            // _vehicleImage
            // 
            this._vehicleImage.Location = new System.Drawing.Point(3, 3);
            this._vehicleImage.Name = "_vehicleImage";
            this._vehicleImage.Size = new System.Drawing.Size(142, 144);
            this._vehicleImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this._vehicleImage.TabIndex = 0;
            this._vehicleImage.TabStop = false;
            this._vehicleImage.Click += new System.EventHandler(this._vehicleImage_Click);
            // 
            // _vehicleName
            // 
            this._vehicleName.BackColor = System.Drawing.SystemColors.Control;
            this._vehicleName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._vehicleName.Location = new System.Drawing.Point(151, 3);
            this._vehicleName.Name = "_vehicleName";
            this._vehicleName.Size = new System.Drawing.Size(261, 144);
            this._vehicleName.TabIndex = 0;
            this._vehicleName.Text = "label1";
            this._vehicleName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(434, 45);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(112, 63);
            this.btnRemove.TabIndex = 2;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // OneEditVehicle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this._vehicleName);
            this.Controls.Add(this._vehicleImage);
            this.Name = "OneEditVehicle";
            this.Size = new System.Drawing.Size(559, 154);
            ((System.ComponentModel.ISupportInitialize)(this._vehicleImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox _vehicleImage;
        private System.Windows.Forms.Label _vehicleName;
        private System.Windows.Forms.Button btnRemove;
    }
}
