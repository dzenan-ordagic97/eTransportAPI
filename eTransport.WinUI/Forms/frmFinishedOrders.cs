using eTransport.WinUI.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eTransport.WinUI.Forms
{
    public partial class frmFinishedOrders : Form
    {
        private int y = new int();
        private readonly APIService _serviceAcceptedOrders = new APIService("CargoReservation");
        private readonly APIService _serviceCarrier = new APIService("Carrier");
        private readonly INavigation _navigation;
        private Model.Requests.CargoReservationSearchRequest _cargoSearch;

        public frmFinishedOrders(INavigation navigation)
        {
            InitializeComponent();
            _navigation = navigation;
            _cargoSearch = new Model.Requests.CargoReservationSearchRequest();
        }
        private async void frmFinishedOrders_Load(object sender, EventArgs e)
        {
            var result = await _serviceCarrier.Get<List<Model.Carrier>>(null);
            _cargoSearch.CarrierID = result[0].CarrierID;
            bool trigger = false;
            List<Model.CargoReservation> cargoReservation = await _serviceAcceptedOrders.Get<List<Model.CargoReservation>>(_cargoSearch);
            if (cargoReservation != null)
            {
                foreach (var item in cargoReservation)
                {
                    if (item.Freight.Finished == true)
                    {
                        flowLayoutPanelFinished.Controls.Add(new OneReservation(item, _navigation, NavForms.Forma.AcceptedOrders));
                        gBFinished.Visible = true;
                        trigger = true;
                    }
                }
            }
            else
            {
                error.Visible = true;
            }
            if (trigger == false)
                error.Visible = true;
        }
    }
}
