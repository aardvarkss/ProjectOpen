using NHibernate;
using SDD.Models;
using SDD.Models.ViewModel;
using ProjectOpen.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectOpen.Models;
using System.Diagnostics;

namespace ProjectOpen.Controllers
{
    public class HomeController : Controller
    {
        #region working


        private HeaderVM getHeaderInfo(List<string> bc, List<string> bcl, string title, string subTitle)
        {
            HeaderVM h = new HeaderVM();

            /* Page specifics - using parameters taken in */

            Breadcrumbs b = new Breadcrumbs();

            b.breadcrumbs = bc;

            b.breadcrumbsLink = bcl;

            h.brdcrm = b;

            HeadingLine hln = new HeadingLine();

            hln.GraphATitle = "Active Projects";
            hln.GraphBTitle = "Tasks Completed";

            List<int> l = new List<int> { 3, 7, 4, 6, 10, 12, 12, 12 };
            hln.GraphA = l;

            List<int> l2 = new List<int> { 16, 18, 13, 9, 12, 18, 19, 17, 3, 16, 12 };
            hln.GraphB = l2;

            hln.PageSubtitle = subTitle;
            hln.PageTitle = title;

            h.hl = hln;

            /* Generate sidebar menu */

            /* This probably needs to be database generated using the users access rights */

            SideBarMenu s = new SideBarMenu();
            MenuItem m = new MenuItem("icol-chart-bar", "", "Dashboard");
            s.addMenuItem(m);

            MenuItem m8 = new MenuItem("icol-clipboard-text", "/Home/Index", "Knowledge base");
            //s.addMenuItem(m8);

            MenuItem m2 = new MenuItem("icol-page-paste", "/Home/RaiseCall", "Raise Call");
            //s.addMenuItem(m2);

            MenuItem m7 = new MenuItem("icol-clipboard-text", "/Home/Index", "Asset Register");
            //s.addMenuItem(m7);

            MenuItem m3 = new MenuItem("icol-page-paste", "/Home/ChangeRequest", "Change Request");
            s.addMenuItem(m3);

            MenuItem m4 = new MenuItem("icol-clipboard-text", "/Home/Index", "Projects");
            s.addMenuItem(m4);

            MenuItem m9 = new MenuItem("icol-clipboard-text", "/Home/Index", "Help Desk");
            //s.addMenuItem(m9);

            MenuItem m5 = new MenuItem("icol-cog", "", "Administration");
            m5.addMenuSubItem(new MenuSubItem("icol-chart-organisation", "", "Department"));
            m5.addMenuSubItem(new MenuSubItem("icol-award-star-gold", "", "Status"));
            m5.addMenuSubItem(new MenuSubItem("icol-user-business-boss", "", "User"));
            s.addMenuItem(m5);

            //MenuItem m14 = new MenuItem("icol-chart-bar", "", "Support");
            //s.addMenuItem(m14);

            

            MenuItem m6 = new MenuItem("icol-key", "", "Log Out");
            s.addMenuItem(m6);

            h.sbm = s;

            HeaderBar hdr = new HeaderBar();

            hdr.User = "Martin N.";
            hdr.AlertQty = 3;
            hdr.PendingTaskQty = 12;
            hdr.MessageQty = 2;

            h.Hdr = hdr;

            return h;
        }

        //
        // GET: /Home/
        public ActionResult Index()
        {
            ProjectSummary p = new ProjectSummary();
            
            List<string> l = new List<string>();
            l.Add("Home");
            l.Add("Projects");

            List<string> l2 = new List<string>();
            l2.Add("/Home");
            l2.Add("/Home/Index");

            p.Header = getHeaderInfo(l, l2, "Project Summary", "Hi");
            
            // Get projects for summary

            IList<Project> queryResults;

            using (ISession session = Data.OpenSession())
            {
                using (ITransaction tx = session.BeginTransaction())
                {
                    //needs to be ordered by project type then department then due date descending
                    queryResults = session.CreateCriteria<Project>().SetMaxResults(1000).List<Project>();
                }
            }

            
            // Get all distinct types

            List<Project> typeList = queryResults
                    .GroupBy(a => a.ProjectProjectType.ProjectTypeDescription)
                    .Select(g => g.First())
                    .ToList();

            // Get all distinct departments

            List<Project> departmentList = queryResults
                    .GroupBy(a => a.ProjectGrouping.GroupingDescription)
                    .Select(g => g.First())
                    .ToList();

            
            // Loop types
            foreach (Project pt in typeList)
            {
                _projectTypeTable ptt = new _projectTypeTable();

                int projectCount = 0;
                ptt.projectTypeDescription = pt.ProjectProjectType.ProjectTypeDescription;
                
                // Loop departments
                foreach (Project pd in departmentList)
                {
                    // get all project for this type & department
                    var selectedProjects = queryResults.
                        Where(x => x.ProjectGroupingId == pd.ProjectGroupingId).
                        Where(x => x.ProjectProjectTypeId == pt.ProjectProjectTypeId);

                    // generate department table
                    ProjectDepartmentTable pdd = new ProjectDepartmentTable();
                    pdd.projectDepartmentDescription = pd.ProjectGrouping.GroupingDescription;
                    pdd.ProjectDepartmentTableCount = selectedProjects.Count();
                    pdd.Projects = selectedProjects.ToList<Project>();
                    pdd.QtyOfProjects = selectedProjects.Count();


                    // if there are any projects in this department, update the project type details
                    if (selectedProjects.Count() > 0)
                    {
                        Debug.Write(pt.ProjectProjectType.ProjectTypeDescription + "," + 
                            pd.ProjectGrouping.GroupingDescription + " -> " + 
                            selectedProjects.Count() + Environment.NewLine);

                        ptt.DepartmentGroups.Add(pdd);
                        ptt.QtyOfProjects += selectedProjects.Count();
                        projectCount += selectedProjects.Count();
                    }
                }

                // persist the project count to type
                ptt.QtyOfProjects = projectCount;

                // add project type to model
                p.Projects.Add(ptt);
            }

            return View(p);
        }

        
        [HttpGet]
        public ActionResult Project(int Id)
        {
            List<string> l = new List<string>();
            l.Add("Home");
            l.Add("Project");

            List<string> l2 = new List<string>();
            l2.Add("/Home");
            l2.Add("/Home/Index");

            ProjectDetail p = new ProjectDetail();

            using (ISession session = Data.OpenSession())
            {
                using (ITransaction tx = session.BeginTransaction())
                {
                    p.Proj = (Project)session.Load(typeof(Project), Id);

                    p.ProjectTypes = session.CreateCriteria<ProjectType>().SetMaxResults(1000).List<ProjectType>();
                    p.Departments = session.CreateCriteria<Grouping>().SetMaxResults(1000).List<Grouping>();

                    p.selectedDepartment = (short)p.Proj.ProjectGroupingId;

                    l.Add(p.Proj.ProjectName);
                    l2.Add("/Home/Project/1");
                }
            }

            p.Header = getHeaderInfo(l, l2, "Project Details", "Hi");

            return View(p);
        }

        //
        // POST: /Home/Project
        [HttpPost]
        public ActionResult Project(Project pr)
        {

            List<string> l = new List<string>();
            l.Add("Home");
            l.Add("Project");

            List<string> l2 = new List<string>();
            l2.Add("/Home");
            l2.Add("/Home/Index");

            ProjectDetail p = new ProjectDetail();

            using (ISession session = Data.OpenSession())
            {
                using (ITransaction tx = session.BeginTransaction())
                {
                    session.SaveOrUpdate(pr);

                    p.Proj = pr;

                    p.ProjectTypes = session.CreateCriteria<ProjectType>().SetMaxResults(1000).List<ProjectType>();
                    p.Departments = session.CreateCriteria<Grouping>().SetMaxResults(1000).List<Grouping>();

                    l.Add(p.Proj.ProjectName);
                    l2.Add("/Home/Project/" + pr.ProjectId);
                }
            }

            p.Header = getHeaderInfo(l, l2, "Project Details", "Hi");

            return View(p);
        }

        [HttpPost]
        public ActionResult UpdateProjectSubmit
            (int projId, string projName, DateTime createDate, string projOwner, Int16 projType, Int16 projDepartment)
        {
            List<string> l = new List<string>();
            l.Add("Home");
            l.Add("Project");

            List<string> l2 = new List<string>();
            l2.Add("/Home");
            l2.Add("/Home/Index");

            ProjectDetail p = new ProjectDetail();

            using (ISession session = Data.OpenSession())
            {
                using (ITransaction tx = session.BeginTransaction())
                {
                    
                    Project temp = (Project)session.Load(typeof(Project), projId);

                    //update the project with new details
                    temp.ProjectCreateDate = createDate;
                    temp.ProjectName = projName;
                    temp.ProjectProjectType = session.Get<ProjectType>(projType);
                    temp.ProjectProjectTypeId = projType;
                    temp.ProjectGrouping = session.Get<Grouping>(projDepartment);
                    temp.ProjectGroupingId = projDepartment;

                    p.selectedDepartment = projDepartment;

                    session.Update(temp);

                    p.Proj = temp;

                    p.ProjectTypes = session.CreateCriteria<ProjectType>().SetMaxResults(1000).List<ProjectType>();
                    p.Departments = session.CreateCriteria<Grouping>().SetMaxResults(1000).List<Grouping>();


                    l.Add(p.Proj.ProjectName);
                    l2.Add("/Home/Project/" + projId);

                    session.Transaction.Commit();

                }
            }

            p.Header = getHeaderInfo(l, l2, "Project Details", "Hi");

            return View("Project",p);
        }

        //
        // GET: /Home/ChangeRequest
        [HttpGet]
        public ActionResult ChangeRequest()
        {
            ChangeRequest r = new ChangeRequest();

            List<string> l = new List<string>();
            l.Add("Home");
            l.Add("Change Request");

            List<string> l2 = new List<string>();
            l2.Add("/Home");
            l2.Add("/Home/ChangeRequest");

            r.Header = getHeaderInfo(l, l2, "New Change Request", "Hi");

            using (ISession session = Data.OpenSession())
            {
               using (ITransaction tx = session.BeginTransaction())
               {
                   r.Requestors = session.CreateCriteria<Staff>().SetMaxResults(1000).List<Staff>();
                   r.Authorisers = session.CreateCriteria<Staff>().SetMaxResults(1000).List<Staff>();

                   r.Departments = session.CreateCriteria<Grouping>().SetMaxResults(1000).List<Grouping>();
               }
            }

            r.selectedAuthoriser = 1;
            r.selectedRequestor = 1;
            r.selectedDepartment = 2;

            return View(r);
        }

        [HttpPost]
        public ActionResult ChangeRequestSubmit(int reqBy, DateTime reqDate, short department, string costCentre,
            int authBy, DateTime authDate, string title, string changeDesc, string changeReason, string businessBenefits, string costSavings)
        {
           Project p;

           using (ISession session = Data.OpenSession())
           {
               using (ITransaction tx = session.BeginTransaction())
               {
                   RequestForWork e = new RequestForWork();
                   e.RequestForWorkCostCentre = costCentre;
                   e.RequestForWorkDescription = changeDesc;
                   e.RequestForWorkCreateDate = reqDate;
                   e.RequestForWorkAuthorisationDate = authDate;
                   e.RequestForWorkReason = changeReason;
                   e.RequestForWorkBusinessBenefits = businessBenefits;
                   e.RequestForWorkCostSavings = costSavings;
                   e.RequestForWorkDepartment = session.Get<Grouping>(department);
                   e.RequestForWorkRequestor = session.Get<Staff>(reqBy);
                   e.RequestForWorkAuthorisedBy = session.Get<Staff>(authBy);
                   e.RequestForWorkTitle = title;

                   session.SaveOrUpdate(e);

                   //create project
                   p = new ProjectOpen.Project();
                   p.ProjectName = title;
                   p.ProjectCreateDate = reqDate;
                   p.ProjectGrouping = session.Get<Grouping>(Int16.Parse(department.ToString()));
                   p.ProjectProjectType = session.Get<ProjectType>(Int16.Parse("5"));
                   p.ProjectOwner = session.Get<Staff>(1);

                   //create project task and complete for change request
                   ProjectTask pt = new ProjectTask();
                   pt.ProjectTaskCreateDate = reqDate;
                   pt.ProjectTaskEffort = 1;
                   pt.ProjectTaskDueDate = reqDate;
                   pt.ProjectTaskProgress = 1;
                   pt.ProjectTaskDescription = "Change Requested";
                   pt.ProjectTaskProjectTaskType = session.Get<ProjectTaskType>(1);
                   pt.ProjectTaskOwnerStaff = session.Get<Staff>(1);
                   pt.ProjectTaskParentProjectTask = pt;
                   pt.ProjectTaskAssignedStaff = session.Get<Staff>(1);
                   pt.ProjectTaskProgress = 1 * 100 / 1;
                   session.SaveOrUpdate(pt);

                   p.ProjectTasks.Add(pt);

                   //create project task for authorisation at zero % complete and look up due date
                   ProjectTask pt2 = new ProjectTask();
                   pt2.ProjectTaskCreateDate = reqDate;
                   pt2.ProjectTaskEffort = 1;
                   pt2.ProjectTaskDueDate = reqDate;
                   pt2.ProjectTaskProgress = 1;
                   pt2.ProjectTaskDescription = "Authorisation";
                   pt2.ProjectTaskProjectTaskType = session.Get<ProjectTaskType>(1);
                   pt2.ProjectTaskOwnerStaff = session.Get<Staff>(1);
                   pt2.ProjectTaskParentProjectTask = pt2;
                   pt2.ProjectTaskAssignedStaff = session.Get<Staff>(1);
                   pt2.ProjectTaskProgress = 0;
                   session.SaveOrUpdate(pt2);

                   p.ProjectTasks.Add(pt2);
                   

                   //create project task for specification at zero % complete and look up due date
                   ProjectTask pt3 = new ProjectTask();
                   pt3.ProjectTaskCreateDate = reqDate;
                   pt3.ProjectTaskEffort = 1;
                   pt3.ProjectTaskDueDate = reqDate;
                   pt3.ProjectTaskProgress = 1;
                   pt3.ProjectTaskDescription = "Specification";
                   pt3.ProjectTaskProjectTaskType = session.Get<ProjectTaskType>(1);
                   pt3.ProjectTaskOwnerStaff = session.Get<Staff>(1);
                   pt3.ProjectTaskParentProjectTask = pt3;
                   pt3.ProjectTaskAssignedStaff = session.Get<Staff>(1);
                   pt3.ProjectTaskProgress = 0;
                   session.SaveOrUpdate(pt3);

                   p.ProjectTasks.Add(pt3);

                   //create project task for specification at zero % complete and look up due date
                   ProjectTask pt4 = new ProjectTask();
                   pt4.ProjectTaskCreateDate = reqDate;
                   pt4.ProjectTaskEffort = 1;
                   pt4.ProjectTaskDueDate = reqDate;
                   pt4.ProjectTaskProgress = 1;
                   pt4.ProjectTaskDescription = "Quote";
                   pt4.ProjectTaskProjectTaskType = session.Get<ProjectTaskType>(1);
                   pt4.ProjectTaskOwnerStaff = session.Get<Staff>(1);
                   pt4.ProjectTaskParentProjectTask = pt4;
                   pt4.ProjectTaskAssignedStaff = session.Get<Staff>(1);
                   pt4.ProjectTaskProgress = 0;
                   session.SaveOrUpdate(pt4);

                   p.ProjectTasks.Add(pt4);

                   ProjectTask pt6 = new ProjectTask();
                   pt6.ProjectTaskCreateDate = reqDate;
                   pt6.ProjectTaskEffort = 1;
                   pt6.ProjectTaskDueDate = reqDate;
                   pt6.ProjectTaskProgress = 1;
                   pt6.ProjectTaskDescription = "Authorise Spend";
                   pt6.ProjectTaskProjectTaskType = session.Get<ProjectTaskType>(1);
                   pt6.ProjectTaskOwnerStaff = session.Get<Staff>(1);
                   pt6.ProjectTaskParentProjectTask = pt6;
                   pt6.ProjectTaskAssignedStaff = session.Get<Staff>(1);
                   pt6.ProjectTaskProgress = 0;
                   session.SaveOrUpdate(pt6);

                   p.ProjectTasks.Add(pt6);


                   ProjectTask pt5 = new ProjectTask();
                   pt5.ProjectTaskCreateDate = reqDate;
                   pt5.ProjectTaskEffort = 1;
                   pt5.ProjectTaskDueDate = reqDate;
                   pt5.ProjectTaskProgress = 1;
                   pt5.ProjectTaskDescription = "Development";
                   pt5.ProjectTaskProjectTaskType = session.Get<ProjectTaskType>(1);
                   pt5.ProjectTaskOwnerStaff = session.Get<Staff>(1);
                   pt5.ProjectTaskParentProjectTask = pt5;
                   pt5.ProjectTaskAssignedStaff = session.Get<Staff>(1);
                   pt5.ProjectTaskProgress = 0;
                   session.SaveOrUpdate(pt5);

                   p.ProjectTasks.Add(pt5);

                   session.SaveOrUpdate(p);


                   ProjectTask pt7 = new ProjectTask();
                   pt7.ProjectTaskCreateDate = reqDate;
                   pt7.ProjectTaskEffort = 1;
                   pt7.ProjectTaskDueDate = reqDate;
                   pt7.ProjectTaskProgress = 1;
                   pt7.ProjectTaskDescription = "Delivery";
                   pt7.ProjectTaskProjectTaskType = session.Get<ProjectTaskType>(1);
                   pt7.ProjectTaskOwnerStaff = session.Get<Staff>(1);
                   pt7.ProjectTaskParentProjectTask = pt7;
                   pt7.ProjectTaskAssignedStaff = session.Get<Staff>(1);
                   pt7.ProjectTaskProgress = 0;
                   session.SaveOrUpdate(pt7);

                   p.ProjectTasks.Add(pt7);

                   session.SaveOrUpdate(p);
                   //get this project id

                   tx.Commit();
               }
           }
           
           //redirect to project page
           //string redirection = "/Project/" + p.ProjectId;

           return RedirectToAction("Project",  "Home", new { id = p.ProjectId });
        }

        #endregion 

        public ActionResult NewTask()
        {
            TaskVM t = new TaskVM();

            List<string> l = new List<string>();
            l.Add("Home");
            l.Add("Projects");
            l.Add("Opex");
            l.Add("Create Task");

            List<string> l2 = new List<string>();
            l2.Add("/Home");
            l2.Add("/Home/Index");
            l2.Add("/Home/Project");
            l2.Add("/Home/Project/#");

            using (ISession session = Data.OpenSession())
            {
                using (ITransaction tx = session.BeginTransaction())
                {
                    t.AvailableAssignedUsers = session.CreateCriteria<Staff>().SetMaxResults(1000).List<Staff>();
                    t.AvailableOwners = session.CreateCriteria<Staff>().SetMaxResults(1000).List<Staff>();

                    t.AvailableTypes = session.CreateCriteria<ProjectTaskType>().SetMaxResults(1000).List<ProjectTaskType>();

                    t.Task = (ProjectTask)session.Load(typeof(ProjectTask),1);

                    // GET ALL TASK IDS WITHIN THIS PROJECT
                    //t.AvailableParentTaskId = ????
                }
            }

            t.Header = getHeaderInfo(l, l2, "Create Task", "Hi");

            return View(t);
        }

        public ActionResult ViewTask(Int32 Id)
        {
            TaskVM t = new TaskVM();

            List<string> l = new List<string>();
            l.Add("Home");
            l.Add("Projects");
            l.Add("Opex");
            l.Add("Create Task");

            List<string> l2 = new List<string>();
            l2.Add("/Home");
            l2.Add("/Home/Index");
            l2.Add("/Home/Project");
            l2.Add("/Home/Project/#");

            using (ISession session = Data.OpenSession())
            {
                using (ITransaction tx = session.BeginTransaction())
                {
                    t.AvailableAssignedUsers = session.CreateCriteria<Staff>().SetMaxResults(1000).List<Staff>();
                    t.AvailableOwners = session.CreateCriteria<Staff>().SetMaxResults(1000).List<Staff>();

                    t.AvailableTypes = session.CreateCriteria<ProjectTaskType>().SetMaxResults(1000).List<ProjectTaskType>();

                    t.Task = (ProjectTask)session.Load(typeof(ProjectTask), Id);

                    // GET ALL TASK IDS WITHIN THIS PROJECT
                    //t.AvailableParentTaskId = ????

                    /* get updates for task ordered by date */

                    
                }
            }

            t.Header = getHeaderInfo(l, l2, "View Task", "Hello");

            return View("ViewTask",t);
        }

        public ActionResult NewDocument()
        {
            List<string> l = new List<string>();
            l.Add("Home");
            l.Add("Document");

            List<string> l2 = new List<string>();
            l2.Add("/Home");
            l2.Add("/Home/NewDocument");

            return View(getHeaderInfo(l, l2, "Attatch Document", "Hi"));
        }

        public ActionResult NewIssue()
        {
            List<string> l = new List<string>();
            l.Add("Home");
            l.Add("Issue");

            List<string> l2 = new List<string>();
            l2.Add("/Home");
            l2.Add("/Home/NewIssue");

            return View(getHeaderInfo(l, l2, "Create Issue / Risk", "Hi"));
        }

    }
}