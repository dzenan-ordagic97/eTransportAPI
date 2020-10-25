using eTransport.Model;
using eTransport.WinUI.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eTransport.WinUI.Forms
{
    public partial class frmChat : Form
    {
        private readonly APIService _serviceMessage = new APIService("Message");

        public MessageHeader messageHeader;

        public frmChat(MessageHeader messageHeader)
        {
            InitializeComponent();
            this.messageHeader = messageHeader;
            LoadData(messageHeader.MessageHeaderID);

        }


        public void newMessage(Model.SignalR.SignalMessage message)
        {
            _flpMessages.Controls.Add(new OneMessage(message.Message, ""));
            scrollToLastMessage();

        }

        public void newMyMessage(Model.SignalR.SignalMessage message)
        {
            _flpMessages.Controls.Add(new OneMyMessage(message.Message, ""));
            scrollToLastMessage();
        }

        private void scrollToLastMessage()
        {
            _flpMessages.Controls.SetChildIndex(_flpMessages.Controls[(_flpMessages.Controls.Count) - 1], 0);
            _flpMessages.ScrollControlIntoView(_flpMessages.Controls[0]);
        }
        private async void LoadData(int messageHeaderID)
        {
            var response = await _serviceMessage.Get<List<Model.Message>>(new Model.Message {MessageHeaderID = messageHeaderID});

            if (response != null)
            {
                foreach (var item in response)
                {
                    if (item.IsMyMessage)
                    {
                        _flpMessages.Controls.Add(new OneMyMessage(item.Content, ""));

                    }
                    else
                    {
                    _flpMessages.Controls.Add(new OneMessage(item.Content,""));

                    }
                }

                if (_flpMessages.VerticalScroll.Visible)
                {
                    _flpMessages.ScrollControlIntoView(_flpMessages.Controls[0]);
                }
            }
            
        }
    }
}
