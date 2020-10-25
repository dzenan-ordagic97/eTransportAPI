using eTransport.WinUI.Helpers;
using eTransport.WinUI.Reports;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eTransport.WinUI.Forms
{
    public partial class frmReports : Form
    {
        private readonly APIService _serviceCargoReservation = new APIService("CargoReservation");
        private readonly APIService _serviceCarrier = new APIService("Carrier");
        private int j = 1;
        private decimal totalPrice = new decimal();
        private INavigation _navigation;

        public frmReports(INavigation navigation)
        {
            InitializeComponent();
            _navigation = navigation;
        }

        private async void frmReports_Load(object sender, EventArgs e)
        {

            var resultCargoReservation = await _serviceCargoReservation.Get<List<Model.CargoReservation>>(null);
            var result = await _serviceCarrier.Get<List<Model.Carrier>>(null);

            ReportParameterCollection rpc = new ReportParameterCollection();
            rpc.Add(new ReportParameter("CarrierName", result[0].CarrierName));

            DataFreights.tblAllFreightsDataTable tbl = new DataFreights.tblAllFreightsDataTable();
            foreach(var item in resultCargoReservation)
            {
                if(item.Freight.CarrierID==result[0].CarrierID && item.Freight.Finished==true && item.Freight.isPayed.GetValueOrDefault()==true)
                {
                    DataFreights.tblAllFreightsRow red = tbl.NewtblAllFreightsRow();
                    red.Rb = j++;
                    red.StartLocation = item.StartLocation;
                    red.EndLocation = item.EndLocation;
                    red.Client = item.Client;
                    red.TransportDate = item.Freight.TransportDate.GetValueOrDefault().ToString("dd.MM.yyyy");
                    red.Price = item.Freight.Price.ToString();
                    totalPrice += item.Freight.Price;
                    tbl.Rows.Add(red);
                }
            }
            rpc.Add(new ReportParameter("TotalPrice", totalPrice.ToString()));
            ReportDataSource rds = new ReportDataSource();
            rds.Name = "CompletedFreights";
            rds.Value = tbl;

            reportViewer1.LocalReport.SetParameters(rpc);
            reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.RefreshReport();
        }
    }
}
