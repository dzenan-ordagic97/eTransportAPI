using eTransport.WinUI.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eTransport.WinUI.Forms
{
    public partial class frmAddCountry : Form, SendData
    {
        private readonly APIService _serviceCountry = new APIService("Country");
        private SendData _sendData;
        private int CountryID = 0;
        private Model.Requests.CountryInsertRequest _countryToSave;
        Regex regexLetters = new Regex(@"^[a-zA-Z\s]*$");

        public frmAddCountry()
        {
            InitializeComponent();
            _sendData = this;
            getCountries();
            _countryToSave = new Model.Requests.CountryInsertRequest();
        }
        private async void getCountries()
        {
            CountryID = 0;
            txtCountryName.Text = "";
            txtAcronym.Text = "";
            var countries = await _serviceCountry.Get<List<Model.Country>>(null);
            _flowLayout.Controls.Clear();
            if (countries != null)
            {
                foreach (var item in countries)
                {
                    OneEditCountry o = new OneEditCountry(item, this);
                    _flowLayout.Controls.Add(o);
                }
            }
        }
        public void Send(object data)
        {
            if (data == null)
            {
                getCountries();
                return;
            }
            if (data.GetType() == typeof(Model.Country))
            {
                var item = data as Model.Country;
                txtCountryName.Text = item.Name;
                txtAcronym.Text = item.Acronym;
                CountryID = item.CountryID;
            }
        }
        private async void btnAdd_Click(object sender, EventArgs e)
        {
            var countriesCheck = await _serviceCountry.Get<List<Model.Country>>(null);
            foreach (var item in countriesCheck)
            {
                if (item.Name == txtCountryName.Text && item.Acronym == txtAcronym.Text)
                {
                    MessageBox.Show("That country exists! Please enter another or update with new values!");
                    return;
                }
            }
            if (txtCountryName.Text == "" || !regexLetters.IsMatch(txtCountryName.Text))
            {
                MessageBox.Show("Please enter a valid name for country! (Only letters)");
                return;
            }
            if (txtAcronym.Text == "" || !regexLetters.IsMatch(txtAcronym.Text))
            {
                MessageBox.Show("Please enter a valid name for acronym! (Only letters)");
                return;
            }
            _countryToSave.Name = txtCountryName.Text;
            _countryToSave.Acronym = txtAcronym.Text;
            if (CountryID > 0)
            {
                var countries = _serviceCountry.Update<Model.Country>(CountryID, _countryToSave);
                if (countries != null)
                {
                    MessageBox.Show("Succesfuly updated", "Countries", MessageBoxButtons.OK);
                    getCountries();
                }
            }
            else
            {
                var countries = _serviceCountry.Insert<Model.Country>(_countryToSave);
                if (countries != null)
                {
                    MessageBox.Show("Succesfuly saved", "Countries", MessageBoxButtons.OK);
                    getCountries();
                }
            }
        }
        private void frmAddCountry_Load(object sender, EventArgs e)
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
    }
}
