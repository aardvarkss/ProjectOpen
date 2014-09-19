using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SDD.Models
{
    public class MenuSubItem
    {
        public string DisplayName { get; set; }
        public List<MenuSubItem> SubItems { get; set; }
        public string IconName { get; set; }
        public string Href { get; set; }

        public MenuSubItem()
        {
            SubItems = new List<MenuSubItem>();
            Href = "javascript:void(0);";
        }

        public MenuSubItem(string iconName, string href, string displayName)
        {
            SubItems = new List<MenuSubItem>();
            
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

        public MenuSubItem(string iconName, string href, string displayName, List<MenuSubItem> menuSubItems)
        {
            
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

            SubItems = menuSubItems;
        }

        public MenuSubItem(string iconName, string href, string displayName, MenuSubItem menuSubItem)
        {
            SubItems = new List<MenuSubItem>();

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

            addMenuSubItem(menuSubItem);
        }

        public void addMenuSubItem(MenuSubItem msi)
        {
            SubItems.Add(msi);
        }
    }
}