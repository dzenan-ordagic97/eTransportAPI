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
    public partial class OneEditVehicle : UserControl
    {
        SendData _sendData;
        Model.Vehicle Vehicle;
        private readonly APIService _service = new APIService("Vehicle");

        public OneEditVehicle(Model.Vehicle item, SendData sendData)
        {
            InitializeComponent();
            _sendData = sendData;
            Vehicle = item;
            _vehicleName.Text = item.VehicleModel;
            _vehicleImage.Image = PictureHelper.byteArrayToImage(item.Image);
        }

        private void _vehicleImage_Click(object sender, EventArgs e)
        {
            _sendData.Send(Vehicle);
        }

        private async void btnRemove_Click(object sender, EventArgs e)
        {
            await _service.Delete<Model.Vehicle>(Vehicle.VehicleID);
            MessageBox.Show("Succesfuly Deleted", "Vehicle", MessageBoxButtons.OK);
            _sendData.Send(null);
        }
    }
}
