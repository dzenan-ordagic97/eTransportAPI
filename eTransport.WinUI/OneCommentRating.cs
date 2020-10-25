using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using eTransport.Model;
using eTransport.WinUI.Forms;
using eTransport.WinUI.Helpers;

namespace eTransport.WinUI
{
    public partial class OneCommentRating : UserControl
    {
        private CommentRating item;
        private readonly INavigation _navigation;
        private NavForms.Forma _previousForm;
        private readonly APIService _serviceCommentRating = new APIService("CommentRating");
        public OneCommentRating(CommentRating item, Forms.INavigation navigation, NavForms.Forma previousForm)
        {
            InitializeComponent();
            this.item = item;
            _navigation = navigation;
            loadData();
            _previousForm = previousForm;
        }
        private void loadData()
        {
            txtClient.Text = item.Client;
            txtComment.Text = item.Comment;
            txtPrice.Text = item.Freight.Price.ToString();
            txtRating.Text = item.Rating.ToString();
            txtTransportDate.Text = item.Freight.TransportDate.GetValueOrDefault().ToString("dd.MM.yyyy");
        }
    }
}
