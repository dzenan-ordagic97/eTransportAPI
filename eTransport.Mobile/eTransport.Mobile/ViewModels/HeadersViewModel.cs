using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace eTransport.Mobile.ViewModels
{
    public class HeadersViewModel : BaseViewModel
    {
        private readonly APIService _serviceHeaders = new APIService("MessageHeader");

        public HeadersViewModel()
        {
            InitCommand = new Command(async () => await Init());

        }
        public ICommand InitCommand { get; set; }
        public ObservableCollection<Model.MessageHeader> HeadersList { get; set; } = new ObservableCollection<Model.MessageHeader>();

        public async Task Init()
        {
            var result = await _serviceHeaders.Get<List<Model.MessageHeader>>(null);

            HeadersList.Clear();
            foreach (var header in result)
            {
                HeadersList.Add(header);
            }
        }
    }
}
