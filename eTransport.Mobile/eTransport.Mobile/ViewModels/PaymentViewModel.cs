using eTransport.Mobile.Views;
using eTransport.Model;
using eTransport.Model.Requests;
using Stripe;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace eTransport.Mobile.ViewModels
{
    public class PaymentViewModel:BaseViewModel
    {
        private readonly APIService _serviceFreight = new APIService("Freight");
        Regex regexNumbers = new Regex(@"^[0-9]*$");
        public PaymentViewModel()
        {
            InitCommand = new Command(async (param) => await Init((int)param));
            PayCommand = new Command(async () => await Pay());
        }
        public int freightId;

        public string _carrierName = null;
        public string CarrierName
        {
            get { return _carrierName; }
            set { SetProperty(ref _carrierName, value); }
        }
        public string _distance = null;
        public string Distance
        {
            get { return _distance; }
            set { SetProperty(ref _distance, value); }
        }
        public string _price = null;
        public string Price
        {
            get { return _price; }
            set { SetProperty(ref _price, value); }
        }

        //credit card info
        public string _creditCardNumber = null;
        public string CreditCardNumber
        {
            get { return _creditCardNumber; }
            set { SetProperty(ref _creditCardNumber, value); }
        }

        public string _expiryYear = null;
        public string ExpiryYear
        {
            get { return _expiryYear; }
            set { SetProperty(ref _expiryYear, value); }
        }
        public string _expiryMonth = null;
        public string ExpiryMonth
        {
            get { return _expiryMonth; }
            set { SetProperty(ref _expiryMonth, value); }
        }
        public string _cvc = null;
        public string CVC
        {
            get { return _cvc; }
            set { SetProperty(ref _cvc, value); }
        }

        public decimal _fullPrice;
        public decimal FullPrice
        {
            get { return _fullPrice; }
            set { SetProperty(ref _fullPrice, value); }
        }

        public ICommand PayCommand { get; set; }
        public ICommand InitCommand { get; set; }

        public async Task Pay()
        {
            if (CreditCardNumber == null || !regexNumbers.IsMatch(CreditCardNumber) || CreditCardNumber.Length!=16)
            {
                await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Error", "Please input valid credit card number (16 numbers)", "OK");
            }else if(ExpiryYear==null || !regexNumbers.IsMatch(ExpiryYear) || ExpiryYear.Length!= 4)
            {
                await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Error", "Please input valid year (4 numbers)!", "OK");
            }else if(int.Parse(ExpiryYear) < 2021 || int.Parse(ExpiryYear)>2030)
            {
                await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Error", "Please input valid year (Minimum year 2021-Max year 2030)!", "OK");
            }
            else if (ExpiryMonth == null || !regexNumbers.IsMatch(ExpiryMonth) || ExpiryMonth.Length!=2)
            {
                await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Error", "Please input valid month (2 numbers)!", "OK");
            }else if(int.Parse(ExpiryMonth)<1 || int.Parse(ExpiryMonth)>12)
            {
                await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Error", "Please input valid month (Months between 01 and 12)!", "OK");
            }
            else if (CVC == null || !regexNumbers.IsMatch(CVC) || CVC.Length!=3)
            {
                await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Error", "Please input valid CVC number (3 numbers)!", "OK");
            }
            else
            {
                IsBusy = true;
                var stripeTokenId = CreateToken(CreditCardNumber, ExpiryMonth, ExpiryYear, CVC);
                var payment = await _serviceFreight.Payment(new PaymentModel()
                {
                    Amount = _fullPrice,
                    Token = stripeTokenId
                });
                var request = new FreightInsertRequest()
                {
                    isTransaction = true,
                    isPayed = true
                };
                await _serviceFreight.Update<Freight>(freightId, request);
                await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("eTransport", "Succesful transaction", "OK");
                IsBusy = false;
                await Xamarin.Forms.Application.Current.MainPage.Navigation.PopAsync();
            }
        }

        public string CreateToken(string cardNumber, string cardExpMonth, string cardExpYear, string cardCVC)
        {
            StripeConfiguration.ApiKey = "pk_test_51HDqToHyu0x6Ot10Xzgep49ahHPHQYaTw4jcTDWbML4Nzh8x5zYT21etX3xMG3WmKkCB1sYies1cikzwbO07Qtsg00v47ehKbF";

            var options = new TokenCreateOptions
            {
                Card = new CreditCardOptions
                {
                    Number = "5555555555554444",
                    ExpYear = 2022,
                    ExpMonth = 9,
                    Cvc = "123"
                }
            };
            var service = new TokenService();
            Token stripeToken = service.Create(options);
            return stripeToken.Id;
        }
        public async Task Init(int freightID)
        {
            try
            {
                var freight = await _serviceFreight.GetById<Freight>(freightID);
                CarrierName = freight.Carrier.CarrierName;
                Distance = freight.Distance.ToString()+"km";
                freightId = freight.FreightID;
                FullPrice = freight.Price+freight.Carrier.StartupPrice;
            }
            catch (Exception)
            {

            }
        }
    }
}
