using eTransport.Model;
using eTransport.Model.Requests;
using eTransport.WinUI.Helpers;
using LiveCharts;
using LiveCharts.Wpf;
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
    public partial class frmStatistics : Form
    {
        private readonly APIService _service = new APIService("CommentRating");
        private readonly APIService _serviceFreight = new APIService("Freight");
        private readonly APIService _serviceCargoReservation = new APIService("CargoReservation");
        private readonly APIService _serviceCarrier = new APIService("Carrier");
        private readonly INavigation _navigation;

        public frmStatistics()
        {
            InitializeComponent();
        }
        public frmStatistics(INavigation navigation)
        {
            InitializeComponent();
            _navigation = navigation;
        }
        Func<ChartPoint, string> labelPoint = chartpoint => string.Format("{0} ({1:P})", chartpoint.Y, chartpoint.Participation);
        private async void frmStatistics_Load(object sender, EventArgs e)
        {
            int Count5 = 0, Count4 = 0, Count3 = 0, Count2 = 0, Count1 = 0;
            decimal totalFreight = 0, totalFreights = 0,totalPayed=0;
            double totalDistance = 0;
            string mostCommonCity = "";
            List<string> cityList = new List<string>();
            var resultCargoReservation = await _serviceCargoReservation.Get<List<Model.CargoReservation>>(null);
            var resultCarrier = await _serviceCarrier.Get<List<Model.Carrier>>(null);
            if (resultCargoReservation != null)
            {
                foreach (var item in resultCargoReservation)
                {
                    if (item.Freight.CarrierID == resultCarrier[0].CarrierID && item.Freight.Finished==true)
                    {
                        cityList.Add(item.StartLocation);
                        cityList.Add(item.EndLocation);
                    }
                }
            }
            if (cityList.Count != 0)
            {
                mostCommonCity = cityList.GroupBy(v => v)
                .OrderByDescending(g => g.Count())
                .First().Key;
            }
            if(mostCommonCity!=null)
            {
                txtCity.Text = mostCommonCity;
            }
            else
            {
                txtCity.Text = "None";
            }
            var freightSearch = new FreightSearchRequest()
            {
                Finished = true
            };
            var result = await _service.Get<List<Model.CommentRating>>(null);
            var resultFreight = await _serviceFreight.Get<List<Model.Freight>>(freightSearch);
            totalFreights = resultFreight.Count();
            totalPayed = resultFreight.Where(x => x.isPayed.GetValueOrDefault()).Count();
            if (resultFreight != null)
            {
                foreach (var item in resultFreight)
                {
                    if (item.Finished == true)
                    {
                        totalFreight += item.Price;
                        totalDistance += item.Distance.GetValueOrDefault();
                    }
                }
                txtTotal.Text = totalFreight.ToString() + "$";
                txtDistance.Text = totalDistance.ToString() + "km";
                txtTotalFreights.Text = totalFreights.ToString();
                txtPayed.Text = totalPayed.ToString();
            }
            else
            {
                txtTotal.Text = "0$";
                txtDistance.Text = "0km";
                txtTotalFreights.Text = "0";
                txtPayed.Text = "0";
            }
            if (result != null)
            {
                foreach (var item in result)
                {
                    if (item.Rating == 5)
                        Count5++;
                    if (item.Rating == 4)
                        Count4++;
                    if (item.Rating == 3)
                        Count3++;
                    if (item.Rating == 2)
                        Count2++;
                    if (item.Rating == 1)
                        Count1++;
                }
            }
            List<string> test = new List<string>()
            {
                "5 stars","4 stars","3 stars","2 stars","1 stars"
            };
            List<int> test2 = new List<int>()
            {
                Count5,Count4,Count3,Count2,Count1
            };
            SeriesCollection series = new SeriesCollection();

            for (int i = 0; i < 5; i++)
            {
                series.Add(new PieSeries() { Title = test[i], Values = new ChartValues<int> { test2[i] }, DataLabels = true });
            }
            //foreach (var item in result)
            //{
            //    series.Add(new PieSeries() { Title = "Rating " + item.Rating, Values = new ChartValues<int> { test.ge }, DataLabels = true, LabelPoint = labelPoint });
            //}
            pieChart1.Series = series;
            pieChart1.LegendLocation = LegendLocation.Bottom;
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
        private void button1_Click(object sender, EventArgs e)
        {
            _navigation.Navigate(new frmFreightDetails(_navigation), null);
            _navigation.Push(NavForms.Forma.Statistics);
        }
        private void btnReport_Click(object sender, EventArgs e)
        {
            _navigation.Navigate(new frmReports(_navigation), null);
            _navigation.Push(NavForms.Forma.Statistics);
        }
    }
}
