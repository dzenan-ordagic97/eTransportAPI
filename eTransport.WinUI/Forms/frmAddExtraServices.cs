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
    public partial class frmAddExtraServices : Form,SendData
    {
        private readonly APIService _serviceExtraServices = new APIService("ExtraServices");
        private SendData _sendData;
        private int ExtraServicesID = 0;
        private Model.Requests.ExtraServicesInsertRequest _extraServicesToSave;

        Regex regexLetters = new Regex(@"^[a-zA-Z\s]*$");

        public frmAddExtraServices()
        {
            InitializeComponent();
            _sendData = this;
            getExtraServices();
            _extraServicesToSave = new Model.Requests.ExtraServicesInsertRequest();
        }
        private void frmAddExtraServices_Load(object sender, EventArgs e)
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
        private async void getExtraServices()
        {
            ExtraServicesID = 0;
            txtPrice.Text = "";
            txtServiceName.Text = "";
            richTxtDescription.Text = "";
            var extraServices = await _serviceExtraServices.Get<List<Model.ExtraServices>>(null);
            _flowLayout.Controls.Clear();
            if (extraServices != null)
            {
                foreach (var item in extraServices)
                {
                    OneEditExtraServices o = new OneEditExtraServices(item, this);
                    _flowLayout.Controls.Add(o);
                }
            }
           
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(txtServiceName.Text=="" || !regexLetters.IsMatch(txtServiceName.Text))
            {
                MessageBox.Show("Please enter a valid value for service name! (Only letters)");
                return;
            }
            if(txtPrice.Text == string.Empty || Regex.IsMatch(txtPrice.Text, "[^0.0-9.0]"))
            {
                MessageBox.Show("Please enter a valid value for price! (Only numbers and no space)");
                return;
            }
            if(richTxtDescription.Text=="" || !regexLetters.IsMatch(richTxtDescription.Text))
            {
                MessageBox.Show("Please enter a valid description! (Only letters)");
                return;
            }
            _extraServicesToSave.Name = txtServiceName.Text;
            _extraServicesToSave.Price = decimal.Parse(txtPrice.Text);
            _extraServicesToSave.Description = richTxtDescription.Text;
            if(ExtraServicesID>0)
            {
                var extraServices =  _serviceExtraServices.Update<Model.ExtraServices>(ExtraServicesID, _extraServicesToSave);
                if (extraServices != null)
                {
                    MessageBox.Show("Succesfuly updated", "Extra services", MessageBoxButtons.OK);
                    getExtraServices();
                }
            }
            else
            {
                var extraServices =  _serviceExtraServices.Insert<Model.ExtraServices>(_extraServicesToSave);
                if (extraServices != null)
                {
                    MessageBox.Show("Succesfuly saved", "Extra services", MessageBoxButtons.OK);
                    getExtraServices();
                }
            }
        }
        public void Send(object data)
        {
            if(data==null)
            {
                getExtraServices();
                return;
            }
            if (data.GetType() == typeof(Model.ExtraServices))
            {
                var item = data as Model.ExtraServices;
                ExtraServicesID = item.ExtraServicesID;
                txtServiceName.Text = item.Name;
                txtPrice.Text = item.Price.ToString();
                richTxtDescription.Text = item.Description;
                
            }
        }
    }
}
