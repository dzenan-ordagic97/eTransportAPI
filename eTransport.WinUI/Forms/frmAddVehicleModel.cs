using eTransport.WinUI.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eTransport.WinUI.Forms
{
    public partial class frmAddVehicleModel : Form
    {
        private readonly APIService _serviceVehicleModel = new APIService("VehicleModel");
        private readonly SendData _sendData;
        Regex regexLetters = new Regex(@"^[a-zA-Z\s]*$");

        public frmAddVehicleModel(SendData send)
        {
            InitializeComponent();
            _sendData = send;
        }
        private void frmAddVehicleModel_Load(object sender, EventArgs e)
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
        private async void btnAdd_Click(object sender, EventArgs e)
        {
            var vehicleModels = await _serviceVehicleModel.Get<List<Model.VehicleType>>(null);
            foreach (var item in vehicleModels)
            {
                if (item.Name == txtVehicleModel.Text)
                {
                    MessageBox.Show("That model already exists!");
                    return;
                }
            }
            if (txtVehicleModel.Text=="" || !regexLetters.IsMatch(txtVehicleModel.Text))
            {
                MessageBox.Show("Please enter a valid string for vehicle model (Only letters)!");
                return;
            }
            try
            {
                var vehicleModel = await _serviceVehicleModel.Insert<Model.VehicleModel>(new Model.VehicleModel()
                {
                    Name = txtVehicleModel.Text,
                });
                if (vehicleModel != null)
                {
                    MessageBox.Show("Succesfuly saved", "Vehicle model", MessageBoxButtons.OK);
                    _sendData.Send(vehicleModel);
                    this.Close();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Vehicle model", MessageBoxButtons.OK);
            }
        }
    }
}
