using eTransport.WinUI.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eTransport.WinUI.Forms
{
    public partial class frmFreightDetails : Form
    {
        private readonly APIService _serviceComment = new APIService("CommentRating");
        private readonly APIService _serviceCarrier = new APIService("Carrier");

        private readonly INavigation _navigation;
        public frmFreightDetails()
        {
            InitializeComponent();
        }
        public frmFreightDetails(INavigation navigation)
        {
            InitializeComponent();
            _navigation = navigation;
            getCommentRating();
        }
        private async void getCommentRating()
        {
            var result = await _serviceCarrier.Get<List<Model.Carrier>>(null);
            bool trigger = false;
            List<Model.CommentRating> commentRatings = await _serviceComment.Get<List<Model.CommentRating>>(null);
            if (commentRatings != null)
            {
                foreach (var item in commentRatings)
                {
                    if (item.Freight.CarrierID == result[0].CarrierID )
                    {
                        flowLayoutPanelFreightDetails.Controls.Add(new OneCommentRating(item, _navigation, NavForms.Forma.Statistics));
                        gBFreightDetails.Visible = true;
                        trigger = true;
                    }
                }
            }
            else
            {
                error.Visible = true;
            }
            if(!trigger)
            {
                error.Visible = true;
            }
        }
        
    }
}
