namespace eTransport.WinUI
{
    partial class OneEditExtraServices
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
            this._ExtraServicesName = new System.Windows.Forms.Label();
            this.btnRemove = new System.Windows.Forms.Button();
            this._Price = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _ExtraServicesName
            // 
            this._ExtraServicesName.BackColor = System.Drawing.SystemColors.ControlLight;
            this._ExtraServicesName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ExtraServicesName.Location = new System.Drawing.Point(96, 0);
            this._ExtraServicesName.Name = "_ExtraServicesName";
            this._ExtraServicesName.Size = new System.Drawing.Size(183, 73);
            this._ExtraServicesName.TabIndex = 2;
            this._ExtraServicesName.Text = "label1";
            this._ExtraServicesName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._ExtraServicesName.Click += new System.EventHandler(this._ExtraServicesName_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Enabled = false;
            this.btnRemove.Location = new System.Drawing.Point(285, 56);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(112, 39);
            this.btnRemove.TabIndex = 3;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // _Price
            // 
            this._Price.BackColor = System.Drawing.SystemColors.ControlLight;
            this._Price.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Price.Location = new System.Drawing.Point(100, 81);
            this._Price.Name = "_Price";
            this._Price.Size = new System.Drawing.Size(179, 73);
            this._Price.TabIndex = 4;
            this._Price.Text = "label1";
            this._Price.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._Price.Click += new System.EventHandler(this._ExtraServicesName_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 31);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 18);
            this.label2.TabIndex = 5;
            this.label2.Text = "Service name:";
            this.label2.Click += new System.EventHandler(this._ExtraServicesName_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 112);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 18);
            this.label3.TabIndex = 6;
            this.label3.Text = "Price:";
            this.label3.Click += new System.EventHandler(this._ExtraServicesName_Click);
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.ForeColor = System.Drawing.Color.Teal;
            this.lblInfo.Location = new System.Drawing.Point(121, 0);
            this.lblInfo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(158, 18);
            this.lblInfo.TabIndex = 7;
            this.lblInfo.Text = "It is used! Can\'t update!";
            // 
            // OneEditExtraServices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._Price);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this._ExtraServicesName);
            this.Name = "OneEditExtraServices";
            this.Size = new System.Drawing.Size(418, 154);
            this.Click += new System.EventHandler(this._ExtraServicesName_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label _ExtraServicesName;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Label _Price;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblInfo;
    }
}
