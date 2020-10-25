using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using eTransport.Model;
using eTransport.WinUI.Helpers;
using eTransport.WinUI.Forms;

namespace eTransport.WinUI
{
    public partial class OneVehicle : UserControl
    {
        private Vehicle item;
        private readonly INavigation _navigation;
        private NavForms.Forma _previousForm;


        public OneVehicle(Vehicle item, Forms.INavigation navigation,NavForms.Forma previousForm)
        {
            InitializeComponent();
            this.item = item;
            _navigation = navigation;
            loadData();
            _previousForm = previousForm;
        }

        private void loadData()
        {
            _vehicleModel.Text = item.VehicleModel;
            _licenceNumber.Text = item.LicencePlate;
            pbVehicle.Image = PictureHelper.byteArrayToImage(item.Image);
        }

        private void OneVehicle_Load(object sender, MouseEventArgs e)
        {
            _navigation.Navigate(new frmVehicleAndDetails(item.VehicleID,_navigation), null);
            _navigation.Push(_previousForm);
        }
    }
}
