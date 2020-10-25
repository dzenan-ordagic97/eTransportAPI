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
    public partial class OneEditExtraServices : UserControl
    {
        SendData _sendData;
        Model.ExtraServices ExtraServices;
        private readonly APIService _service = new APIService("ExtraServices");
        private readonly APIService _serviceCargoReservation = new APIService("CargoReservation");
        private Model.Requests.CargoReservationSearchRequest searchRequest;

        public OneEditExtraServices(Model.ExtraServices item, SendData sendData)
        {
            InitializeComponent();
            _sendData = sendData;
            ExtraServices = item;
            _ExtraServicesName.Text = item.Name;
            _Price.Text = item.Price.ToString();
            checkForExtraUsage();
        }
        private async void checkForExtraUsage()
        {
            searchRequest = new Model.Requests.CargoReservationSearchRequest()
            {
                ExtraServicesID = ExtraServices.ExtraServicesID,
                isExtraServiceDelete = true
            };
            var reservationsExtra = await _serviceCargoReservation.Get<List<Model.CargoReservation>>(searchRequest);
            if (reservationsExtra.Count == 0)
            {
                btnRemove.Enabled = true;
                lblInfo.Visible = false;
            }
           
        }
        private async void _ExtraServicesName_Click(object sender, EventArgs e)
        {
            searchRequest = new Model.Requests.CargoReservationSearchRequest()
            {
                ExtraServicesID = ExtraServices.ExtraServicesID,
                isExtraServiceDelete = true
            };
            var reservationsExtra = await _serviceCargoReservation.Get<List<Model.CargoReservation>>(searchRequest);
            if (reservationsExtra.Count > 0)
            {
                _sendData.Send(null);
            }
            else
            {
                _sendData.Send(ExtraServices);
            }
        }

        private async void btnRemove_Click(object sender, EventArgs e)
        {

            await _service.Delete<Model.ExtraServices>(ExtraServices.ExtraServicesID);
            MessageBox.Show("Succesfuly Deleted", "Extra services", MessageBoxButtons.OK);
            _sendData.Send(null);
        }
    }
}
