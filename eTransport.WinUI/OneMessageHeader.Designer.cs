namespace eTransport.WinUI
{
    partial class OneMessageHeader
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
            this.lbl_name = new System.Windows.Forms.Label();
            this.lbl_lastMessage = new System.Windows.Forms.Label();
            this._picStatus = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this._picStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_name.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbl_name.Location = new System.Drawing.Point(56, 11);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(45, 15);
            this.lbl_name.TabIndex = 0;
            this.lbl_name.Text = "Name";
            this.lbl_name.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OneMessageHeader_MouseClick);
            // 
            // lbl_lastMessage
            // 
            this.lbl_lastMessage.AutoSize = true;
            this.lbl_lastMessage.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbl_lastMessage.Location = new System.Drawing.Point(56, 37);
            this.lbl_lastMessage.Name = "lbl_lastMessage";
            this.lbl_lastMessage.Size = new System.Drawing.Size(35, 13);
            this.lbl_lastMessage.TabIndex = 1;
            this.lbl_lastMessage.Text = "label2";
            this.lbl_lastMessage.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OneMessageHeader_MouseClick);
            // 
            // _picStatus
            // 
            this._picStatus.Location = new System.Drawing.Point(194, 3);
            this._picStatus.Name = "_picStatus";
            this._picStatus.Size = new System.Drawing.Size(19, 23);
            this._picStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this._picStatus.TabIndex = 2;
            this._picStatus.TabStop = false;
            // 
            // OneMessageHeader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this._picStatus);
            this.Controls.Add(this.lbl_lastMessage);
            this.Controls.Add(this.lbl_name);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.Name = "OneMessageHeader";
            this.Size = new System.Drawing.Size(216, 64);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OneMessageHeader_MouseClick);
            ((System.ComponentModel.ISupportInitialize)(this._picStatus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.Label lbl_lastMessage;
        private System.Windows.Forms.PictureBox _picStatus;
    }
}
