namespace eTransport.WinUI
{
    partial class OneEditCountry
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
            this._CountryName = new System.Windows.Forms.Label();
            this._Acronym = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _CountryName
            // 
            this._CountryName.BackColor = System.Drawing.SystemColors.ControlLight;
            this._CountryName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._CountryName.Location = new System.Drawing.Point(112, 0);
            this._CountryName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._CountryName.Name = "_CountryName";
            this._CountryName.Size = new System.Drawing.Size(273, 81);
            this._CountryName.TabIndex = 3;
            this._CountryName.Text = "label1";
            this._CountryName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._CountryName.Click += new System.EventHandler(this._CountryName_Click);
            // 
            // _Acronym
            // 
            this._Acronym.BackColor = System.Drawing.SystemColors.ControlLight;
            this._Acronym.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Acronym.Location = new System.Drawing.Point(112, 81);
            this._Acronym.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._Acronym.Name = "_Acronym";
            this._Acronym.Size = new System.Drawing.Size(273, 79);
            this._Acronym.TabIndex = 4;
            this._Acronym.Text = "label1";
            this._Acronym.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._Acronym.Click += new System.EventHandler(this._CountryName_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Country name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Acronym:";
            // 
            // OneEditCountry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._Acronym);
            this.Controls.Add(this._CountryName);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "OneEditCountry";
            this.Size = new System.Drawing.Size(385, 160);
            this.Click += new System.EventHandler(this._CountryName_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _CountryName;
        private System.Windows.Forms.Label _Acronym;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
