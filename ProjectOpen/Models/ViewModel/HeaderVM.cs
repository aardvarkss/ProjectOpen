using ProjectOpen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SDD.Models.ViewModel
{
    public class HeaderVM
    {
        public SideBarMenu sbm { get; set; }

        public HeaderBar Hdr { get; set; }

        public Breadcrumbs brdcrm { get; set; }

        public HeadingLine hl { get; set; }
    }
}