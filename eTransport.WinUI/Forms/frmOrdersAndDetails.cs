using eTransport.Model;
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
    public partial class frmOrdersAndDetails : Form
    {
        private readonly APIService _serviceOrderWithDetails= new APIService("CargoReservation");
        private readonly APIService _serviceFreight = new APIService("Freight");
        private Model.Requests.CargoReservationInsertRequest request;
        private readonly INavigation _navigation;
        private int _id=0;
        public frmOrdersAndDetails()
        {
            InitializeComponent();
            request = new Model.Requests.CargoReservationInsertRequest();
        }
        public frmOrdersAndDetails(int id, INavigation navigation)
        {
            InitializeComponent();
            _navigation = navigation;
            _id = id;
            request = new Model.Requests.CargoReservationInsertRequest();
        }
        private async void frmOrdersAndDetails_Load(object sender, EventArgs e)
        {
            var cargoReservation = await _serviceOrderWithDetails.GetById<Model.CargoReservation>(_id);
            txtStartLocation.Text = cargoReservation.StartLocation;
            txtEndLocation.Text = cargoReservation.EndLocation;
            txtStartDate.Text = cargoReservation.StartDateTransport.ToString("dd.MM.yyyy");
            txtEndDate.Text = cargoReservation.EndDateTransport.ToString("dd.MM.yyyy");
            txtClient.Text = cargoReservation.Client;
            txtHeight.Text = cargoReservation.Cargo.MaxHeight.ToString();
            txtWeight.Text = cargoReservation.Cargo.Weight.ToString();
            txtWidth.Text = cargoReservation.Cargo.MaxWidth.ToString();
            txtCargoName.Text = cargoReservation.Cargo.Name;
            richTxtDescription.Text = cargoReservation.Cargo.Description;
            if (cargoReservation.Cargo.Image.Length == 0)
            {
                cargoReservation.Cargo.Image = PictureHelper.imageToByteArray(Properties.Resources.delivery);
            }
            pBOrders.Image = PictureHelper.byteArrayToImage(cargoReservation.Cargo.Image);
            if(cargoReservation.FreightID!=null)
            {
                btnDecline.Enabled = true;
            }
            if(cargoReservation.ExtraServices==null)
            {
                txtExtraService.Text = "No extra service";
            }
            else
            {
                txtExtraService.Text = cargoReservation.ExtraServices.Name;
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
        private void button1_Click(object sender, EventArgs e)
        {
            _navigation.Navigate(new frmAddFreight(_id,_navigation), null);
        }
        private async void btnDecline_Click(object sender, EventArgs e)
        {
            var cargoReservation = await _serviceOrderWithDetails.GetById<Model.CargoReservation>(_id);
            int id = cargoReservation.FreightID.GetValueOrDefault();
            request.Accepted = false;
            request.Finished = null;
            request.FreightID = null;
            request.ExtraServicesID = null;
            cargoReservation = await _serviceOrderWithDetails.Update<Model.CargoReservation>(_id, request);
            var freightReservation= await _serviceFreight.Delete<Model.Freight>(id);
            if (freightReservation != null)
            {
                MessageBox.Show("Succesfully declined!");
                this.Close();
                _navigation.Pop();
            }
        }
    }
}
