namespace eTransport.WinUI.Forms
{
    partial class frmFreightDetails
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
            this.gBFreightDetails = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanelFreightDetails = new System.Windows.Forms.FlowLayoutPanel();
            this.error = new System.Windows.Forms.Label();
            this.gBFreightDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // gBFreightDetails
            // 
            this.gBFreightDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gBFreightDetails.Controls.Add(this.flowLayoutPanelFreightDetails);
            this.gBFreightDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gBFreightDetails.Location = new System.Drawing.Point(16, 41);
            this.gBFreightDetails.Margin = new System.Windows.Forms.Padding(4);
            this.gBFreightDetails.Name = "gBFreightDetails";
            this.gBFreightDetails.Padding = new System.Windows.Forms.Padding(4);
            this.gBFreightDetails.Size = new System.Drawing.Size(1035, 769);
            this.gBFreightDetails.TabIndex = 5;
            this.gBFreightDetails.TabStop = false;
            this.gBFreightDetails.Text = "Freights with ratings";
            this.gBFreightDetails.Visible = false;
            // 
            // flowLayoutPanelFreightDetails
            // 
            this.flowLayoutPanelFreightDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanelFreightDetails.AutoScroll = true;
            this.flowLayoutPanelFreightDetails.Location = new System.Drawing.Point(9, 23);
            this.flowLayoutPanelFreightDetails.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanelFreightDetails.Name = "flowLayoutPanelFreightDetails";
            this.flowLayoutPanelFreightDetails.Size = new System.Drawing.Size(1019, 1037);
            this.flowLayoutPanelFreightDetails.TabIndex = 0;
            // 
            // error
            // 
            this.error.AutoSize = true;
            this.error.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.error.ForeColor = System.Drawing.Color.Red;
            this.error.Location = new System.Drawing.Point(21, 17);
            this.error.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.error.Name = "error";
            this.error.Size = new System.Drawing.Size(171, 20);
            this.error.TabIndex = 6;
            this.error.Text = "No available ratings!";
            this.error.Visible = false;
            // 
            // frmFreightDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 879);
            this.Controls.Add(this.error);
            this.Controls.Add(this.gBFreightDetails);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmFreightDetails";
            this.Text = "Freight details";
            this.gBFreightDetails.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gBFreightDetails;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelFreightDetails;
        private System.Windows.Forms.Label error;
    }
}