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
    public partial class OneMyMessage : UserControl
    {
        public OneMyMessage(string content,string time)
        {
            InitializeComponent();
            this.Margin = new Padding() {Left = 15 };
            _lblMessage.Text = content;
        }
    }
}
