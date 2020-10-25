namespace eTransport.WinUI.Forms
{
    partial class frmAcceptedOrders
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
            this.gBAccepted = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanelAccepted = new System.Windows.Forms.FlowLayoutPanel();
            this.error = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            this.gBAccepted.SuspendLayout();
            this.SuspendLayout();
            // 
            // gBAccepted
            // 
            this.gBAccepted.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gBAccepted.Controls.Add(this.flowLayoutPanelAccepted);
            this.gBAccepted.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gBAccepted.Location = new System.Drawing.Point(12, 30);
            this.gBAccepted.Name = "gBAccepted";
            this.gBAccepted.Size = new System.Drawing.Size(763, 762);
            this.gBAccepted.TabIndex = 1;
            this.gBAccepted.TabStop = false;
            this.gBAccepted.Text = "Accepted orders";
            this.gBAccepted.Visible = false;
            // 
            // flowLayoutPanelAccepted
            // 
            this.flowLayoutPanelAccepted.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanelAccepted.AutoScroll = true;
            this.flowLayoutPanelAccepted.Location = new System.Drawing.Point(7, 19);
            this.flowLayoutPanelAccepted.Name = "flowLayoutPanelAccepted";
            this.flowLayoutPanelAccepted.Size = new System.Drawing.Size(751, 1163);
            this.flowLayoutPanelAccepted.TabIndex = 0;
            // 
            // error
            // 
            this.error.AutoSize = true;
            this.error.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.error.ForeColor = System.Drawing.Color.Red;
            this.error.Location = new System.Drawing.Point(15, 7);
            this.error.Name = "error";
            this.error.Size = new System.Drawing.Size(246, 20);
            this.error.TabIndex = 3;
            this.error.Text = "No available accepted orders!";
            this.error.Visible = false;
            // 
            // lblInfo
            // 
            this.lblInfo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.ForeColor = System.Drawing.Color.Teal;
            this.lblInfo.Location = new System.Drawing.Point(267, 7);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(388, 20);
            this.lblInfo.TabIndex = 4;
            this.lblInfo.Text = "Info: Client must accept the price to end freight";
            // 
            // frmAcceptedOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.error);
            this.Controls.Add(this.gBAccepted);
            this.Name = "frmAcceptedOrders";
            this.Text = "Accepted orders";
            this.Load += new System.EventHandler(this.frmAcceptedOrders_Load);
            this.gBAccepted.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gBAccepted;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelAccepted;
        private System.Windows.Forms.Label error;
        private System.Windows.Forms.Label lblInfo;
    }
}