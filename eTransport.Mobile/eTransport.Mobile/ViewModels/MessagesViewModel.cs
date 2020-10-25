using eTransport.Mobile.ModelXamarin;
using eTransport.Model.SignalR;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace eTransport.Mobile.ViewModels
{
    public class MessagesViewModel : BaseViewModel
    {
        public ChatMessage ChatMessage { get; }
        private HubConnection connection;
        private Model.MessageHeader _messageHeader;
        private int _messageHeaderId;
        private readonly APIService _serviceMessage = new APIService("Message");
        public ObservableCollection<ChatMessage> Messages { get; }
        public ObservableCollection<User> Users { get; }

        public async Task Init()
        {
            InitializeConnection();
            StartConnection();
            LoadMessages();
        }

        private async void LoadMessages()
        {
            if (_messageHeader == null)
            {

                return;
            }
            var response = await _serviceMessage.Get<List<Model.Message>>(new Model.Message { MessageHeaderID = _messageHeaderId });

            if (response != null)
            {
                for(int i = response.Count()-1; i >= 0; i--)
                {
                    SendLocalMessage(response[i].Content, response[i].IsMyMessage ? "Me" :  _messageHeader?.Username.Split('@')[0]);
                }

               
            }
        }

        public Command SendMessageCommand { get; }
        public Command ConnectCommand { get; }
        public Command DisconnectCommand { get; }

        Random random;
        private int idCarrier;

        public MessagesViewModel()
        {

        }
        public MessagesViewModel(Model.MessageHeader selectedItem)
        {
            if (DesignMode.IsDesignModeEnabled)
                return;

            Title = "";
            _messageHeader = selectedItem;
            _messageHeaderId = selectedItem.MessageHeaderID;

            ChatMessage = new ChatMessage();
            Messages = new ObservableCollection<ChatMessage>();
            Users = new ObservableCollection<User>();
            SendMessageCommand = new Command(async () => await SendMessage());
            random = new Random();
        }

        public MessagesViewModel(int idCarrier)
        {
            this.idCarrier = idCarrier;

            ChatMessage = new ChatMessage();
            Messages = new ObservableCollection<ChatMessage>();
            Users = new ObservableCollection<User>();
            SendMessageCommand = new Command(async () => await SendMessage());
            random = new Random();
        }

        private async void StartConnection()
        {
            try
            {
                await connection.StartAsync();
                await connection.InvokeAsync("ChangeAvailability", true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void InitializeConnection()
        {
            connection = new HubConnectionBuilder()
                 .WithUrl("http://localhost:52391/chat", options =>
                 {
                     options.AccessTokenProvider = async () => await Task.FromResult(APIService.Session.JWT);
                     options.Headers.Add("Access-Control-Allow-Credentials", "true");
                 })
                 .WithAutomaticReconnect()
                .Build();
          
            connection.On<Model.SignalR.SignalMessage>("onSendMessage", (obj) =>
            {
                // UpdateOneHeaderLastMessage(obj);
                if (_messageHeader?.FromID == obj.From || idCarrier == obj.From)
                {
                    SendLocalMessage(obj.Message, _messageHeader?.Username.Split('@')[0]);
                }
            });

        }
       

        async Task SendMessage()
        {
            if (ChatMessage.Message == null)
                return;
            SendLocalMessage(ChatMessage.Message, "Me");
            await connection.InvokeAsync("SendMessage", new SignalMessage() { To = _messageHeader == null ? (int?)idCarrier : null, HeaderId = _messageHeader == null ? null : _messageHeader?.MessageHeaderID, Message = ChatMessage.Message });
            ChatMessage.Message = string.Empty;
        }

        private void SendLocalMessage(string message, string user)
        {
            user = user ?? "";
            Device.BeginInvokeOnMainThread(() =>
            {
                var first = Users.FirstOrDefault(u => u.Name == user);

                Messages.Insert(0, new ChatMessage
                {
                    Message = message,
                    User = user,
                    Color = user.Equals("Me") ? Color.FromRgba(186, 186, 186, 0) : Color.FromRgba(87, 203, 87, 0)
                });
            });
        }

       
    }
}
