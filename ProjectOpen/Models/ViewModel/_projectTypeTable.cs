using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectOpen.Models.ViewModel
{
    public class _projectTypeTable
    {
        public _projectTypeTable()
        {
            DepartmentGroups = new List<ProjectDepartmentTable>();
        }

        public IList<ProjectDepartmentTable> DepartmentGroups { get; set; }
        public string projectTypeDescription { get; set; }
        public int QtyOfProjects { get; set; }
        public int projectTypeCount { get; set; }
        
        
    }
}