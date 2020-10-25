namespace eTransport.WinUI
{
    partial class OneMyMessage
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
            this._lblMessage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _lblMessage
            // 
            this._lblMessage.AutoSize = true;
            this._lblMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lblMessage.Location = new System.Drawing.Point(270, 10);
            this._lblMessage.Margin = new System.Windows.Forms.Padding(0, 20, 0, 0);
            this._lblMessage.MaximumSize = new System.Drawing.Size(190, 0);
            this._lblMessage.Name = "_lblMessage";
            this._lblMessage.Padding = new System.Windows.Forms.Padding(10);
            this._lblMessage.Size = new System.Drawing.Size(38, 33);
            this._lblMessage.TabIndex = 0;
            this._lblMessage.Text = "cy";
            // 
            // OneMyMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this._lblMessage);
            this.Name = "OneMyMessage";
            this.Padding = new System.Windows.Forms.Padding(270, 10, 10, 10);
            this.Size = new System.Drawing.Size(550, 96);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _lblMessage;
    }
}
