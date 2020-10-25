using eTransport.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eTransport.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaymentPage : ContentPage
    {
        private PaymentViewModel model = null;
        private int _freightID;
        public PaymentPage(int freightID)
        {
            InitializeComponent();
            BindingContext = model = new PaymentViewModel();
            _freightID = freightID;
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init(_freightID);
        }
    }
}