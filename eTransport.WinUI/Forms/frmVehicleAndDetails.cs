using eTransport.Model;
using eTransport.WinUI.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eTransport.WinUI.Forms
{
    public partial class frmVehicleAndDetails : Form
    {
        private readonly APIService _serviceVehicleDetails = new APIService("Vehicle");
        private readonly APIService _serviceFreight = new APIService("Freight");
        private readonly APIService _serviceVehicleType = new APIService("VehicleType");
        private readonly APIService _serviceVehicleModel = new APIService("VehicleModel");
        private List<Model.VehicleType> _vehicleType;
        private List<Model.VehicleModel> _vehicleModel;
        private readonly INavigation _navigation;
        private Model.Requests.VehicleInsertRequest vehicleRequest;
        Regex regexLettersNumbers = new Regex(@"^[a-zA-Z0-9\s]*$");
        public bool trigger = false;
        private int _id = 0;
        public frmVehicleAndDetails(INavigation navigation)
        {
            InitializeComponent();
            _navigation = navigation;
            _vehicleType = new List<VehicleType>();
            _vehicleModel = new List<VehicleModel>();
            vehicleRequest = new Model.Requests.VehicleInsertRequest();

        }
        public frmVehicleAndDetails(int id, INavigation navigation)
        {
            InitializeComponent();
            _id = id;
            _navigation = navigation;
            _vehicleType = new List<VehicleType>();
            _vehicleModel = new List<VehicleModel>();
            vehicleRequest = new Model.Requests.VehicleInsertRequest();

        }
        private async void getVehicleType()
        {
            _vehicleType.AddRange(await _serviceVehicleType.Get<List<Model.VehicleType>>(null));
            comboBoxType.DataSource = _vehicleType;
            comboBoxType.DisplayMember = "Name";
            comboBoxType.ValueMember = "VehicleTypeID";
        }
        private async void getVehicleModel()
        {
            _vehicleModel.AddRange(await _serviceVehicleModel.Get<List<Model.VehicleModel>>(null));
            comboBoxModel.DataSource = _vehicleModel;
            comboBoxModel.DisplayMember = "Name";
            comboBoxModel.ValueMember = "VehicleModelID";
        }


        private async void frmVehicleAndDetails_Load(object sender, EventArgs e)
        {
            LoadTheme();
            var vehicle = await _serviceVehicleDetails.GetById<Model.Vehicle>(_id);
            txtVehicleModel.Text = vehicle.VehicleModel;
            txtVehicleType.Text = vehicle.VehicleType;
            txtLicencePlate.Text = vehicle.LicencePlate;
            txtSeating.Text = vehicle.SeatingCapacity.ToString();
            txtTrunk.Text = vehicle.TrunkVolume.ToString();
            txtYear.Text = vehicle.YearOfManufacture.ToString();
            if (vehicle.Image.Length == 0)
            {
                vehicle.Image = PictureHelper.imageToByteArray(Properties.Resources.delivery);
            }
            pBVehicle.Image = PictureHelper.byteArrayToImage(vehicle.Image);
            if (vehicle.VehicleDetails != null)
            {
                txtHeight.Text = vehicle.VehicleDetails.MaxHeight.ToString();
                txtWidth.Text = vehicle.VehicleDetails.MaxWidth.ToString();
                txtWeight.Text = vehicle.VehicleDetails.MaxWeight.ToString();
                txtLength.Text = vehicle.VehicleDetails.MaxLength.ToString();
                txtPrice.Text = vehicle.VehicleDetails.Price_per_km.ToString();
                richTxtDescription.Text = vehicle.VehicleDetails.Description;
            }
            else
            {
                txtHeight.Text = "0";
                txtWidth.Text = "0";
                txtWeight.Text = "0";
                txtLength.Text = "0";
                txtPrice.Text = "0.0";
                richTxtDescription.Text = "";
            }
            var freights = await _serviceFreight.Get<List<Model.Freight>>(null);
            foreach (var item in freights)
            {
                if (item.VehicleID == vehicle.VehicleID)
                {
                    trigger = true;
                }
            }
            if (trigger == true)
            {
                btnDelete.Enabled = false;
            }
            else
            {
                btnDelete.Enabled = true;
            }

        }


        private async void btnDelete_Click(object sender, EventArgs e)
        {
            await _serviceVehicleDetails.Delete<Model.Vehicle>(_id);
            MessageBox.Show("Succesful delete!");
            this.Close();
            _navigation.Pop();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //Visibility
            btnEdit.Visible = false;
            lblPictureUpdate.Visible = true;
            btnSave.Visible = true;
            txtYear.Visible = false;
            dtmYear.Visible = true;
            comboBoxModel.Visible = true;
            comboBoxType.Visible = true;
            txtVehicleModel.Visible = false;
            txtVehicleType.Visible = false;
            btnDelete.Enabled = false;
            pBVehicle.Enabled = true;

            txtLicencePlate.ReadOnly = false;
            txtSeating.ReadOnly = false;
            txtTrunk.ReadOnly = false;
            txtHeight.ReadOnly = false;
            txtWeight.ReadOnly = false;
            txtWidth.ReadOnly = false;
            txtLength.ReadOnly = false;
            txtPrice.ReadOnly = false;
            richTxtDescription.ReadOnly = false;

            getVehicleType();
            getVehicleModel();

        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (txtLicencePlate.Text == string.Empty || !regexLettersNumbers.IsMatch(txtLicencePlate.Text))
            {
                MessageBox.Show("Please enter a valid value for licence plate! (Only letters and numbers)");
                return;
            }
            if (txtSeating.Text == string.Empty || Regex.IsMatch(txtSeating.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter a valid value for seat capacity! (Only numbers and no space)");
                return;
            }
            if (txtTrunk.Text == string.Empty || Regex.IsMatch(txtTrunk.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter a valid value for trunk volume! (Only numbers and no space)");
                return;
            }
            if (dtmYear.Text == string.Empty)
            {
                MessageBox.Show("Please choose a valid value for year of manufacture!");
                return;
            }
            if (txtHeight.Text == string.Empty || Regex.IsMatch(txtHeight.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter a valid value for height! (Only numbers and no space)");
                return;
            }
            if (txtWeight.Text == string.Empty || Regex.IsMatch(txtWeight.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter a valid value for weight! (Only numbers and no space)");
                return;
            }
            if (txtLength.Text == string.Empty || Regex.IsMatch(txtLength.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter a valid value for length! (Only numbers and no space)");
                return;
            }
            if (txtWidth.Text == string.Empty || Regex.IsMatch(txtWidth.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter a valid value for width! (Only numbers and no space)");
                return;
            }
            if (txtPrice.Text == string.Empty || Regex.IsMatch(txtPrice.Text, "[^0.0-9.0]"))
            {
                MessageBox.Show("Please enter a valid value for price! (Only numbers and no space)");
                return;
            }
            if (!regexLettersNumbers.IsMatch(richTxtDescription.Text))
            {
                MessageBox.Show("No special characters for description!");
                return;
            }



            vehicleRequest.VehicleModelID = ((Model.VehicleModel)comboBoxModel.SelectedItem).VehicleModelID;
            vehicleRequest.VehicleTypeID = ((Model.VehicleType)comboBoxType.SelectedItem).VehicleTypeID;
            //Image = Helpers.PictureHelper.imageToByteArray(pBVehicle.Image),
            vehicleRequest.LicencePlate = txtLicencePlate.Text;
            vehicleRequest.SeatingCapacity = int.Parse(txtSeating.Text);
            vehicleRequest.YearOfManufacture = dtmYear.Value;
            vehicleRequest.TrunkVolume = double.Parse(txtTrunk.Text);
            vehicleRequest.Details = new Model.VehicleDetails()
            {
                Description = richTxtDescription.Text,
                MaxHeight = double.Parse(txtHeight.Text),
                MaxLength = double.Parse(txtLength.Text),
                MaxWeight = double.Parse(txtWeight.Text),
                MaxWidth = double.Parse(txtWidth.Text),
                Price_per_km = decimal.Parse(txtPrice.Text),
            };

            if (pBVehicle.Image == null)
            {
                vehicleRequest.Image = PictureHelper.imageToByteArray(Properties.Resources.delivery);
            }
            else
            {
                vehicleRequest.Image = PictureHelper.imageToByteArray(pBVehicle.Image);
            }
            await _serviceVehicleDetails.Update<Model.Vehicle>(_id, vehicleRequest);
            MessageBox.Show("Succesful update!");
            this.Close();
            _navigation.Pop();
        }

        private void pBVehicle_Click(object sender, EventArgs e)
        {
            var image = Helpers.PictureHelper.loadImageFromDocument();
            vehicleRequest.Image = image;
            pBVehicle.Image = Helpers.PictureHelper.byteArrayToImage(image);
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
