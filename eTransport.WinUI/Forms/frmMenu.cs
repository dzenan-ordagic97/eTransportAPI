using eTransport.Model.Requests;
using eTransport.WinUI.Helpers;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eTransport.WinUI.Forms
{
    public interface INavigation
    {
        Stack<NavForms.Forma> lastform { get; set; }
        void Navigate(Form form, object sender);
        void Pop();
        void Push(NavForms.Forma form);
    }
    public partial class frmMenu : Form, INavigation
    {
        //Fields
        private Button currentButton;
        private Random random;
        private int tempIndex;
        private Form activeForm;
        private readonly APIService _service = new APIService("Users/Auth");
        private readonly APIService _serviceCarrier = new APIService("Carrier");
        private readonly INavigation _navigation;
        public Stack<NavForms.Forma> lastform { get; set; }
        //Constructor
        private HubConnection connection;

        public frmMenu()
        {
            InitializeComponent();
            random = new Random();
            btnCloseChildForm.Visible = false;
            this.Text = string.Empty;
            this.ControlBox = false;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            btnProfile.Text =" "+APIService.Session.ImePrezime;
            _navigation = this;
            lastform = new Stack<NavForms.Forma>();
        }
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;


        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        //Theme
        private Color SelectThemeColor()
        {
            int index = random.Next(ThemeColor.ColorList.Count);
            while (tempIndex == index)
            {
                index = random.Next(ThemeColor.ColorList.Count);
            }
            tempIndex = index;
            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }
        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = SelectThemeColor();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    panelTitleBar.BackColor = color;
                    panelLogo.BackColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    ThemeColor.PrimaryColor = color;
                    ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    btnCloseChildForm.Visible = true;
                }
            }
        }
        private void DisableButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(51, 51, 76);
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }
        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
                activeForm.Close();
            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktopPane.Controls.Add(childForm);
            this.panelDesktopPane.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitle.Text = childForm.Text;
            
        }
        private void btnVehicles_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.frmVehicles(_navigation), sender);
        }
        private void btnOrders_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.frmOrders(_navigation), sender);
        }
        private void btnServices_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.frmAddExtraServices(), sender);
        }
        private void btnProfile_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.frmProfile(), sender);
        }
        
        private void btnAddCountry_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.frmAddCountry(), sender);
        }
        
        private void btnCity_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.frmAddCity(), sender);
        }
        private void btnStatistics_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.frmStatistics(_navigation), sender);
        }
        private void btnUsers_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.frmUsers(), sender);
        }
        private void btnCloseChildForm_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            lastform.Clear();
            btnBack.Visible = false;
            Reset();
        }
        private void Reset()
        {
            DisableButton();
            lblTitle.Text = "DASHBOARD";
            panelTitleBar.BackColor = Color.FromArgb(0, 150, 136);
            panelLogo.BackColor = Color.FromArgb(39, 39, 58);
            currentButton = null;
            btnCloseChildForm.Visible = false;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }
        private void bntMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        private void panelLogo_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        private async void frmMenu_Load(object sender, EventArgs e)
        {
            if (APIService.Session.Role.Contains(Model.Helpers.Role.Admin))
            {
                btnUsers.Show();
                btnVehicles.Hide();
                btnOrders.Hide();
                btnServices.Hide();
                btnProfile.Hide();
                btnStatistics.Hide();
                btnAddCountry.Show();
                button2.Hide();
                btnCity.Show();
                txtName.Text = "Admin!";
            }
            else
            {
                btnUsers.Hide();
            }
            var carrier = await _serviceCarrier.Get<List<Model.Carrier>>(null);
            if(carrier.Count>0)
            {
                txtName.Text = carrier[0].CarrierName;
            }
            else
            {
                txtName.Text = "No carrier name!";
            }
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Restart();
        }
        public void Navigate(Form form,object sender)
        {
            OpenChildForm(form, sender);
        }
        public void Pop()
        {
            var last = lastform.Pop();
            if (lastform.Count==0)
            {
                btnCloseChildForm.Visible = true;
                btnBack.Visible = false;
            }
            if (last == NavForms.Forma.Vehicles)
            {
                OpenChildForm(new frmVehicles(_navigation), null);
            }
            if (last == NavForms.Forma.AddVehicle)
            {
                OpenChildForm(new frmAddVehicle(_navigation), null);
            }
            if (last == NavForms.Forma.Orders)
            {
                OpenChildForm(new frmOrders(_navigation), null);
            }
            if (last == NavForms.Forma.Statistics)
            {
                OpenChildForm(new frmStatistics(_navigation), null);
            }
        }
        public void Push(NavForms.Forma form)
        {
            btnBack.Visible = true;
            btnCloseChildForm.Visible = false;
            lastform.Push(form);
        }
        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            Pop();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var messages_form = new Forms.frmMessages();
            if (activeForm != null)
                activeForm.Close();

            ActivateButton(sender);
            messages_form.BringToFront();
            messages_form.Show();
        }
    }
}
