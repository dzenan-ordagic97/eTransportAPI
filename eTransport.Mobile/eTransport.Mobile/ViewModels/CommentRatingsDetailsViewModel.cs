using eTransport.Model;
using eTransport.Model.Requests;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace eTransport.Mobile.ViewModels
{
    public class CommentRatingsDetailsViewModel:BaseViewModel
    {
        private readonly APIService _serviceCommentRating = new APIService("CommentRating");
        public CommentRatingsDetailsViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }
        public ObservableCollection<CommentRating> CommentRatingList { get; set; } = new ObservableCollection<CommentRating>();
        public ICommand InitCommand { get; set; }
        public async Task Init()
        {
            var request = new CommentRatingSearchRequest()
            {
                isClient = true
            };
            var list = await _serviceCommentRating.Get<List<Model.CommentRating>>(request);
            if (list.Count == 0)
            {
                await Application.Current.MainPage.DisplayAlert("Info", "You have not rated any of the carriers!", "OK");
            }
            CommentRatingList.Clear();
            foreach (var comment in list)
            {
                CommentRatingList.Add(comment);
            }
        }
    }
}
