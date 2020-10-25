using eTransport.WinUI.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eTransport.WinUI.Forms
{

    public partial class frmLogin : Form
    {
        private readonly APIService _service = new APIService("Users/Auth");
        public frmLogin()
        {
            InitializeComponent();
            _error.Visible = false;
            if(Properties.Settings.Default.Email!=string.Empty)
            {
                txtEmail.Text = Properties.Settings.Default.Email;
                txtPassword.Text = Properties.Settings.Default.Password;
                cbRememberMe.Checked = true;
            }

        }
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtEmail_Enter(object sender, EventArgs e)
        {
            if (txtEmail.Text== "yourMail@gmail.com")
  {
                txtEmail.Text="";
                txtEmail.ForeColor=Color.LightGray;
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (txtEmail.Text == "")
            {
                txtEmail.Text = "yourMail@gmail.com";
                txtEmail.ForeColor = Color.Silver;
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Your password")
            {
                txtPassword.Text = "";
                txtPassword.ForeColor = Color.LightGray;
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                txtPassword.Text = "Your password";
                txtPassword.ForeColor = Color.Silver;
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            btnLogin.Enabled = false;
            var email = txtEmail.Text;
            var pass = txtPassword.Text;
            try
            {
                var user = await _service.Auth<Model.User>(email, pass);
                if (!String.IsNullOrEmpty(user.Token))
                {
                    APIService.Session.ImePrezime = user.FirstName + " " + user.LastName;
                    APIService.Session.JWT = user.Token;
                    if(cbRememberMe.Checked)
                    {
                        saveData();
                    }
                    var handler = new JwtSecurityTokenHandler();
                    var jsonToken = handler.ReadJwtToken(user.Token);
                   
                    if (jsonToken.ValidTo.ToLocalTime().CompareTo(DateTime.Now.ToLocalTime()) < 1)
                    {

                        APIService.Session.JWT = "";
                        APIService.Session.Role = null;
                        return;
                    }

                    APIService.Session.ImePrezime = user.FirstName + " " + user.LastName;
                    APIService.Session.Role = new List<string>();
                    
                    foreach (var claim in jsonToken.Claims)
                    {
                        if (claim.Type.Equals("role"))
                        {
                            APIService.Session.Role.Add(claim.Value);
                        }

                    }
                    if (APIService.Session.Role.Contains(Model.Helpers.Role.Carrier) || APIService.Session.Role.Contains(Model.Helpers.Role.Admin))
                    {
                        this.Hide();
                        frmMenu f = new frmMenu();
                        f.ShowDialog();
                        this.Close();
                    }else
                    {
                        _error.Visible = true;
                        _error.Text = "Dont have permitions!";
                        btnLogin.Enabled = true;
                    }
                    
                }
            }
            catch (Exception err)
            {
                _error.Visible = true;
                _error.Text = err.Message;
                btnLogin.Enabled = true;
            }
        }

        private void frmLogin_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        private void saveData()
        {
            Properties.Settings.Default.Email = txtEmail.Text;
            Properties.Settings.Default.Password = txtPassword.Text;
            Properties.Settings.Default.Save();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            frmRegister frmRegister = new frmRegister();
            frmRegister.Show();
            this.Hide();
        }
    }
}
