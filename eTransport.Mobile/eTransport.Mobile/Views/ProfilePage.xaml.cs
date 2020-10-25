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
    public partial class ProfilePage : ContentPage
    {
        private ProfileVM model;
        public ProfilePage()
        {
            InitializeComponent();
            BindingContext = model = new ProfileVM();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Update.IsVisible = false;
            Save.IsVisible = true;
            Back.IsVisible = true;
            Logout.IsVisible = false;
           
            FrameName.IsVisible = false;
            FrameDate.IsVisible = false;
            FrameGender.IsVisible = false;
            FrameJMBG.IsVisible = false;
            FrameLast.IsVisible = false;
            MainFrameName.IsVisible = false;
            MainFrameLast.IsVisible = false;
            MainFrameJMBG.IsVisible = false;
            MainFrameGender.IsVisible = false;
            MainFrameDate.IsVisible = false;

            FirstName.IsVisible = true;
            LastName.IsVisible = true;
            Gender.IsVisible = true;
            JMBG.IsVisible = true;
            DateOfBirth.IsVisible = true;
        }

        private async void Save_Clicked(object sender, EventArgs e)
        {
            await model.Update();

            if (model.trigger == true)
            {
                Save.IsVisible = false;
                Back.IsVisible = false;
                Update.IsVisible = true;
                Logout.IsVisible = true;

                FrameName.IsVisible = true;
                FrameDate.IsVisible = true;
                FrameGender.IsVisible = true;
                FrameJMBG.IsVisible = true;
                FrameLast.IsVisible = true;
                MainFrameName.IsVisible = true;
                MainFrameDate.IsVisible = true;
                MainFrameGender.IsVisible = true;
                MainFrameJMBG.IsVisible = true;
                MainFrameLast.IsVisible = true;

                FirstName.IsVisible = false;
                LastName.IsVisible = false;
                Gender.IsVisible = false;
                JMBG.IsVisible = false;
                DateOfBirth.IsVisible = false;
            }
        }

        private async void Back_Clicked(object sender, EventArgs e)
        {
            await model.Back();
            Save.IsVisible = false;
            Back.IsVisible = false;
            Update.IsVisible = true;
            Logout.IsVisible = true;

            FrameName.IsVisible = true;
            FrameDate.IsVisible = true;
            FrameGender.IsVisible = true;
            FrameJMBG.IsVisible = true;
            FrameLast.IsVisible = true;
            MainFrameName.IsVisible = true;
            MainFrameDate.IsVisible = true;
            MainFrameGender.IsVisible = true;
            MainFrameJMBG.IsVisible = true;
            MainFrameLast.IsVisible = true;

            FirstName.IsVisible = false;
            LastName.IsVisible = false;
            Gender.IsVisible = false;
            JMBG.IsVisible = false;
            DateOfBirth.IsVisible = false;
        }
    }
}