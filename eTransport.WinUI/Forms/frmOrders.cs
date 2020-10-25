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
    public partial class frmOrders : Form
    {
        private readonly APIService _serviceCargoReservation = new APIService("CargoReservation");
        private readonly APIService _serviceCarrier = new APIService("Carrier");
        private readonly INavigation _navigation;
        public frmOrders()
        {
            InitializeComponent();
            getReservations();
        }
        public frmOrders(INavigation navigation)
        {
            InitializeComponent();
            _navigation = navigation;
            getReservations();
        }          
        private async void getReservations()
        {
            var result = await _serviceCarrier.Get<List<Model.Carrier>>(null);
            List<Model.CargoReservation> reservations = await _serviceCargoReservation.Get<List<Model.CargoReservation>>(null);
            if (reservations != null)
            {
                foreach (var item in reservations)
                {
                    if (item.FreightID == null && item.Accepted == false)
                    {
                        flowLayoutPanelGlobal.Controls.Add(new OneReservation(item, _navigation, NavForms.Forma.Orders));
                        gBGlobal.Visible = true;
                    }
                    if (item.Freight.CarrierID == result[0].CarrierID && item.Accepted==false) { 
                        flowLayoutPanelForYou.Controls.Add(new OneReservation(item, _navigation, NavForms.Forma.Orders));
                        gBForYou.Visible = true;
                        gBGlobal.Visible = true;
                    }
                    

                }
            }
            if(gBForYou.Visible==false && gBGlobal.Visible==false)
            {
                error.Visible = true;
            }
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
        private void frmOrders_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }
        private void btnShowAccepted_Click(object sender, EventArgs e)
        {
            _navigation.Navigate(new frmAcceptedOrders(_navigation), null);
            _navigation.Push(NavForms.Forma.Orders);
        }

        private void btnFinished_Click(object sender, EventArgs e)
        {
            _navigation.Navigate(new frmFinishedOrders(_navigation), null);
            _navigation.Push(NavForms.Forma.Orders);
        }

        
    }
}
