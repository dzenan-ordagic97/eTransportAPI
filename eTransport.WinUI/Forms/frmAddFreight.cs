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
    public partial class frmAddFreight : Form
    {
        private readonly APIService _serviceFreight = new APIService("Freight");
        private readonly APIService _serviceVehicle = new APIService("Vehicle");
        private readonly APIService _serviceCargo = new APIService("CargoReservation");
        private readonly APIService _serviceCarrier = new APIService("Carrier");
        private Model.Requests.CargoReservationInsertRequest _cargoUpdate;
        private Model.Requests.FreightInsertRequest _freightUpdate;
        private readonly INavigation _navigation;
        private List<Model.Vehicle> _vehicles;
        private int _id = 0;
        Regex regexNumbers = new Regex(@"^[0-9]*$");
        public frmAddFreight(int id, INavigation navigation)
        {
            InitializeComponent();
            _vehicles = new List<Model.Vehicle>();
            getVehicle();
            _cargoUpdate = new Model.Requests.CargoReservationInsertRequest();
            _id = id;
            _navigation = navigation;
        }
        private async void getVehicle()
        {
            _vehicles.AddRange(await _serviceVehicle.Get<List<Model.Vehicle>>(null));
            cBVehicle.DataSource = _vehicles;
            cBVehicle.DisplayMember = "VehicleModel";
            cBVehicle.ValueMember = "VehicleID";
        }
        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtTransportDate.Value.Date < DateTime.Now.Date)
            {
                MessageBox.Show("You can't assign past date! (Transport date can't be lower than todays date)");
                return;
            }

            if (txtPrice.Text == "" || !regexNumbers.IsMatch(txtPrice.Text))
            {
                MessageBox.Show("Please enter a vaild price (Only numbers and no space)!");
                return;
            }
            if (txtDistance.Text == "" || !regexNumbers.IsMatch(txtDistance.Text))
            {
                MessageBox.Show("Please enter a vaild distance (Only numbers and no space)!");
                return;
            }
            if(cBVehicle.SelectedItem==null)
            {
                MessageBox.Show("Please choose your vehicle! (Add on Vehicles tab if you don't have!)");
                return;
            }
            try
            {
                var result = await _serviceCarrier.Get<List<Model.Carrier>>(null);
                var cargoReservation = await _serviceCargo.GetById<Model.CargoReservation>(_id);
                if (cargoReservation.FreightID != null)
                {
                    if (cargoReservation.ExtraServices != null)
                    {
                        _freightUpdate = new Model.Requests.FreightInsertRequest()
                        {
                            AcceptDate = DateTime.Now,
                            CarrierID = result[0].CarrierID,
                            Price = decimal.Parse(txtPrice.Text) + cargoReservation.ExtraServices.Price + result[0].StartupPrice,
                            TransportDate = DateTime.Parse(txtTransportDate.Text),
                            VehicleID = ((Model.Vehicle)cBVehicle.SelectedItem).VehicleID,
                            Distance = double.Parse(txtDistance.Text),
                            isPayed = false,
                            isRated = false,
                            isAdding = true
                        };
                    }
                    else
                    {
                        _freightUpdate = new Model.Requests.FreightInsertRequest()
                        {
                            AcceptDate = DateTime.Now,
                            CarrierID = result[0].CarrierID,
                            Price = decimal.Parse(txtPrice.Text) + result[0].StartupPrice,
                            TransportDate = DateTime.Parse(txtTransportDate.Text),
                            VehicleID = ((Model.Vehicle)cBVehicle.SelectedItem).VehicleID,
                            Distance = double.Parse(txtDistance.Text),
                            isPayed = false,
                            isRated = false,
                            isAdding = true
                        };
                    }
                    var freight = await _serviceFreight.Update<Model.Freight>(cargoReservation.FreightID.GetValueOrDefault(), _freightUpdate);

                    _cargoUpdate.FreightID = freight.FreightID;
                    _cargoUpdate.Freight = freight;
                    _cargoUpdate.Accepted = true;
                    _cargoUpdate.Finished = false;
                    _cargoUpdate.isFreightUpdate = true;
                    var cargo = await _serviceCargo.Update<Model.CargoReservation>(_id, _cargoUpdate);
                    if (freight != null && cargo != null)
                    {

                        MessageBox.Show("Succesfuly saved", "Freight", MessageBoxButtons.OK);
                        this.Close();
                        _navigation.Pop();
                    }
                }
                else
                {
                    if (cargoReservation.ExtraServices != null)
                    {
                        _freightUpdate = new Model.Requests.FreightInsertRequest()
                        {
                            AcceptDate = DateTime.Now,
                            CarrierID = result[0].CarrierID,
                            Price = decimal.Parse(txtPrice.Text) + cargoReservation.ExtraServices.Price + result[0].StartupPrice,
                            Distance = double.Parse(txtDistance.Text),
                            TransportDate = DateTime.Parse(txtTransportDate.Text),
                            VehicleID = ((Model.Vehicle)cBVehicle.SelectedItem).VehicleID,
                            isPayed = false,
                            isRated = false
                        };
                    }
                    else
                    {
                        _freightUpdate = new Model.Requests.FreightInsertRequest()
                        {
                            AcceptDate = DateTime.Now,
                            CarrierID = result[0].CarrierID,
                            Price = decimal.Parse(txtPrice.Text) + result[0].StartupPrice,
                            Distance = double.Parse(txtDistance.Text),
                            TransportDate = DateTime.Parse(txtTransportDate.Text),
                            VehicleID = ((Model.Vehicle)cBVehicle.SelectedItem).VehicleID,
                            isPayed = false,
                            isRated = false
                        };
                    }
                    var freight = await _serviceFreight.Insert<Model.Freight>(_freightUpdate);
                    _cargoUpdate.FreightID = freight.FreightID;
                    _cargoUpdate.Freight = freight;
                    _cargoUpdate.Accepted = true;
                    _cargoUpdate.Finished = false;
                    var cargo = await _serviceCargo.Update<Model.CargoReservation>(_id, _cargoUpdate);

                    if (freight != null && cargo != null)
                    {
                        MessageBox.Show("Succesfuly saved", "Freight", MessageBoxButtons.OK);
                        this.Close();
                        _navigation.Pop();
                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Freight", MessageBoxButtons.OK);
            }
        }
        private void frmAddFreight_Load(object sender, EventArgs e)
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
