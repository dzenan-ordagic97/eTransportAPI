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
    public partial class CommentsRatingsPage : ContentPage
    {
        private CommentRatingsViewModel model = null;
        public CommentsRatingsPage()
        {
            InitializeComponent();
            BindingContext = model = new CommentRatingsViewModel();

        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
            if(model.CommentRatingList.Count==0)
            {
                errorLabel.IsVisible = true;
            }
            else
            {
                errorLabel.IsVisible = false;
            }
        }
        
        private async void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var result = await Application.Current.MainPage.DisplayAlert("Info", "Do you want to rate the following reservation?", "Yes", "No");
            if (result == true)
            {
                await Navigation.PushAsync(new AddCommentRatingPage(((eTransport.Model.CargoReservation)e.SelectedItem).CargoReservationID));
            }
            else
            {
                await model.Init();
            }
        }
    }
}