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
    public partial class frmAddVehicleType : Form
    {
        private readonly APIService _serviceVehicleType = new APIService("VehicleType");
        private readonly SendData _sendData;
        Regex regexLetters = new Regex(@"^[a-zA-Z\s]*$");
        public frmAddVehicleType(SendData send)
        {
            InitializeComponent();
            this._sendData = send;
        }
        private void frmAddVehicleType_Load(object sender, EventArgs e)
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
            var vehicleTypes = await _serviceVehicleType.Get<List<Model.VehicleType>>(null);
            foreach(var item in vehicleTypes)
            {
                if(item.Name == txtVehicleType.Text)
                {
                    MessageBox.Show("That type already exists!");
                    return;
                }
            }
            if (txtVehicleType.Text == "" || !regexLetters.IsMatch(txtVehicleType.Text))
            {
                MessageBox.Show("Please enter a valid string for vehicle type (Only letters)!");
                return;
            }
            try
            {
                var vehicleType = await _serviceVehicleType.Insert<Model.VehicleType>(new Model.VehicleType()
                {
                    Name = txtVehicleType.Text,
                }) ;
                if (vehicleType != null)
                {
                    MessageBox.Show("Succesfuly saved", "Vehicle type", MessageBoxButtons.OK);
                    _sendData.Send(vehicleType);
                    this.Close();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Vehicle type", MessageBoxButtons.OK);
            }
        }
    }
}
