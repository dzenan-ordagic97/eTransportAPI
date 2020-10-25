namespace eTransport.WinUI
{
    partial class OneEditCity
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
            this._CityName = new System.Windows.Forms.Label();
            this._postal = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _CityName
            // 
            this._CityName.BackColor = System.Drawing.SystemColors.ControlLight;
            this._CityName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._CityName.ForeColor = System.Drawing.SystemColors.ControlText;
            this._CityName.Location = new System.Drawing.Point(90, 0);
            this._CityName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._CityName.Name = "_CityName";
            this._CityName.Size = new System.Drawing.Size(276, 95);
            this._CityName.TabIndex = 4;
            this._CityName.Text = "label1";
            this._CityName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._CityName.Click += new System.EventHandler(this._CityName_Click);
            // 
            // _postal
            // 
            this._postal.BackColor = System.Drawing.SystemColors.ControlLight;
            this._postal.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._postal.ForeColor = System.Drawing.SystemColors.ControlText;
            this._postal.Location = new System.Drawing.Point(95, 95);
            this._postal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._postal.Name = "_postal";
            this._postal.Size = new System.Drawing.Size(271, 90);
            this._postal.TabIndex = 5;
            this._postal.Text = "label1";
            this._postal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._postal.Click += new System.EventHandler(this._CityName_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(0, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "City name:";
            this.label1.Click += new System.EventHandler(this._CityName_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(3, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Postal nmbr:";
            this.label2.Click += new System.EventHandler(this._CityName_Click);
            // 
            // OneEditCity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._postal);
            this.Controls.Add(this._CityName);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "OneEditCity";
            this.Size = new System.Drawing.Size(370, 185);
            this.Click += new System.EventHandler(this._CityName_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _CityName;
        private System.Windows.Forms.Label _postal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
