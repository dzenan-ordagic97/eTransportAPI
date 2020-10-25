using eTransport.Mobile.Views;
using eTransport.Model;
using eTransport.Model.Requests;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace eTransport.Mobile.ViewModels
{
    public class CargoViewModel:BaseViewModel
    {
        private readonly APIService _serviceCargo = new APIService("Cargo");

        public CargoViewModel()
        {
            CargoCommand = new Command(async () => await Init());
            AddCommand = new Command(async () => await Add());
        }
        public ObservableCollection<Cargo> CargoList { get; set; } = new ObservableCollection<Cargo>();
        public ICommand CargoCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public async Task Add()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new AddCargoPage());
        }
        public async Task Init()
        {

            var list = await _serviceCargo.Get<List<Model.Cargo>>(null);
            //if (list.Count == 0)
            //{
            //    await Application.Current.MainPage.DisplayAlert("Info", "You don't have any cargos", "OK");
            //}
            CargoList.Clear();
            foreach (var cargo in list)
            {
                CargoList.Add(cargo);
            }
        }
    }
}
