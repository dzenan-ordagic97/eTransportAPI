using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace eTransport.Mobile.ModelXamarin
{
    public class User : ObservableObject
    {
        static Random Random = new Random();
        string name;
        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        string firstLetter;
        public string FirstLetter
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(firstLetter))
                    return firstLetter;

                firstLetter = Name?.Length > 0 ? Name[0].ToString() : "?";
                return firstLetter;
            }
            set => firstLetter = value;
        }

        Color color;
        public Color Color
        {
            get
            {
                color = Name.Equals("Me") ? Color.FromRgb(140, 140, 140).MultiplyAlpha(.9): Color.FromRgb(0, 150, 136).MultiplyAlpha(.9);
                return color;
            }
            set => color = value;
        }
    }
}