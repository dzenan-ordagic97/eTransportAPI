using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Flurl.Http;
using Flurl;
using eTransport.Model.Requests;
using eTransport.WinUI.Helpers;

namespace eTransport.WinUI.Forms
{
    public partial class frmUsers : Form
    {
        private readonly APIService _apiService = new APIService("Users");
        public frmUsers()
        {
            InitializeComponent();
        }
        private async void btnShow_Click(object sender, EventArgs e)
        {
            var search = new UserSearchRequest()
            {
                Username = txtSearch.Text,
            };

            var result = await _apiService.Get<List<Model.User>>(search);
            dgvUsers.AutoGenerateColumns = false;
            dgvUsers.DataSource = result;
            
        }
        private void frmUsers_Load(object sender, EventArgs e)
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
