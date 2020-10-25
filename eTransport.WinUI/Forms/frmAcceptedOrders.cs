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
    public partial class frmAcceptedOrders : Form
    {
        private readonly APIService _serviceAcceptedOrders = new APIService("CargoReservation");
        private readonly APIService _serviceCarrier = new APIService("Carrier");
        private readonly INavigation _navigation;
        private Model.Requests.CargoReservationSearchRequest _cargoSearch;
        public frmAcceptedOrders(INavigation navigation)
        {
            InitializeComponent();
            _navigation = navigation;
            _cargoSearch = new Model.Requests.CargoReservationSearchRequest();
        }
        private async void frmAcceptedOrders_Load(object sender, EventArgs e)
        {
            var result = await _serviceCarrier.Get<List<Model.Carrier>>(null);
            _cargoSearch.CarrierID = result[0].CarrierID;
            bool trigger = false;
            List<Model.CargoReservation> cargoReservation = await _serviceAcceptedOrders.Get<List<Model.CargoReservation>>(_cargoSearch);
            if (cargoReservation != null)
            {
                foreach (var item in cargoReservation)
                {
                    if (item.Accepted == true && item.Freight.Finished==false)
                    {
                        flowLayoutPanelAccepted.Controls.Add(new OneReservation(item, _navigation, NavForms.Forma.AcceptedOrders));
                        gBAccepted.Visible = true;
                        trigger = true;
                    }
                }
            }
            else
            {
                lblInfo.Visible = false;
                error.Visible = true;
            }
            if (trigger == false)
            {
                lblInfo.Visible = false;
                error.Visible = true;

            }
            LoadTheme();
        }
        private void LoadTheme()
        {
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btn.BackColor = ThemeColor.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
            }
        }
    }
}
