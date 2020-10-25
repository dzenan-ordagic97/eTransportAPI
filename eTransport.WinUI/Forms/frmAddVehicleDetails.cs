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
    public partial class frmAddVehicleDetails : Form
    {
        private readonly APIService _serviceVehicleDetails = new APIService("VehicleDetails");
        private readonly SendData _sendData;
        Regex regexNumbers = new Regex(@"^[0-9]*$");
        Regex regexNumbersPrice = new Regex(@"^[0.0-9.0]*$");
        Regex regexLettersNumbers = new Regex(@"^[a-zA-Z0-9\s]*$");

        public frmAddVehicleDetails(SendData _sendData)
        {
            InitializeComponent();
            this._sendData = _sendData;
        }

        private void frmAddVehicleDetails_Load(object sender, EventArgs e)
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
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtHeight.Text == "" || !regexNumbers.IsMatch(txtHeight.Text))
            {
                MessageBox.Show("Please enter a valid value for height (Only numbers and no space)!");
                return;
            }
            if (txtWeight.Text == "" || !regexNumbers.IsMatch(txtWeight.Text))
            {
                MessageBox.Show("Please enter a valid value for weight (Only numbers and no space)!");
                return;
            }
            if (txtLength.Text == "" || !regexNumbers.IsMatch(txtLength.Text))
            {
                MessageBox.Show("Please enter a valid value for lenght (Only numbers and no space)!");
                return;
            }
            if (txtWidth.Text == "" || !regexNumbers.IsMatch(txtWidth.Text))
            {
                MessageBox.Show("Please enter a valid value for width (Only numbers and no space)!");
                return;
            }
            if (txtPrice.Text == "" || !regexNumbersPrice.IsMatch(txtPrice.Text))
            {
                MessageBox.Show("Please enter a valid value for price (Only numbers and no space)!");
                return;
            }
            if (!regexLettersNumbers.IsMatch(richTxtDescription.Text))
            {
                MessageBox.Show("No special characters for description!");
                return;
            }
            try
            {
                var model = new Model.VehicleDetails()
                {
                    MaxHeight = double.Parse(txtHeight.Text),
                    MaxLength = double.Parse(txtLength.Text),
                    MaxWeight = double.Parse(txtWeight.Text),
                    MaxWidth = double.Parse(txtWidth.Text),
                    Price_per_km = decimal.Parse(txtPrice.Text),
                    Description = richTxtDescription.Text
                };

                _sendData.Send(model);
                this.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Vehicle details", MessageBoxButtons.OK);
            }
        }
    }
}
