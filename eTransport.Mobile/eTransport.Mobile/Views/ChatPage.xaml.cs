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
    public partial class ChatPage : ContentPage
    {
        MessagesViewModel vm;
        Model.MessageHeader _selectedItem;
        public ChatPage(Model.MessageHeader selectedItem)
        {
            InitializeComponent();
            BindingContext = vm = new MessagesViewModel(selectedItem);
            _selectedItem = selectedItem;
            //vm.ListMessages.CollectionChanged += (sender, e) =>
            //{
            //    var target = vm.ListMessages[vm.ListMessages.Count - 1];
            //    MessagesListView.ScrollTo(target, ScrollToPosition.End, true);
            //};
        }
        public ChatPage(int idCarrier)
        {
            InitializeComponent();
            BindingContext = vm = new MessagesViewModel(idCarrier);
            //vm.ListMessages.CollectionChanged += (sender, e) =>
            //{
            //    var target = vm.ListMessages[vm.ListMessages.Count - 1];
            //    MessagesListView.ScrollTo(target, ScrollToPosition.End, true);
            //};
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await vm.Init();
       
        }
    }
}