using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SDD.Models
{
    public class MenuItem
    {
        public string DisplayName { get; set; }
        public List<MenuSubItem> subItems { get; set; }
        public string IconName { get; set; }
        public string Href { get; set; }

        public MenuItem()
        {
            subItems = new List<MenuSubItem>();
            Href = "javascript:void(0);";
        }

        public MenuItem(string iconName, string href, string displayName)
        {
            subItems = new List<MenuSubItem>();
            
            if (href == "")
            {
                this.Href = "javascript:void(0);";
            }
            else
            {
                this.Href = href;
            }

            this.IconName = iconName;
            this.DisplayName = displayName;
        }

        public void addMenuSubItem(MenuSubItem msi)
        {
            subItems.Add(msi);
        }
    }
}