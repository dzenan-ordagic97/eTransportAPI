using eTransport.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace eTransport.Mobile.ViewModels
{
    public class HomeViewModel:BaseViewModel
    {
        private readonly APIService _serviceCarrier = new APIService("Carrier");
        private Model.Requests.CarrierSearchRequest requestCarrier;
        public HomeViewModel()
        {
            HomeCommand = new Command(async () => await Init());
            RecommendedCommand = new Command(async () => await Recommended());
        }
        private string _rating= string.Empty;
        public string Rating
        {
            get { return _rating; }
            set { SetProperty(ref _rating, value); }
        }
        public ICommand HomeCommand { get; set; }
        public ICommand RecommendedCommand { get; set; }
        public ObservableCollection<Carrier> CarrierList { get; set; } = new ObservableCollection<Carrier>();
        public ObservableCollection<Carrier> RecommendedList { get; set; } = new ObservableCollection<Carrier>();


        public async Task Init()
        {
            requestCarrier = new Model.Requests.CarrierSearchRequest()
            {
                IsSingleCarrier = false
            };
            var list = await _serviceCarrier.Get<List<Model.Carrier>>(requestCarrier);
            CarrierList.Clear();
            //if (list.Count==0)
            //{
            //    await Application.Current.MainPage.DisplayAlert("Info","No available carriers","OK");
            //}
            foreach (var item in list)
            {
                CarrierList.Add(item);
            }
        }
        public async Task Recommended()
        {
            try
            {
                var recommended = await _serviceCarrier.Recommend<List<Carrier>>();
                RecommendedList.Clear();
                foreach (var item in recommended)
                {
                    RecommendedList.Add(item);
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
