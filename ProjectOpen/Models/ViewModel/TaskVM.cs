using SDD.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectOpen.Models.ViewModel
{
    public class TaskVM
    {
        public HeaderVM Header { get; set; }

        public ProjectTask Task { get; set; }
        public IList<ProjectTaskType> AvailableTypes { get; set; }
        public IList<Staff> AvailableOwners { get; set; }
        public IList<Staff> AvailableAssignedUsers { get; set; }
        public IList<int> AvailableParentTaskId { get; set; }
    }
}