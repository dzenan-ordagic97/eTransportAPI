using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace eTransport.Mobile.ModelXamarin
{
   public class ChatMessage : ObservableObject
    {
        static Random Random = new Random();
        string user;
        public string User
        {
            get => user;
            set => SetProperty(ref user, value);
        }

        string message;
        public string Message
        {
            get => message;
            set => SetProperty(ref message, value);
        }

        string firstLetter;
        public string FirstLetter
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(firstLetter))
                    return firstLetter;

                firstLetter = User?.Length > 0 ? User[0].ToString() : "?";
                return firstLetter;
            }
            set => firstLetter = value;
        }

        Color color;
        public Color Color
        {
            get
            {
                color = User.Equals("Me") ? Color.FromRgb(140, 140, 140).MultiplyAlpha(.9) : Color.FromRgb(0, 150, 136).MultiplyAlpha(.9);
                return color;
            }
            set => color = value;
        }

        Color backgroundColor;
        public Color BackgroundColor
        {
            get
            {

                backgroundColor = User.Equals("Me") ? Color.FromRgb(140, 140, 140).MultiplyAlpha(.9) : Color.FromRgb(0, 150, 136).MultiplyAlpha(.9);

                return backgroundColor;
            }
            set => backgroundColor = value;
        }
    }
}