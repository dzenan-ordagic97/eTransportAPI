namespace eTransport.WinUI.Forms
{
    partial class frmOrders
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
            this.gBGlobal = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanelGlobal = new System.Windows.Forms.FlowLayoutPanel();
            this.gBForYou = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanelForYou = new System.Windows.Forms.FlowLayoutPanel();
            this.error = new System.Windows.Forms.Label();
            this.btnShowAccepted = new System.Windows.Forms.Button();
            this.btnFinished = new System.Windows.Forms.Button();
            this.gBGlobal.SuspendLayout();
            this.gBForYou.SuspendLayout();
            this.SuspendLayout();
            // 
            // gBGlobal
            // 
            this.gBGlobal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gBGlobal.Controls.Add(this.flowLayoutPanelGlobal);
            this.gBGlobal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gBGlobal.Location = new System.Drawing.Point(8, 89);
            this.gBGlobal.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gBGlobal.Name = "gBGlobal";
            this.gBGlobal.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gBGlobal.Size = new System.Drawing.Size(1017, 437);
            this.gBGlobal.TabIndex = 0;
            this.gBGlobal.TabStop = false;
            this.gBGlobal.Text = "Global reservations";
            this.gBGlobal.Visible = false;
            // 
            // flowLayoutPanelGlobal
            // 
            this.flowLayoutPanelGlobal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanelGlobal.AutoScroll = true;
            this.flowLayoutPanelGlobal.Location = new System.Drawing.Point(9, 23);
            this.flowLayoutPanelGlobal.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.flowLayoutPanelGlobal.Name = "flowLayoutPanelGlobal";
            this.flowLayoutPanelGlobal.Size = new System.Drawing.Size(1001, 406);
            this.flowLayoutPanelGlobal.TabIndex = 0;
            // 
            // gBForYou
            // 
            this.gBForYou.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gBForYou.Controls.Add(this.flowLayoutPanelForYou);
            this.gBForYou.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gBForYou.Location = new System.Drawing.Point(16, 546);
            this.gBForYou.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gBForYou.Name = "gBForYou";
            this.gBForYou.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gBForYou.Size = new System.Drawing.Size(1017, 444);
            this.gBForYou.TabIndex = 1;
            this.gBForYou.TabStop = false;
            this.gBForYou.Text = "Reservations for you";
            this.gBForYou.Visible = false;
            // 
            // flowLayoutPanelForYou
            // 
            this.flowLayoutPanelForYou.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanelForYou.AutoScroll = true;
            this.flowLayoutPanelForYou.Location = new System.Drawing.Point(8, 25);
            this.flowLayoutPanelForYou.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.flowLayoutPanelForYou.Name = "flowLayoutPanelForYou";
            this.flowLayoutPanelForYou.Size = new System.Drawing.Size(1001, 412);
            this.flowLayoutPanelForYou.TabIndex = 1;
            // 
            // error
            // 
            this.error.AutoSize = true;
            this.error.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.error.ForeColor = System.Drawing.Color.Red;
            this.error.Location = new System.Drawing.Point(16, 28);
            this.error.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.error.Name = "error";
            this.error.Size = new System.Drawing.Size(214, 20);
            this.error.TabIndex = 2;
            this.error.Text = "No available reservations!";
            this.error.Visible = false;
            // 
            // btnShowAccepted
            // 
            this.btnShowAccepted.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowAccepted.Location = new System.Drawing.Point(812, 17);
            this.btnShowAccepted.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnShowAccepted.Name = "btnShowAccepted";
            this.btnShowAccepted.Size = new System.Drawing.Size(207, 50);
            this.btnShowAccepted.TabIndex = 3;
            this.btnShowAccepted.Text = "Show accepted orders";
            this.btnShowAccepted.UseVisualStyleBackColor = true;
            this.btnShowAccepted.Click += new System.EventHandler(this.btnShowAccepted_Click);
            // 
            // btnFinished
            // 
            this.btnFinished.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFinished.Location = new System.Drawing.Point(597, 17);
            this.btnFinished.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnFinished.Name = "btnFinished";
            this.btnFinished.Size = new System.Drawing.Size(207, 50);
            this.btnFinished.TabIndex = 4;
            this.btnFinished.Text = "Show finished orders";
            this.btnFinished.UseVisualStyleBackColor = true;
            this.btnFinished.Click += new System.EventHandler(this.btnFinished_Click);
            // 
            // frmOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1049, 1031);
            this.Controls.Add(this.btnFinished);
            this.Controls.Add(this.btnShowAccepted);
            this.Controls.Add(this.error);
            this.Controls.Add(this.gBForYou);
            this.Controls.Add(this.gBGlobal);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmOrders";
            this.Text = "Orders";
            this.Load += new System.EventHandler(this.frmOrders_Load);
            this.gBGlobal.ResumeLayout(false);
            this.gBForYou.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gBGlobal;
        private System.Windows.Forms.GroupBox gBForYou;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelGlobal;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelForYou;
        private System.Windows.Forms.Label error;
        private System.Windows.Forms.Button btnShowAccepted;
        private System.Windows.Forms.Button btnFinished;
    }
}