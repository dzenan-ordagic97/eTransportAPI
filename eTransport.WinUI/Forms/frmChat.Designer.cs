namespace eTransport.WinUI.Forms
{
    partial class frmChat
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
            this._flpMessages = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // _flpMessages
            // 
            this._flpMessages.AutoScroll = true;
            this._flpMessages.Dock = System.Windows.Forms.DockStyle.Fill;
            this._flpMessages.FlowDirection = System.Windows.Forms.FlowDirection.BottomUp;
            this._flpMessages.Location = new System.Drawing.Point(0, 0);
            this._flpMessages.Name = "_flpMessages";
            this._flpMessages.Size = new System.Drawing.Size(800, 450);
            this._flpMessages.TabIndex = 0;
            this._flpMessages.WrapContents = false;
            // 
            // frmChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this._flpMessages);
            this.Name = "frmChat";
            this.Text = "frmChat";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel _flpMessages;
    }
}