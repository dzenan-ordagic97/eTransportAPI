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
    public partial class frmAddCity : Form, SendData
    {
        private readonly APIService _serviceCountry = new APIService("Country");
        private readonly APIService _serviceCity = new APIService("City");
        private List<Model.Country> _country;
        private SendData _sendData;
        private int CityID = 0;
        private Model.Requests.CityInsertRequest _cityToSave;
        private Model.Requests.CitySearchRequest _citySearch;
        Regex regexLetters = new Regex(@"^[a-zA-Z\s]*$");
        Regex regexNumbers = new Regex(@"^[0-9]*$");
        public frmAddCity()
        {
            InitializeComponent();
            _sendData = this;
            //getCities();
            _cityToSave = new Model.Requests.CityInsertRequest();
            _citySearch = new Model.Requests.CitySearchRequest();
            _country = new List<Model.Country>();
            getCountries();
        }
        private async void getCountries()
        {
            _country.AddRange(await _serviceCountry.Get<List<Model.Country>>(null));
            cBCountry.DataSource = _country;
            cBCountry.DisplayMember = "Name";
            cBCountry.ValueMember = "CountryID";
        }
        private async void getCities()
        {
            CityID = 0;
            txtCityName.Text = "";
            txtPostal.Text = "";
            _citySearch.CountryID = ((Model.Country)cBCountry.SelectedItem).CountryID;
            var cities = await _serviceCity.Get<List<Model.City>>(_citySearch);
            _flowLayout.Controls.Clear();
            if (cities != null)
            {
                foreach (var item in cities)
                {
                    OneEditCity o = new OneEditCity(item, this);
                    _flowLayout.Controls.Add(o);
                }
            }
        }
        private async void btnAdd_Click(object sender, EventArgs e)
        {
            _citySearch.CountryID = ((Model.Country)cBCountry.SelectedItem).CountryID;
            var citiesCheck = await _serviceCity.Get<List<Model.City>>(_citySearch);
            foreach(var item in citiesCheck)
            {
                if(item.Name==txtCityName.Text && item.PostalNumber==txtPostal.Text)
                {
                    MessageBox.Show("That city exists! Please enter another or update with new values!");
                    return;
                }
            }
            if (cBCountry.SelectedItem == null)
            {
                MessageBox.Show("Please choose a valid value for city!");
                return;
            }
            if (txtCityName.Text == "" || !regexLetters.IsMatch(txtCityName.Text))
            {
                MessageBox.Show("Please enter a valid name for city (Only letters)!");
                return;
            }
            if (txtPostal.Text == "" || !regexNumbers.IsMatch(txtPostal.Text))
            {
                MessageBox.Show("Please enter a valid postal number for city! (Only numbers and no space)");
                return;
            }
            _cityToSave.Name = txtCityName.Text;
            _cityToSave.PostalNumber = txtPostal.Text;
            _cityToSave.CountryID = ((Model.Country)cBCountry.SelectedItem).CountryID;
            if (CityID > 0)
            {
                var cities = await _serviceCity.Update<Model.City>(CityID, _cityToSave);
                if (cities != null)
                {
                    MessageBox.Show("Succesfuly updated", "Cities", MessageBoxButtons.OK);
                    getCities();
                }
            }
            else
            {
                var cities = await _serviceCity.Insert<Model.City>(_cityToSave);
                if (cities != null)
                {
                    MessageBox.Show("Succesfuly saved", "Cities", MessageBoxButtons.OK);
                    getCities();
                }
            }
        }
        public void Send(object data)
        {
            if (data == null)
            {
                getCities();
                return;
            }
            if (data.GetType() == typeof(Model.City))
            {
                var item = data as Model.City;
                txtCityName.Text = item.Name;
                txtPostal.Text = item.PostalNumber;
                CityID = item.CityID;
            }
        }
        private void frmAddCity_Load(object sender, EventArgs e)
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
        private async void cBCountry_SelectionChangeCommitted(object sender, EventArgs e)
        {
            _citySearch.CountryID= ((Model.Country)cBCountry.SelectedItem).CountryID;
            var cities = await _serviceCity.Get<List<Model.City>>(_citySearch);
            _flowLayout.Controls.Clear();
            if (cities != null)
            {
                foreach (var item in cities)
                {
                    OneEditCity o = new OneEditCity(item, this);
                    _flowLayout.Controls.Add(o);
                }
            }
        }
    }
}
