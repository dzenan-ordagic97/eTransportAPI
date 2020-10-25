using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eTransport.WinUI
{
    public partial class OneMessage : UserControl
    {
        public OneMessage(string content, string date)
        {
            InitializeComponent();
            this.Margin = new Padding() {Left = 15 };
            _lblMessage.Text = content;
        }
    }
}
