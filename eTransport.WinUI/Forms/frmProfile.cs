using eTransport.Model.Requests;
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
    public partial class frmProfile : Form
    {
        private readonly APIService _serviceCarrier = new APIService("Carrier");
        private Model.Requests.CarrierInsertRequest _carrierToSave;
        Regex regexLetters = new Regex(@"^[a-zA-Z\s]*$");
        Regex regexLettersNumbers = new Regex(@"^[a-zA-Z0-9]*$");
        Regex regexNumbersProfile = new Regex(@"^[0-9\-]*$");
        Regex regexNumbers = new Regex(@"^[0.0-9.0]*$");
        Regex regexEmail = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

        public frmProfile()
        {
            InitializeComponent();
            _carrierToSave = new CarrierInsertRequest();
        }
        private void frmProfile_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }
        private async void LoadTheme()
        {
            try
            {
                var result = await _serviceCarrier.Get<List<Model.Carrier>>(null);
                txtCarrierName.Text = result[0].CarrierName.ToString();
                txtBusinessMail.Text = result[0].CarrierBusinessEmail.ToString();
                txtBusinessNumber.Text = result[0].BusinessNumber.ToString();
                txtDriverLicence.Text = result[0].DriverLicenceNumber.ToString();
                txtStartupPrice.Text = result[0].StartupPrice.ToString();
                if (result[0].Image.Length==0)
                {
                    result[0].Image = PictureHelper.imageToByteArray(Properties.Resources.delivery);
                }
                pBCarrier.Image = PictureHelper.byteArrayToImage(result[0].Image);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Carrier", MessageBoxButtons.OK);
            }
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            txtCarrierName.ReadOnly = false;
            txtBusinessMail.ReadOnly = false;
            txtBusinessNumber.ReadOnly = false;
            txtDriverLicence.ReadOnly = false;
            txtStartupPrice.ReadOnly = false;
            pBCarrier.Enabled = true;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
            lblPictureUpdate.Visible = true;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (txtCarrierName.Text == "" || !regexLetters.IsMatch(txtCarrierName.Text))
            {
                MessageBox.Show("Please enter a valid value for carrier name! (Only letters)");
                return;
            }
            if (txtBusinessMail.Text == "" || !regexEmail.IsMatch(txtBusinessMail.Text))
            {
                MessageBox.Show("Please ender a valid format for business mail! (Example: something@gmail.com)");
                return;
            }
            if (txtDriverLicence.Text == "" || !regexLettersNumbers.IsMatch(txtDriverLicence.Text))
            {
                MessageBox.Show("Please enter a valid value for driver licence! (Letters and numbers)");
                return;
            }
            if (txtBusinessNumber.Text == "" || !regexNumbersProfile.IsMatch(txtBusinessNumber.Text))
            {
                MessageBox.Show("Please ender a valid value for business number! (Only numbers with optional '-')");
                return;
            }
            if (txtStartupPrice.Text == "" || !regexNumbers.IsMatch(txtStartupPrice.Text))
            {
                MessageBox.Show("Please enter a valid value for startup price! (Only numbers and no space)");
                return;
            }
            _carrierToSave.BusinessNumber = txtBusinessNumber.Text;
            _carrierToSave.CarrierBusinessEmail = txtBusinessMail.Text;
            _carrierToSave.CarrierName = txtCarrierName.Text;
            _carrierToSave.DriverLicenceNumber = txtDriverLicence.Text;
            _carrierToSave.StartupPrice = decimal.Parse(txtStartupPrice.Text);
            if (pBCarrier.Image == null)
            {
                _carrierToSave.Image = PictureHelper.imageToByteArray(Properties.Resources.delivery);
            }
            else
            {
                _carrierToSave.Image = PictureHelper.imageToByteArray(pBCarrier.Image);
            }
            var result = await _serviceCarrier.Get<List<Model.Carrier>>(null);
            var data = await _serviceCarrier.Update<Model.Carrier>(result[0].CarrierID, _carrierToSave);
            if (data != null)
            {
                MessageBox.Show("Succesfuly updated", "Carrier", MessageBoxButtons.OK);
                btnUpdate.Visible = true;
                btnSave.Visible = false;
                lblPictureUpdate.Visible = false;
                txtCarrierName.ReadOnly = true;
                txtBusinessMail.ReadOnly = true;
                txtBusinessNumber.ReadOnly = true;
                txtDriverLicence.ReadOnly = true;
                txtStartupPrice.ReadOnly = true;
                pBCarrier.Enabled = false;
            }
        }

        private void pBCarrier_Click(object sender, EventArgs e)
        {
            var image = Helpers.PictureHelper.loadImageFromDocument();
            _carrierToSave.Image = image;
            pBCarrier.Image = Helpers.PictureHelper.byteArrayToImage(image);
        }

        

        
    }
}
