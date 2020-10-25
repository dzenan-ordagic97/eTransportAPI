namespace eTransport.WinUI
{
    partial class OneMessage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OneMessage));
            this._lblMessage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _lblMessage
            // 
            this._lblMessage.AutoSize = true;
            this._lblMessage.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this._lblMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lblMessage.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this._lblMessage.Location = new System.Drawing.Point(10, 10);
            this._lblMessage.Margin = new System.Windows.Forms.Padding(3, 20, 3, 0);
            this._lblMessage.MaximumSize = new System.Drawing.Size(400, 0);
            this._lblMessage.Name = "_lblMessage";
            this._lblMessage.Padding = new System.Windows.Forms.Padding(10);
            this._lblMessage.Size = new System.Drawing.Size(400, 150);
            this._lblMessage.TabIndex = 0;
            this._lblMessage.Text = resources.GetString("_lblMessage.Text");
            // 
            // OneMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this._lblMessage);
            this.Name = "OneMessage";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(550, 170);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _lblMessage;
    }
}
