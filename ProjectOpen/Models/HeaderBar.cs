using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectOpen.Models
{
    public class HeaderBar
    {
        public string User { get; set; }

        public int PendingTaskQty { get; set; }
        public int AlertQty { get; set; }
        public int MessageQty { get; set; }

        public IList<ProjectNotificationInstance> Messages { get; set; }
        public IList<ProjectNotificationInstance> Alerts { get; set; }
        public IList<ProjectTask> PendingTasks { get; set; }

    }
}