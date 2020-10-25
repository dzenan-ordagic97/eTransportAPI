using eTransport.Model;
using eTransport.Model.SignalR;
using eTransport.WinUI.Helpers;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eTransport.WinUI.Forms
{

    public partial class frmMessages : Form, INavigation
    {
        private Form activeForm;
        private HubConnection connection;

        private readonly APIService _serviceMessageHeaders = new APIService("MessageHeader");
        private List<Model.MessageHeader> _orgHeaders;
        private int currentChatHeader;
        private MessageHeader _messageHeader;

        public frmMessages()
        {
            InitializeComponent();
            LoadData();
            InitializeConnection();
            StartConnection();
            _orgHeaders = new List<Model.MessageHeader>();
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

            connection.On<Model.SignalR.UserStatus>("onChangeAvailibility", (obj) =>
            {
                UpdateOneHeaderStatus(obj);

            });
            connection.On<Model.SignalR.SignalMessage>("onSendMessage", (obj) =>
            {
                // UpdateOneHeaderLastMessage(obj);
                if (_messageHeader?.FromID == obj.From)
                {
                    UpdateChat(obj);
                }
            });

        }

        private void UpdateChat(SignalMessage message) => ((frmChat)activeForm)?.newMessage(message);
        private void UpdateMyChat(SignalMessage message) => ((frmChat)activeForm)?.newMyMessage(message);

        public Stack<NavForms.Forma> lastform { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Navigate(Form form, object sender)
        {
            openchildform(form as frmChat, sender);
        }

        public void Pop()
        {
            throw new NotImplementedException();
        }

        public void Push(NavForms.Forma form)
        {
            throw new NotImplementedException();
        }

        private void openchildform(frmChat childform, object btnsender)
        {

            btnSend.Visible = Visible;
            txtMessage.Visible = Visible;

            currentChatHeader = ((frmChat)childform).messageHeader.MessageHeaderID;
            _messageHeader = ((frmChat)childform).messageHeader;
            if (activeForm != null)
                activeForm.Close();
            activeForm = childform;
            childform.TopLevel = false;
            childform.FormBorderStyle = FormBorderStyle.None;
            childform.Dock = DockStyle.Fill;
            this.panel_messages.Controls.Add(childform);
            this.panel_messages.Tag = childform;
            childform.BringToFront();
            childform.Show();
            lblTitle.Text = ((frmChat)childform).messageHeader.Username.Split('@')[0];
           
        }

        private void UpdateOneHeaderStatus(Model.SignalR.UserStatus obj)
        {
            for (int i = 0; i < _orgHeaders.Count; i++)
            {

                if (_orgHeaders[i].FromID == obj.Id)
                {
                    _orgHeaders[i].Active = obj.Status;
                }
            }

            LoadHeaders(_orgHeaders);
        }

        private void UpdateOneHeaderLastMessage(SignalMessage message)
        {
            bool notFound = true;
            for (int i = 0; i < _orgHeaders.Count; i++)
            {
                if (_orgHeaders[i].FromID == message.From)
                {
                    var temp = _orgHeaders[i];
                    temp.LastMessage = message.Message;
                    temp.Active = true;
                    temp.Sent = DateTime.Now;
                    _orgHeaders.RemoveAt(i);
                    _orgHeaders.Insert(0, new Model.MessageHeader() { Username = temp.Username, Active = temp.Active, FromID = temp.FromID, LastMessage = temp.LastMessage, ToID = temp.ToID, Sent = temp.Sent, MessageHeaderID = temp.MessageHeaderID });
                    notFound = false;
                }
            }
            if (notFound)
            {
                LoadData();
            }
            flp_MessageHeaders.Controls.Clear();

            LoadHeaders(_orgHeaders);
        }

        private void LoadHeaders(List<Model.MessageHeader> headers)
        {
            flp_MessageHeaders.Controls.Clear();
            foreach (var item in headers.ToArray())
            {
                _orgHeaders.Clear();
                _orgHeaders.Add(item);
                flp_MessageHeaders.Controls.Add(new OneMessageHeader(item, this));
            }
        }

        private async void LoadData()
        {
            var response = await _serviceMessageHeaders.Get<List<Model.MessageHeader>>(null);
            if (response != null)
            {
                LoadHeaders(response);
            }

        }

        private void frmMessages_FormClosed(object sender, FormClosedEventArgs e)
        {
            connection.StopAsync();
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            if (txtMessage.Text == "")
            {
                return;
            }
            else
            {
                var message = txtMessage.Text;
                await connection.InvokeAsync("SendMessage", new SignalMessage() { HeaderId = currentChatHeader, Message = message });
                UpdateMyChat(new SignalMessage() { Message = message });
                txtMessage.Text = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        
    }
}
