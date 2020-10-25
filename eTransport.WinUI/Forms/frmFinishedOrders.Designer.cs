namespace eTransport.WinUI.Forms
{
    partial class frmFinishedOrders
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
            this.gBFinished = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanelFinished = new System.Windows.Forms.FlowLayoutPanel();
            this.error = new System.Windows.Forms.Label();
            this.gBFinished.SuspendLayout();
            this.SuspendLayout();
            // 
            // gBFinished
            // 
            this.gBFinished.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gBFinished.Controls.Add(this.flowLayoutPanelFinished);
            this.gBFinished.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gBFinished.Location = new System.Drawing.Point(12, 43);
            this.gBFinished.Name = "gBFinished";
            this.gBFinished.Size = new System.Drawing.Size(776, 770);
            this.gBFinished.TabIndex = 4;
            this.gBFinished.TabStop = false;
            this.gBFinished.Text = "Finished orders";
            this.gBFinished.Visible = false;
            // 
            // flowLayoutPanelFinished
            // 
            this.flowLayoutPanelFinished.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanelFinished.AutoScroll = true;
            this.flowLayoutPanelFinished.Location = new System.Drawing.Point(7, 19);
            this.flowLayoutPanelFinished.Name = "flowLayoutPanelFinished";
            this.flowLayoutPanelFinished.Size = new System.Drawing.Size(764, 1139);
            this.flowLayoutPanelFinished.TabIndex = 0;
            // 
            // error
            // 
            this.error.AutoSize = true;
            this.error.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.error.ForeColor = System.Drawing.Color.Red;
            this.error.Location = new System.Drawing.Point(22, 9);
            this.error.Name = "error";
            this.error.Size = new System.Drawing.Size(235, 20);
            this.error.TabIndex = 5;
            this.error.Text = "No available finished orders!";
            this.error.Visible = false;
            // 
            // frmFinishedOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gBFinished);
            this.Controls.Add(this.error);
            this.Name = "frmFinishedOrders";
            this.Text = "Finished orders";
            this.Load += new System.EventHandler(this.frmFinishedOrders_Load);
            this.gBFinished.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gBFinished;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelFinished;
        private System.Windows.Forms.Label error;
    }
}