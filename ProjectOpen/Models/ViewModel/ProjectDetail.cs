using SDD.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectOpen.Models.ViewModel
{
    public class ProjectDetail
    {
        public HeaderVM Header { get; set; }

        public IList<ProjectType> ProjectTypes { get; set; }
        public IList<Grouping> Departments { get; set; }

        public Project Proj { get; set; }

        public ProjectType selectedProjectType { get; set; }
        public int selectedDepartment { get; set; }

        //public IList<ProjectTask> Tasks { get; set; }
        //public IList<ProjectIssue> Issues { get; set; }

        //public IList<ProjectDocument> Documents { get; set; }
    }
}