using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using eTransport.WinUI.Helpers;
using eTransport.WinUI.Forms;

namespace eTransport.WinUI
{
    public partial class OneEditCity : UserControl
    {
        SendData _sendData;
        Model.City City;
        public OneEditCity(Model.City item, SendData sendData)
        {
            InitializeComponent();
            _sendData = sendData;
            City = item;
            _CityName.Text = item.Name;
            _postal.Text = item.PostalNumber;
        }

        private void _CityName_Click(object sender, EventArgs e)
        {
            _sendData.Send(City);
        }
        
    }
}
