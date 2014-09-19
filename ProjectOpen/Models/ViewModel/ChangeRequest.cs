using SDD.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectOpen.Models.ViewModel
{
    public class ChangeRequest
    {
        public HeaderVM Header { get; set; }

        public IList<Staff> Requestors { get; set; }
        public IList<Staff> Authorisers { get; set; }
        public IList<Grouping> Departments { get; set; }
        
        public int selectedRequestor { get; set; }
        public int selectedAuthoriser { get; set; }
        public int selectedDepartment { get; set; }

        public string DescriptionOfChange { get; set; }
        public string ReasonForChange { get; set; }
        public string BusinessBenefits { get; set; }
        public string EstimatedCostSavings { get; set; }

        public DateTime RequestDate { get; set; }
        public DateTime AuthorisationDate { get; set; }
        public string CostCentre { get; set; }

        public string Title { get; set; }
    }
}