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
    public partial class CommentRatingDetailsPage : ContentPage
    {
        CommentRatingsDetailsViewModel model = null;
        public CommentRatingDetailsPage()
        {
            InitializeComponent();
            BindingContext = model = new CommentRatingsDetailsViewModel();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }
    }
}