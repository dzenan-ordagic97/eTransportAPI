using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using eTransport.WinUI.Forms;
using eTransport.WinUI.Helpers;

namespace eTransport.WinUI
{
    public partial class OneEditCountry : UserControl
    {
        SendData _sendData;
        Model.Country Country;

        public OneEditCountry(Model.Country item, SendData sendData)
        {
            InitializeComponent();
            _sendData = sendData;
            Country = item;
            _CountryName.Text = item.Name;
            _Acronym.Text = item.Acronym;
        }

        private void _CountryName_Click(object sender, EventArgs e)
        {
            _sendData.Send(Country);
        }

        
    }
}
