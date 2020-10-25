using System;
using System.Collections.Generic;
using System.Text;

namespace eTransport.Mobile.Models
{
    public enum MenuItemType
    {
        Home,
        Profile,
        Cargo
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
