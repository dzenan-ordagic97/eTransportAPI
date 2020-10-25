using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using eTransport.WinUI.Forms;

namespace eTransport.WinUI
{
    public partial class OneMessageHeader : UserControl
    {
        public Model.MessageHeader _messageHeader { get; set; }

        private INavigation _navigation;

        public OneMessageHeader(Model.MessageHeader mesageHeader, INavigation navigation)
        {
            InitializeComponent();
            _messageHeader = mesageHeader;
            _navigation = navigation;
            lbl_lastMessage.Text = _messageHeader.LastMessage + "  •  " + generateTime(_messageHeader.Sent);
            lbl_name.Text = _messageHeader.Username.Split('@')[0];
        }

        public void ChangeMessage (string message, DateTime time) => _messageHeader.LastMessage = message + "  •  " + generateTime(time);
       
        private string generateTime(DateTime? sent)
        {
            TimeSpan span = DateTime.Now.Subtract((DateTime) sent);
            var totalMinutes = span.TotalMinutes;
            if (totalMinutes < 1)
            {
                return "Now";
            }
            if (totalMinutes < 60)
            {
                return ((int)totalMinutes).ToString() + "min ago";
            }
            var totalHours = span.TotalHours;

            if (totalHours<=24)
            {
                return ((int)totalHours).ToString() + "h ago";
            }

            var totalDays = span.TotalDays;

            if (totalDays == 1)
            {
                return "Yesterday";
            }

            return ((DateTime)sent).ToString("dd.MM.yyyy");
        }

        private void OneMessageHeader_MouseClick(object sender, MouseEventArgs e)
        {
            _navigation.Navigate(new frmChat(_messageHeader), sender);
        }
    }


}
