using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectOpen.Models.ViewModel
{
    public class ProjectDepartmentTable
    {
        public ProjectDepartmentTable()
        {
            Projects = new List<Project>();
            Identifier = Guid.NewGuid();
        }

        public Guid Identifier { get; set; }
        public IList<Project> Projects { get; set; }
        public string projectDepartmentDescription { get; set; }
        public int QtyOfProjects { get; set; }
        public int ProjectDepartmentTableCount { get; set; }
    }
}