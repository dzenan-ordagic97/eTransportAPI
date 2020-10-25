using eTransport.WinUI.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eTransport.WinUI.Forms
{
    public partial class frmVehicles : Form
    {
        private readonly APIService _serviceVehicles = new APIService("Vehicle");
        private readonly INavigation _navigation;
        public frmVehicles(INavigation navigation)
        {
            InitializeComponent();
            _navigation = navigation;
            lblError.Visible = false;
            getVehicles();
        }
        public frmVehicles()
        {
            InitializeComponent();
            lblError.Visible = false;
            getVehicles();
        }
        private async void getVehicles()
        {
            List<Model.Vehicle> vozila = await _serviceVehicles.Get<List<Model.Vehicle>>(null);
            if (vozila != null)
            {
                foreach (var item in vozila)
                {
                    flowLayoutPanel1.Controls.Add(new OneVehicle(item, _navigation, NavForms.Forma.Vehicles));
                }
            }
            if(vozila.Count==0)
            {
                lblError.Visible = true;
            }
        }

        private void frmVehicles_Load(object sender, EventArgs e)
        {
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

        private void btn_addVehicle_Click(object sender, EventArgs e)
        {
            _navigation.Navigate(new frmAddVehicle(_navigation), sender);
            _navigation.Push(NavForms.Forma.Vehicles);
        }
    }
}
