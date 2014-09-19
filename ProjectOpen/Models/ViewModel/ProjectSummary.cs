using SDD.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectOpen.Models.ViewModel
{
    public class ProjectSummary
    {
        public ProjectSummary()
        {
            Projects = new List<_projectTypeTable>();
        }

        public HeaderVM Header { get; set; }

        public IList<_projectTypeTable> Projects { get; set; }
    }
}