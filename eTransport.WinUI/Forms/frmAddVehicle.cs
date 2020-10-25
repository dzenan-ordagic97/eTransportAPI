using eTransport.Model;
using eTransport.Model.Requests;
using eTransport.WinUI.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eTransport.WinUI.Forms
{
    public interface SendData
    {
        void Send(Object data);
    }
    public partial class frmAddVehicle : Form,SendData
    {
        private SendData _sendData;
        private List<Model.VehicleType> _vehicleType;
        private List<Model.VehicleModel> _vehicleModel;
        private readonly APIService _serviceVehicleType = new APIService("VehicleType");
        private readonly APIService _serviceVehicleModel = new APIService("VehicleModel");
        private readonly APIService _serviceVehicleDetails = new APIService("VehicleDetails");
        private readonly APIService _serviceVehicle = new APIService("Vehicle");
        private Model.Requests.VehicleInsertRequest _vehicleToSave;
        private INavigation _navigation;
        Regex regexLettersNumbers = new Regex(@"^[a-zA-Z0-9\s]*$");
        Regex regexNumbers = new Regex(@"^[0-9]*$");



        public frmAddVehicle()
        {
            _vehicleType = new List<VehicleType>();
            _vehicleModel = new List<VehicleModel>();
            InitializeComponent();
            getVehicleType();
            getVehicleModel();
            _sendData = this;
            _vehicleToSave = new Model.Requests.VehicleInsertRequest();
        }
        public frmAddVehicle(INavigation navigation)
        {
            _vehicleType = new List<VehicleType>();
            _vehicleModel = new List<VehicleModel>();
            InitializeComponent();
            getVehicleType();
            getVehicleModel();
            _sendData = this;
            _vehicleToSave = new Model.Requests.VehicleInsertRequest();
            this._navigation = navigation;
        }
        private async void getVehicleType()
        {
            _vehicleType.AddRange(await _serviceVehicleType.Get<List<Model.VehicleType>>(null));
            cBVehicleType.DataSource = _vehicleType;
            cBVehicleType.DisplayMember = "Name";
            cBVehicleType.ValueMember = "VehicleTypeID";
        }
        private async void getVehicleModel()
        {
            _vehicleModel.AddRange(await _serviceVehicleModel.Get<List<Model.VehicleModel>>(null));
            cBVehicleModel.DataSource = _vehicleModel;
            cBVehicleModel.DisplayMember = "Name";
            cBVehicleModel.ValueMember = "VehicleModelID";
        }
        public void Send(object data)
        {
            if (data is Model.VehicleDetails)
            {
                _vehicleToSave.Details = data as Model.VehicleDetails;
                txtHeight.Text = _vehicleToSave.Details.MaxHeight.ToString();
                txtLength.Text = _vehicleToSave.Details.MaxLength.ToString();
                txtWeight.Text = _vehicleToSave.Details.MaxWeight.ToString();
                txtWidth.Text = _vehicleToSave.Details.MaxWidth.ToString();
                txtPrice.Text = _vehicleToSave.Details.Price_per_km.ToString();
                richTxtDescription.Text = _vehicleToSave.Details.Description.ToString();
                panel2.Visible = true;
                btn_save_top.Visible = false;
                btnSaveVehicle.Visible = true;
            }
            if(data.GetType()==typeof(Model.VehicleType))
            {
                _vehicleType.Add((Model.VehicleType)data);
                cBVehicleType.DataSource = null;
                cBVehicleType.Items.Clear();
                cBVehicleType.DataSource = _vehicleType;
                cBVehicleType.DisplayMember = "Name";
                cBVehicleType.ValueMember = "VehicleTypeID";
            }
            if (data.GetType() == typeof(Model.VehicleModel))
            {
                _vehicleModel.Add((Model.VehicleModel)data);
                cBVehicleModel.DataSource = null;
                cBVehicleModel.Items.Clear();
                cBVehicleModel.DataSource = _vehicleModel;
                cBVehicleModel.DisplayMember = "Name";
                cBVehicleModel.ValueMember = "VehicleModelID";
            }
           
        }
        private void frmAddVehicle_Load(object sender, EventArgs e)
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
        private  void btnSaveVehicle_Click(object sender, EventArgs e)
        {
            if (cBVehicleType.SelectedItem == null)
            {
                MessageBox.Show("Please choose a valid value for vehicle type!");
                return;
            }
            if (cBVehicleModel.SelectedItem == null)
            {
                MessageBox.Show("Please choose a valid value for vehicle model!");
                return;
            }
            if (txtBoxLicencePlate.Text == string.Empty || !regexLettersNumbers.IsMatch(txtBoxLicencePlate.Text))
            {
                MessageBox.Show("Please enter a valid value for licence plate! (Letters and numbers only)");
                return;
            }
            if (txtBoxSeat.Text == string.Empty || !regexNumbers.IsMatch(txtBoxSeat.Text))
            {
                MessageBox.Show("Please enter a valid value for seat capacity! (Numbers only and no space)");
                return;
            }
            if (txtBoxTrunk.Text == string.Empty || !regexNumbers.IsMatch(txtBoxTrunk.Text))
            {
                MessageBox.Show("Please enter a valid value for trunk volume! (Numbers only and no space)");
                return;
            }
            if (txtBoxYear.Text == string.Empty)
            {
                MessageBox.Show("Please choose a valid value for year of manufacture!");
                return;
            }
            saveToDb();
        }
        private async void saveToDb()
        {
            _vehicleToSave.LicencePlate = txtBoxLicencePlate.Text;
            _vehicleToSave.SeatingCapacity = int.Parse(txtBoxSeat.Text);
            _vehicleToSave.TrunkVolume = double.Parse(txtBoxTrunk.Text);
            _vehicleToSave.YearOfManufacture = txtBoxYear.Value;
            _vehicleToSave.VehicleTypeID = ((Model.VehicleType)cBVehicleType.SelectedItem).VehicleTypeID;
            _vehicleToSave.VehicleModelID = ((Model.VehicleModel)cBVehicleModel.SelectedItem).VehicleModelID;

            var data = await _serviceVehicle.Insert<Model.Vehicle>(_vehicleToSave);

            if (data != null)
            {
                   MessageBox.Show("Succesfuly saved", "Vehicle", MessageBoxButtons.OK);
                _navigation.Pop();
            }

        }
        private void btnVehicleDetails_Click(object sender, EventArgs e)
        {
            frmAddVehicleDetails childForm = new frmAddVehicleDetails(_sendData);
            childForm.BringToFront();
            childForm.Show();
        }
        private void btn_save_top_Click(object sender, EventArgs e)
        {
            if (pBVehicle.Image== null)
            {
                MessageBox.Show("Please upload a valid image for your vehicle!");
                return;
            }
            if (cBVehicleType.SelectedItem==null)
            {
                MessageBox.Show("Please choose a valid value for vehicle type!");
                return;
            }
            if(cBVehicleModel.SelectedItem==null)
            {
                MessageBox.Show("Please choose a valid value for vehicle model!");
                return;
            }
            if(txtBoxLicencePlate.Text==string.Empty || !regexLettersNumbers.IsMatch(txtBoxLicencePlate.Text))
            {
                MessageBox.Show("Please enter a valid value for licence plate! (Letters and numbers only)");
                return;
            }
            if (txtBoxSeat.Text == string.Empty || !regexNumbers.IsMatch(txtBoxSeat.Text))
            {
                MessageBox.Show("Please enter a valid value for seat capacity! (Numbers only and no space)");
                return;
            }
            if (txtBoxTrunk.Text == string.Empty || !regexNumbers.IsMatch(txtBoxTrunk.Text))
            {
                MessageBox.Show("Please enter a valid value for trunk volume! (Numbers only and no space)");
                return;
            }
            if (txtBoxYear.Text == string.Empty)
            {
                MessageBox.Show("Please choose a valid value for year of manufacture!");
                return;
            }
            saveToDb();
        }
        private void btnRemove_Click(object sender, EventArgs e)
        {
            _vehicleToSave.Details = null;
            txtHeight.Text = "";
            txtLength.Text = "";
            txtWeight.Text = "";
            txtWidth.Text = "";
            txtPrice.Text = "";
            richTxtDescription.Text = "";
            panel2.Visible = false;
            btn_save_top.Visible = true;
            btnSaveVehicle.Visible = false;
        }
        private void pBVehicle_Click(object sender, EventArgs e)
        {
            var image = Helpers.PictureHelper.loadImageFromDocument();
            _vehicleToSave.Image = image;
            pBVehicle.Image = Helpers.PictureHelper.byteArrayToImage(image);
        }
        private void btnAddVehicleType_Click(object sender, EventArgs e)
        {
            frmAddVehicleType childForm = new frmAddVehicleType(_sendData);
            childForm.BringToFront();
            childForm.Show();
        }
        private void btnVehicleModel_Click(object sender, EventArgs e)
        {
            frmAddVehicleModel childForm = new frmAddVehicleModel(_sendData);
            childForm.BringToFront();
            childForm.Show();
        }
    }
}
