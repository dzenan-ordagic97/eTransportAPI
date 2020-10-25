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
    public partial class frmRegister : Form
    {
        private readonly APIService _service = new APIService("Users/Auth/Register");
        private readonly APIService _serviceUser = new APIService("Users");
        private readonly APIService _serviceCountry = new APIService("Country");
        private readonly APIService _serviceCity = new APIService("City");
        private List<Model.Country> _country;
        private List<Model.City> _city;
        private Model.Requests.ApplicationUserCreateRequest _userToSave;
        private Model.Requests.CitySearchRequest _citySearch;
        Regex regex = new Regex("^(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-+]).{6,}$");
        Regex regexEmail = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        Regex regexLetters = new Regex(@"^[a-zA-Z\s]*$");
        Regex regexLettersNumbers = new Regex(@"^[a-zA-Z0-9\s]*$");
        Regex regexLettersAddress = new Regex(@"^[a-zA-Z0-9\s]*$");
        Regex regexNumbers = new Regex(@"^[0-9]*$");
        Regex regexNumbersTelephone = new Regex(@"^[0-9\-]*$");

        public frmRegister()
        {
            InitializeComponent();
            _userToSave = new Model.Requests.ApplicationUserCreateRequest();
            _userToSave.Carrier = new Model.Requests.CarrierInsertRequest();
            _citySearch = new Model.Requests.CitySearchRequest();
            _country = new List<Model.Country>();
            _city = new List<Model.City>();
            getCountry();
        }
        private async void getCountry()
        {
            _country.AddRange(await _serviceCountry.Get<List<Model.Country>>(null));
            cBCountry.DataSource = _country;
            cBCountry.DisplayMember = "Name";
            cBCountry.ValueMember = "CountryID";
        }
        private async void btnRegister_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text == "" || !regexEmail.IsMatch(txtEmail.Text))
            {
                MessageBox.Show("Please enter valid email! (Example: something@gmail.com)");
                return;
            }
            if (txtPassword.Text == "")
            {
                MessageBox.Show("Please enter a valid password! (Minimum 6 chars, one number, one uppercase and one special char)");
                return;
            }
            if(!regex.IsMatch(txtPassword.Text))
            {
                MessageBox.Show("Invalid password (Minimum 6 chars, one number, one uppercase and one special char)!");
                return;
            }
            if(txtCarrierName.Text=="" || !regexLetters.IsMatch(txtCarrierName.Text))
            {
                MessageBox.Show("Please enter a valid carrier name! (Only letters)");
                return;
            }
            if(txtBusinessMail.Text=="" || !regexEmail.IsMatch(txtBusinessMail.Text))
            {
                MessageBox.Show("Please enter valid business email! (Example: something@gmail.com)");
                return;
            }
            if(txtDriverLicence.Text=="" || !regexLettersNumbers.IsMatch(txtDriverLicence.Text))
            {
                MessageBox.Show("Please enter a valid driver licence! (Only letters and numbers)");
                return;
            }
            if(txtBusinessNumber.Text=="" || !regexNumbersTelephone.IsMatch(txtBusinessNumber.Text))
            {
                MessageBox.Show("Please enter a valid business number! (Only numbers with optional '-' between them)");
                return;
            }
            if(cBCity.SelectedItem==null)
            {
                MessageBox.Show("Please choose a valid city!");
                return;
            }
            if(txtAddress.Text=="" || !regexLettersAddress.IsMatch(txtAddress.Text))
            {
                MessageBox.Show("Please enter a valid address name! (Only letters and numbers)");
                return;
            }
            _userToSave.Email = txtEmail.Text;
            _userToSave.Password = txtPassword.Text;

            _userToSave.Carrier.BusinessNumber = txtBusinessNumber.Text;
            _userToSave.Carrier.CarrierBusinessEmail = txtBusinessMail.Text;
            _userToSave.Carrier.CarrierName = txtCarrierName.Text;
            _userToSave.Carrier.DriverLicenceNumber = txtDriverLicence.Text;
            _userToSave.Address = new Address()
            {
                CityID = ((Model.City)cBCity.SelectedItem).CityID,
                Name = txtAddress.Text
            };

            if (_userToSave.Carrier.Image == null)
            {
                _userToSave.Carrier.Image = PictureHelper.imageToByteArray(Properties.Resources.placeholder);
            }
            else
            {
                _userToSave.Carrier.Image = PictureHelper.imageToByteArray(pBCarrier.Image);
            }
            var result = await _serviceUser.Get<List<Model.User>>(null);
            foreach(var item in result)
            {
                if(item.Email==_userToSave.Email)
                {
                    MessageBox.Show("You are already registered! Please login!");
                    this.Close();
                    frmLogin frmLogin = new frmLogin();
                    frmLogin.Show();
                }
            }
            var data = await _service.Insert<Model.User>(_userToSave);
            if (data != null)
            {
                MessageBox.Show("Succesfuly registered", "User", MessageBoxButtons.OK);
                this.Close();
                frmLogin frmLogin = new frmLogin();
                frmLogin.Show();
            }
        }
        private void pBCarrier_Click(object sender, EventArgs e)
        {
            var image = Helpers.PictureHelper.loadImageFromDocument();
            _userToSave.Carrier.Image = image;
            pBCarrier.Image = Helpers.PictureHelper.byteArrayToImage(image);
        }
        private async void cBCountry_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cBCity.DataSource = null;
            cBCity.Items.Clear();
            _city.Clear();
            _citySearch.CountryID = ((Model.Country)cBCountry.SelectedItem).CountryID;
            _city.AddRange(await _serviceCity.Get<List<Model.City>>(_citySearch));
            cBCity.DataSource = _city;
            cBCity.DisplayMember = "Name";
            cBCity.ValueMember = "CityID";
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            frmLogin frmLogin = new frmLogin();
            frmLogin.Show();

        }
    }
}
