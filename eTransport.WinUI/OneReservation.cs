using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using eTransport.Model;
using eTransport.WinUI.Forms;
using eTransport.WinUI.Helpers;

namespace eTransport.WinUI
{
    public partial class OneReservation : UserControl
    {
        private CargoReservation item;
        private readonly INavigation _navigation;
        private NavForms.Forma _previousForm;
        private readonly APIService _serviceCargoReservation = new APIService("CargoReservation");
        private Model.Requests.CargoReservationInsertRequest _cargoUpdate;



        public OneReservation(CargoReservation item, Forms.INavigation navigation, NavForms.Forma previousForm)
        {
            InitializeComponent();
            this.item = item;
            _navigation = navigation;
            loadData();
            _previousForm = previousForm;
            _cargoUpdate = new Model.Requests.CargoReservationInsertRequest();

        }
        private void loadData()
        {
            //Ako je zavrseno skroz
            if (item.Freight.Finished == true)
            {
                btnEnd.Visible = false;
                button1.Visible = false;

                lblPayed.Visible = true;
                lblPrice.Visible = true;
                lblExtraService.Visible = true;
                txtExtraService.Visible = true;
                txtPayed.Visible = true;
                txtPrice.Visible = true;
                lblExtraService2.Visible = false;
                txtExtraService2.Visible = false;
            }
            if (item.Accepted == true && (item.Freight.Finished == null || item.Freight.Finished == false) && (item.Freight.ClientAccepted == null || item.Freight.ClientAccepted == false))
            {
                btnEnd.Visible = true;
                btnEnd.Enabled = false;

                lblPayed.Visible = true;
                lblPrice.Visible = true;
                lblExtraService.Visible = true;
                txtExtraService.Visible = true;
                txtPayed.Visible = true;
                txtPrice.Visible = true;
                lblExtraService2.Visible = false;
                txtExtraService2.Visible = false;
            }
            if (item.Accepted == true && (item.Freight.Finished == null || item.Freight.Finished == false) && item.Freight.ClientAccepted==true)
            {
                btnEnd.Visible = true;

                lblPayed.Visible = true;
                lblPrice.Visible = true;
                txtPayed.Visible = true;
                lblExtraService.Visible = true;
                txtExtraService.Visible = true;
                txtPrice.Visible = true;
                lblExtraService2.Visible = false;
                txtExtraService2.Visible = false;
            }
            if (item.Accepted == false && (item.Freight.Finished == null || item.Freight.Finished == false))
            {
                button1.Visible = true;

            }
            txtStartDate.Text = item.StartDateTransport.ToString("dd.MM.yyyy");
            txtEndDate.Text = item.EndDateTransport.ToString("dd.MM.yyyy");
            txtStartLocation.Text = item.StartLocation;
            txtEndLocation.Text = item.EndLocation;
            txtClient.Text = item.Client;
            txtPrice.Text = item.Freight.Price.ToString();
            if(item.Freight.isPayed.GetValueOrDefault()==true)
            {
                txtPayed.Text = "Yes";
            }
            else
            {
                txtPayed.Text = "No";
            }
            if (item.ExtraServices.Name == null)
            {
                txtExtraService.Text = "No extra service";
                txtExtraService2.Text = "No extra service";
            }
            else
            {
                txtExtraService.Text = item.ExtraServices.Name;
                txtExtraService2.Text = item.ExtraServices.Name;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            _navigation.Navigate(new frmOrdersAndDetails(item.CargoReservationID, _navigation), null);
            _navigation.Push(NavForms.Forma.Orders);
        }

        private async void btnEnd_Click(object sender, EventArgs e)
        {
            _cargoUpdate.Finished = true;
            _cargoUpdate.Accepted = true;
            _cargoUpdate.FreightID = item.FreightID.GetValueOrDefault();
            var cargo = await _serviceCargoReservation.Update<Model.CargoReservation>(item.CargoReservationID, _cargoUpdate);
            if (cargo != null)
            {
                MessageBox.Show("Succesfuly saved", "Freight", MessageBoxButtons.OK);
                _navigation.Navigate(new frmAcceptedOrders(_navigation), null);
            }
        }
    }
}
