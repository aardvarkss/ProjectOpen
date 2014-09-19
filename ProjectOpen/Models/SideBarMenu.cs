using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SDD.Models
{
    public class SideBarMenu
    {
        public List<MenuItem> Items { get; set; }

        public SideBarMenu()
        {
            Items = new List<MenuItem>();
        }

        public void addMenuItem(MenuItem m)
        {
            Items.Add(m);
        }
    }
}