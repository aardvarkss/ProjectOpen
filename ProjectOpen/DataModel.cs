using System;
using System.Collections.Generic;
using NHibernate.Cfg;
using NHibernate.Validator.Constraints;

namespace ProjectOpen
{
  [System.CodeDom.Compiler.GeneratedCode("NHibernateModelGenerator", "1.0.0.0")]
  public partial class Grouping
  {
    public virtual short GroupingId { get; set; }
    public virtual System.Nullable<short> GroupingGroupingTypeId { get; set; }
    [Length(Max=64)]
    public virtual string GroupingDescription { get; set; }

    private IList<Project> _projects = new List<Project>();

    public virtual IList<Project> Projects
    {
      get { return _projects; }
      set { _projects = value; }
    }

    private IList<RequestForWork> _requestForWorks = new List<RequestForWork>();

    public virtual IList<RequestForWork> RequestForWorks
    {
      get { return _requestForWorks; }
      set { _requestForWorks = value; }
    }

    private IList<Staff> _staffs = new List<Staff>();

    public virtual IList<Staff> Staffs
    {
      get { return _staffs; }
      set { _staffs = value; }
    }

    public virtual GroupingType GroupingGroupingType { get; set; }

    static partial void CustomizeMappingDocument(System.Xml.Linq.XDocument mappingDocument);

    internal static System.Xml.Linq.XDocument MappingXml
    {
      get
      {
        var mappingDocument = System.Xml.Linq.XDocument.Parse(@"<?xml version='1.0' encoding='utf-8' ?>
<hibernate-mapping xmlns='urn:nhibernate-mapping-2.2'
                   assembly='" + typeof(Grouping).Assembly.GetName().Name + @"'
                   namespace='ProjectOpen'
                   >
  <class name='Grouping'
         table='Grouping'
         lazy='false'
         >
    <id name='GroupingId'
        column='Grouping_id'
        >
      <generator class='identity'>
      </generator>
    </id>
    <property name='GroupingGroupingTypeId'
              column='Grouping_groupingTypeId'
              insert='false'
              update='false'
              />
    <property name='GroupingDescription'
              column='Grouping_description'
              />
    <bag name='Projects'
          inverse='false'
          lazy='false'
          >
      <key column='Project_groupingId' />
      <one-to-many class='Project' />
    </bag>
    <bag name='RequestForWorks'
          inverse='false'
          >
      <key column='RequestForWork_department' />
      <one-to-many class='RequestForWork' />
    </bag>
    <bag name='Staffs'
          inverse='false'
          >
      <key column='Staff_groupingId' />
      <one-to-many class='Staff' />
    </bag>
    <many-to-one name='GroupingGroupingType' class='GroupingType' column='Grouping_groupingTypeId' />
  </class>
</hibernate-mapping>");
        CustomizeMappingDocument(mappingDocument);
        return mappingDocument;
      }
    }
  }

  [System.CodeDom.Compiler.GeneratedCode("NHibernateModelGenerator", "1.0.0.0")]
  public partial class Staff
  {
    public virtual int StaffId { get; set; }
    [Length(Max=32)]
    public virtual string StaffForename { get; set; }
    [Length(Max=32)]
    public virtual string StaffSurname { get; set; }
    [Length(Max=64)]
    [NotNull]
    public virtual string StaffDisplayName { get; set; }
    public virtual System.Nullable<int> StaffUserType { get; set; }
    [Length(Max=64)]
    public virtual string StaffEmailAddress { get; set; }
    [Length(Max=16)]
    public virtual string StaffContactNumber { get; set; }
    public virtual System.Nullable<short> StaffGroupingId { get; set; }
    public virtual System.Nullable<int> StaffDefaultAuthoriserId { get; set; }
    [Length(Max=8)]
    public virtual string StaffDefaultCostCentre { get; set; }

    private IList<Project> _projectsByProjectOwner = new List<Project>();

    public virtual IList<Project> ProjectsByProjectOwner
    {
      get { return _projectsByProjectOwner; }
      set { _projectsByProjectOwner = value; }
    }

    private IList<Project> _projectsByProjectProjectManager = new List<Project>();

    public virtual IList<Project> ProjectsByProjectProjectManager
    {
      get { return _projectsByProjectProjectManager; }
      set { _projectsByProjectProjectManager = value; }
    }

    private IList<ProjectTaskNotification> _projectTaskNotifications = new List<ProjectTaskNotification>();

    public virtual IList<ProjectTaskNotification> ProjectTaskNotifications
    {
      get { return _projectTaskNotifications; }
      set { _projectTaskNotifications = value; }
    }

    private IList<RequestForWork> _requestForWorksByRequestForWorkAuthorisedBy = new List<RequestForWork>();

    public virtual IList<RequestForWork> RequestForWorksByRequestForWorkAuthorisedBy
    {
      get { return _requestForWorksByRequestForWorkAuthorisedBy; }
      set { _requestForWorksByRequestForWorkAuthorisedBy = value; }
    }

    private IList<RequestForWork> _requestForWorksByRequestForWorkRequestor = new List<RequestForWork>();

    public virtual IList<RequestForWork> RequestForWorksByRequestForWorkRequestor
    {
      get { return _requestForWorksByRequestForWorkRequestor; }
      set { _requestForWorksByRequestForWorkRequestor = value; }
    }

    private IList<Staff> _staffs = new List<Staff>();

    public virtual IList<Staff> Staffs
    {
      get { return _staffs; }
      set { _staffs = value; }
    }

    private IList<ProjectDocument> _projectDocumentsByProjectDocumentUser = new List<ProjectDocument>();

    public virtual IList<ProjectDocument> ProjectDocumentsByProjectDocumentUser
    {
      get { return _projectDocumentsByProjectDocumentUser; }
      set { _projectDocumentsByProjectDocumentUser = value; }
    }

    private IList<ProjectTask> _projectTasksByProjectTaskOwnerStaff = new List<ProjectTask>();

    public virtual IList<ProjectTask> ProjectTasksByProjectTaskOwnerStaff
    {
      get { return _projectTasksByProjectTaskOwnerStaff; }
      set { _projectTasksByProjectTaskOwnerStaff = value; }
    }

    private IList<ProjectTask> _projectTasksByProjectTaskAssignedStaff = new List<ProjectTask>();

    public virtual IList<ProjectTask> ProjectTasksByProjectTaskAssignedStaff
    {
      get { return _projectTasksByProjectTaskAssignedStaff; }
      set { _projectTasksByProjectTaskAssignedStaff = value; }
    }

    public virtual Grouping StaffGrouping { get; set; }

    public virtual Staff StaffDefaultAuthoriser { get; set; }

    static partial void CustomizeMappingDocument(System.Xml.Linq.XDocument mappingDocument);

    internal static System.Xml.Linq.XDocument MappingXml
    {
      get
      {
        var mappingDocument = System.Xml.Linq.XDocument.Parse(@"<?xml version='1.0' encoding='utf-8' ?>
<hibernate-mapping xmlns='urn:nhibernate-mapping-2.2'
                   assembly='" + typeof(Staff).Assembly.GetName().Name + @"'
                   namespace='ProjectOpen'
                   >
  <class name='Staff'
         table='Staff'
         lazy='false'
         >
    <id name='StaffId'
        column='Staff_id'
        >
      <generator class='identity'>
      </generator>
    </id>
    <property name='StaffForename'
              column='Staff_forename'
              />
    <property name='StaffSurname'
              column='Staff_surname'
              />
    <property name='StaffDisplayName'
              column='Staff_displayName'
              />
    <property name='StaffUserType'
              column='Staff_userType'
              />
    <property name='StaffEmailAddress'
              column='Staff_emailAddress'
              />
    <property name='StaffContactNumber'
              column='Staff_contactNumber'
              />
    <property name='StaffGroupingId'
              column='Staff_groupingId'
              insert='false'
              update='false'
              />
    <property name='StaffDefaultAuthoriserId'
              column='Staff_defaultAuthoriserId'
              insert='false'
              update='false'
              />
    <property name='StaffDefaultCostCentre'
              column='Staff_defaultCostCentre'
              />
    <bag name='ProjectsByProjectOwner'
          inverse='false'
          lazy='false'
          >
      <key column='Project_ownerId' />
      <one-to-many class='Project' />
    </bag>
    <bag name='ProjectsByProjectProjectManager'
          inverse='false'
          >
      <key column='Project_projectManager' />
      <one-to-many class='Project' />
    </bag>
    <bag name='ProjectTaskNotifications'
          inverse='false'
          >
      <key column='ProjectTaskNotification_staffId' />
      <one-to-many class='ProjectTaskNotification' />
    </bag>
    <bag name='RequestForWorksByRequestForWorkAuthorisedBy'
          inverse='false'
          >
      <key column='RequestForWork_authorisedById' />
      <one-to-many class='RequestForWork' />
    </bag>
    <bag name='RequestForWorksByRequestForWorkRequestor'
          inverse='false'
          >
      <key column='RequestForWork_requestorId' />
      <one-to-many class='RequestForWork' />
    </bag>
    <bag name='Staffs'
          inverse='false'
          >
      <key column='Staff_defaultAuthoriserId' />
      <one-to-many class='Staff' />
    </bag>
    <bag name='ProjectDocumentsByProjectDocumentUser'
          inverse='false'
          >
      <key column='ProjectDocument_userId' />
      <one-to-many class='ProjectDocument' />
    </bag>
    <bag name='ProjectTasksByProjectTaskOwnerStaff'
          inverse='false'
          lazy='false'
          >
      <key column='ProjectTask_ownerStaffId' />
      <one-to-many class='ProjectTask' />
    </bag>
    <bag name='ProjectTasksByProjectTaskAssignedStaff'
          inverse='false'
          >
      <key column='ProjectTask_assignedStaffId' />
      <one-to-many class='ProjectTask' />
    </bag>
    <many-to-one name='StaffGrouping' class='Grouping' column='Staff_groupingId' />
    <many-to-one name='StaffDefaultAuthoriser' class='Staff' column='Staff_defaultAuthoriserId' />
  </class>
</hibernate-mapping>");
        CustomizeMappingDocument(mappingDocument);
        return mappingDocument;
      }
    }
  }

  [System.CodeDom.Compiler.GeneratedCode("NHibernateModelGenerator", "1.0.0.0")]
  public partial class GroupingType
  {
    public virtual short GroupingTypeId { get; set; }
    [Length(Max=32)]
    public virtual string GroupingTypeDescription { get; set; }

    private IList<Grouping> _groupings = new List<Grouping>();

    public virtual IList<Grouping> Groupings
    {
      get { return _groupings; }
      set { _groupings = value; }
    }

    static partial void CustomizeMappingDocument(System.Xml.Linq.XDocument mappingDocument);

    internal static System.Xml.Linq.XDocument MappingXml
    {
      get
      {
        var mappingDocument = System.Xml.Linq.XDocument.Parse(@"<?xml version='1.0' encoding='utf-8' ?>
<hibernate-mapping xmlns='urn:nhibernate-mapping-2.2'
                   assembly='" + typeof(GroupingType).Assembly.GetName().Name + @"'
                   namespace='ProjectOpen'
                   >
  <class name='GroupingType'
         table='GroupingType'
         >
    <id name='GroupingTypeId'
        column='GroupingType_id'
        >
      <generator class='identity'>
      </generator>
    </id>
    <property name='GroupingTypeDescription'
              column='GroupingType_description'
              />
    <bag name='Groupings'
          inverse='false'
          >
      <key column='Grouping_groupingTypeId' />
      <one-to-many class='Grouping' />
    </bag>
  </class>
</hibernate-mapping>");
        CustomizeMappingDocument(mappingDocument);
        return mappingDocument;
      }
    }
  }

  [System.CodeDom.Compiler.GeneratedCode("NHibernateModelGenerator", "1.0.0.0")]
  public partial class Project
  {
    public virtual int ProjectId { get; set; }
    [Length(Max=32)]
    public virtual string ProjectName { get; set; }
    public virtual System.Nullable<int> ProjectOwnerId { get; set; }
    [NotNull]
    public virtual System.DateTime ProjectCreateDate { get; set; }
    public virtual System.Nullable<short> ProjectGroupingId { get; set; }
    public virtual System.Nullable<short> ProjectProjectTypeId { get; set; }
    public virtual System.Nullable<int> ProjectProjectManagerId { get; set; }

    private IList<ProjectTask> _projectTasks = new List<ProjectTask>();

    public virtual IList<ProjectTask> ProjectTasks
    {
      get { return _projectTasks; }
      set { _projectTasks = value; }
    }

    private IList<ProjectTaskNotification> _projectTaskNotifications = new List<ProjectTaskNotification>();

    public virtual IList<ProjectTaskNotification> ProjectTaskNotifications
    {
      get { return _projectTaskNotifications; }
      set { _projectTaskNotifications = value; }
    }

    private IList<ProjectIssue> _projectIssuesByProjectIssueProject = new List<ProjectIssue>();

    public virtual IList<ProjectIssue> ProjectIssuesByProjectIssueProject
    {
      get { return _projectIssuesByProjectIssueProject; }
      set { _projectIssuesByProjectIssueProject = value; }
    }

    private IList<ProjectDocument> _projectDocumentsByProjectDocumentProject = new List<ProjectDocument>();

    public virtual IList<ProjectDocument> ProjectDocumentsByProjectDocumentProject
    {
      get { return _projectDocumentsByProjectDocumentProject; }
      set { _projectDocumentsByProjectDocumentProject = value; }
    }

    public virtual Grouping ProjectGrouping { get; set; }

    public virtual Staff ProjectOwner { get; set; }

    public virtual Staff ProjectProjectManager { get; set; }

    public virtual ProjectType ProjectProjectType { get; set; }

    static partial void CustomizeMappingDocument(System.Xml.Linq.XDocument mappingDocument);

    internal static System.Xml.Linq.XDocument MappingXml
    {
      get
      {
        var mappingDocument = System.Xml.Linq.XDocument.Parse(@"<?xml version='1.0' encoding='utf-8' ?>
<hibernate-mapping xmlns='urn:nhibernate-mapping-2.2'
                   assembly='" + typeof(Project).Assembly.GetName().Name + @"'
                   namespace='ProjectOpen'
                   >
  <class name='Project'
         table='Project'
         lazy='false'
         >
    <id name='ProjectId'
        column='Project_id'
        >
      <generator class='identity'>
      </generator>
    </id>
    <property name='ProjectName'
              column='Project_name'
              />
    <property name='ProjectOwnerId'
              column='Project_ownerId'
              insert='false'
              update='false'
              />
    <property name='ProjectCreateDate'
              column='Project_createDate'
              />
    <property name='ProjectGroupingId'
              column='Project_groupingId'
              insert='false'
              update='false'
              />
    <property name='ProjectProjectTypeId'
              column='Project_projectTypeId'
              insert='false'
              update='false'
              />
    <property name='ProjectProjectManagerId'
              column='Project_projectManager'
              insert='false'
              update='false'
              />
    <bag name='ProjectTasks'
          inverse='false'
          lazy='false'
          >
      <key column='ProjectTask_projectId' />
      <one-to-many class='ProjectTask' />
    </bag>
    <bag name='ProjectTaskNotifications'
          inverse='false'
          >
      <key column='ProjectTaskNotification_projectId' />
      <one-to-many class='ProjectTaskNotification' />
    </bag>
    <bag name='ProjectIssuesByProjectIssueProject'
          inverse='false'
          lazy='false'
          >
      <key column='ProjectIssue_projectId' />
      <one-to-many class='ProjectIssue' />
    </bag>
    <bag name='ProjectDocumentsByProjectDocumentProject'
          inverse='false'
          lazy='false'
          >
      <key column='ProjectDocument_projectId' />
      <one-to-many class='ProjectDocument' />
    </bag>
    <many-to-one name='ProjectGrouping' class='Grouping' column='Project_groupingId' />
    <many-to-one name='ProjectOwner' class='Staff' column='Project_ownerId' />
    <many-to-one name='ProjectProjectManager' class='Staff' column='Project_projectManager' />
    <many-to-one name='ProjectProjectType' class='ProjectType' column='Project_projectTypeId' />
  </class>
</hibernate-mapping>");
        CustomizeMappingDocument(mappingDocument);
        return mappingDocument;
      }
    }
  }

  [System.CodeDom.Compiler.GeneratedCode("NHibernateModelGenerator", "1.0.0.0")]
  public partial class ProjectIssueSeverity
  {
    public virtual short ProjectIssueSeverityId { get; set; }
    [Length(Max=32)]
    public virtual string ProjectIssueSeverityDescription { get; set; }
    public virtual System.Nullable<short> ProjectIssueSeverityOrder { get; set; }
    public virtual System.Nullable<bool> ProjectIssueSeverityRiskFlag { get; set; }
    public virtual System.Nullable<bool> ProjectIssueSeverityIssueFlag { get; set; }

    private IList<ProjectIssue> _projectIssuesByProjectIssueSeverity = new List<ProjectIssue>();

    public virtual IList<ProjectIssue> ProjectIssuesByProjectIssueSeverity
    {
      get { return _projectIssuesByProjectIssueSeverity; }
      set { _projectIssuesByProjectIssueSeverity = value; }
    }

    static partial void CustomizeMappingDocument(System.Xml.Linq.XDocument mappingDocument);

    internal static System.Xml.Linq.XDocument MappingXml
    {
      get
      {
        var mappingDocument = System.Xml.Linq.XDocument.Parse(@"<?xml version='1.0' encoding='utf-8' ?>
<hibernate-mapping xmlns='urn:nhibernate-mapping-2.2'
                   assembly='" + typeof(ProjectIssueSeverity).Assembly.GetName().Name + @"'
                   namespace='ProjectOpen'
                   >
  <class name='ProjectIssueSeverity'
         table='ProjectIssueSeverity'
         >
    <id name='ProjectIssueSeverityId'
        column='ProjectIssueSeverity_id'
        >
      <generator class='identity'>
      </generator>
    </id>
    <property name='ProjectIssueSeverityDescription'
              column='ProjectIssueSeverity_description'
              />
    <property name='ProjectIssueSeverityOrder'
              column='ProjectIssueSeverity_order'
              />
    <property name='ProjectIssueSeverityRiskFlag'
              column='ProjectIssueSeverity_riskFlag'
              />
    <property name='ProjectIssueSeverityIssueFlag'
              column='ProjectIssueSeverity_issueFlag'
              />
    <bag name='ProjectIssuesByProjectIssueSeverity'
          inverse='false'
          >
      <key column='ProjectIssue_severityId' />
      <one-to-many class='ProjectIssue' />
    </bag>
  </class>
</hibernate-mapping>");
        CustomizeMappingDocument(mappingDocument);
        return mappingDocument;
      }
    }
  }

  [System.CodeDom.Compiler.GeneratedCode("NHibernateModelGenerator", "1.0.0.0")]
  public partial class ProjectNotificationInstance
  {
    public virtual int ProjectNotificationInstanceId { get; set; }
    public virtual System.Nullable<int> ProjectNotificationInstanceNotificationId { get; set; }
    public virtual System.Nullable<System.DateTime> ProjectNotificationInstanceCreateDate { get; set; }
    public virtual System.Nullable<System.DateTime> ProjectNotificationInstanceViewDate { get; set; }
    [Length(Max=256)]
    public virtual string ProjectNotificationInstanceDescription { get; set; }

    public virtual ProjectTaskNotification ProjectNotificationInstanceNotification { get; set; }

    static partial void CustomizeMappingDocument(System.Xml.Linq.XDocument mappingDocument);

    internal static System.Xml.Linq.XDocument MappingXml
    {
      get
      {
        var mappingDocument = System.Xml.Linq.XDocument.Parse(@"<?xml version='1.0' encoding='utf-8' ?>
<hibernate-mapping xmlns='urn:nhibernate-mapping-2.2'
                   assembly='" + typeof(ProjectNotificationInstance).Assembly.GetName().Name + @"'
                   namespace='ProjectOpen'
                   >
  <class name='ProjectNotificationInstance'
         table='ProjectNotificationInstance'
         >
    <id name='ProjectNotificationInstanceId'
        column='ProjectNotificationInstance_id'
        >
      <generator class='identity'>
      </generator>
    </id>
    <property name='ProjectNotificationInstanceNotificationId'
              column='ProjectNotificationInstance_notificationId'
              insert='false'
              update='false'
              />
    <property name='ProjectNotificationInstanceCreateDate'
              column='ProjectNotificationInstance_createDate'
              />
    <property name='ProjectNotificationInstanceViewDate'
              column='ProjectNotificationInstance_viewDate'
              />
    <property name='ProjectNotificationInstanceDescription'
              column='ProjectNotificationInstance_description'
              />
    <many-to-one name='ProjectNotificationInstanceNotification' class='ProjectTaskNotification' column='ProjectNotificationInstance_notificationId' />
  </class>
</hibernate-mapping>");
        CustomizeMappingDocument(mappingDocument);
        return mappingDocument;
      }
    }
  }

  [System.CodeDom.Compiler.GeneratedCode("NHibernateModelGenerator", "1.0.0.0")]
  public partial class ProjectTask
  {
    public virtual int ProjectTaskId { get; set; }
    [Length(Max=32)]
    public virtual string ProjectTaskDescription { get; set; }
    [NotNull]
    public virtual int ProjectTaskProjectTaskTypeId { get; set; }
    public virtual System.Nullable<short> ProjectTaskProgress { get; set; }
    [NotNull]
    public virtual System.DateTime ProjectTaskCreateDate { get; set; }
    [NotNull]
    public virtual System.DateTime ProjectTaskDueDate { get; set; }
    public virtual System.Nullable<int> ProjectTaskEffort { get; set; }
    public virtual System.Nullable<int> ProjectTaskProjectId { get; set; }
    public virtual System.Nullable<int> ProjectTaskOwnerStaffId { get; set; }
    public virtual System.Nullable<int> ProjectTaskAssignedStaffId { get; set; }
    public virtual System.Nullable<int> ProjectTaskParentProjectTaskId { get; set; }
    [Length(Max=32)]
    public virtual string ProjectTaskTitle { get; set; }
    [Length(Max=500)]
    public virtual string ProjectTaskLongDescription { get; set; }

    private IList<ProjectTask> _projectTasks = new List<ProjectTask>();

    public virtual IList<ProjectTask> ProjectTasks
    {
      get { return _projectTasks; }
      set { _projectTasks = value; }
    }

    private IList<ProjectTaskNotification> _projectTaskNotifications = new List<ProjectTaskNotification>();

    public virtual IList<ProjectTaskNotification> ProjectTaskNotifications
    {
      get { return _projectTaskNotifications; }
      set { _projectTaskNotifications = value; }
    }

    private IList<ProjectUpdate> _projectUpdates = new List<ProjectUpdate>();

    public virtual IList<ProjectUpdate> ProjectUpdates
    {
      get { return _projectUpdates; }
      set { _projectUpdates = value; }
    }

    private IList<ProjectNote> _projectNotes = new List<ProjectNote>();

    public virtual IList<ProjectNote> ProjectNotes
    {
      get { return _projectNotes; }
      set { _projectNotes = value; }
    }

    private IList<ProjectIssue> _projectIssuesByProjectIssueProjectTask = new List<ProjectIssue>();

    public virtual IList<ProjectIssue> ProjectIssuesByProjectIssueProjectTask
    {
      get { return _projectIssuesByProjectIssueProjectTask; }
      set { _projectIssuesByProjectIssueProjectTask = value; }
    }

    private IList<ProjectDocument> _projectDocumentsByProjectDocumentProjectTask = new List<ProjectDocument>();

    public virtual IList<ProjectDocument> ProjectDocumentsByProjectDocumentProjectTask
    {
      get { return _projectDocumentsByProjectDocumentProjectTask; }
      set { _projectDocumentsByProjectDocumentProjectTask = value; }
    }

    public virtual Staff ProjectTaskOwnerStaff { get; set; }

    public virtual Staff ProjectTaskAssignedStaff { get; set; }

    public virtual Project ProjectTaskProject { get; set; }

    public virtual ProjectTask ProjectTaskParentProjectTask { get; set; }

    public virtual ProjectTaskType ProjectTaskProjectTaskType { get; set; }

    static partial void CustomizeMappingDocument(System.Xml.Linq.XDocument mappingDocument);

    internal static System.Xml.Linq.XDocument MappingXml
    {
      get
      {
        var mappingDocument = System.Xml.Linq.XDocument.Parse(@"<?xml version='1.0' encoding='utf-8' ?>
<hibernate-mapping xmlns='urn:nhibernate-mapping-2.2'
                   assembly='" + typeof(ProjectTask).Assembly.GetName().Name + @"'
                   namespace='ProjectOpen'
                   >
  <class name='ProjectTask'
         table='ProjectTask'
         lazy='false'
         >
    <id name='ProjectTaskId'
        column='ProjectTask_id'
        >
      <generator class='identity'>
      </generator>
    </id>
    <property name='ProjectTaskDescription'
              column='ProjectTask_description'
              />
    <property name='ProjectTaskProjectTaskTypeId'
              column='ProjectTask_projectTaskTypeId'
              insert='false'
              update='false'
              />
    <property name='ProjectTaskProgress'
              column='ProjectTask_progress'
              />
    <property name='ProjectTaskCreateDate'
              column='ProjectTask_createDate'
              />
    <property name='ProjectTaskDueDate'
              column='ProjectTask_dueDate'
              />
    <property name='ProjectTaskEffort'
              column='ProjectTask_effort'
              />
    <property name='ProjectTaskProjectId'
              column='ProjectTask_projectId'
              insert='false'
              update='false'
              />
    <property name='ProjectTaskOwnerStaffId'
              column='ProjectTask_ownerStaffId'
              insert='false'
              update='false'
              />
    <property name='ProjectTaskAssignedStaffId'
              column='ProjectTask_assignedStaffId'
              insert='false'
              update='false'
              />
    <property name='ProjectTaskParentProjectTaskId'
              column='ProjectTask_parentProjectTaskId'
              insert='false'
              update='false'
              />
    <property name='ProjectTaskTitle'
              column='ProjectTask_title'
              />
    <property name='ProjectTaskLongDescription'
              column='ProjectTask_longDescription'
              />
    <bag name='ProjectTasks'
          inverse='false'
          >
      <key column='ProjectTask_parentProjectTaskId' />
      <one-to-many class='ProjectTask' />
    </bag>
    <bag name='ProjectTaskNotifications'
          inverse='false'
          >
      <key column='ProjectTaskNotification_projectTaskId' />
      <one-to-many class='ProjectTaskNotification' />
    </bag>
    <bag name='ProjectUpdates'
          inverse='false'
          lazy='false'
          >
      <key column='ProjectUpdate_projectTaskId' />
      <one-to-many class='ProjectUpdate' />
    </bag>
    <bag name='ProjectNotes'
          inverse='false'
          >
      <key column='ProjectNote_projectTaskId' />
      <one-to-many class='ProjectNote' />
    </bag>
    <bag name='ProjectIssuesByProjectIssueProjectTask'
          inverse='false'
          lazy='false'
          >
      <key column='ProjectIssue_projectTaskId' />
      <one-to-many class='ProjectIssue' />
    </bag>
    <bag name='ProjectDocumentsByProjectDocumentProjectTask'
          inverse='false'
          lazy='false'
          >
      <key column='ProjectDocument_projectTaskId' />
      <one-to-many class='ProjectDocument' />
    </bag>
    <many-to-one name='ProjectTaskOwnerStaff' class='Staff' column='ProjectTask_ownerStaffId' />
    <many-to-one name='ProjectTaskAssignedStaff' class='Staff' column='ProjectTask_assignedStaffId' />
    <many-to-one name='ProjectTaskProject' class='Project' column='ProjectTask_projectId' />
    <many-to-one name='ProjectTaskParentProjectTask' class='ProjectTask' column='ProjectTask_parentProjectTaskId' />
    <many-to-one name='ProjectTaskProjectTaskType' class='ProjectTaskType' column='ProjectTask_projectTaskTypeId' />
  </class>
</hibernate-mapping>");
        CustomizeMappingDocument(mappingDocument);
        return mappingDocument;
      }
    }
  }

  [System.CodeDom.Compiler.GeneratedCode("NHibernateModelGenerator", "1.0.0.0")]
  public partial class ProjectTaskNotification
  {
    public virtual int ProjectTaskNotificationId { get; set; }
    public virtual System.Nullable<int> ProjectTaskNotificationProjectTaskId { get; set; }
    public virtual System.Nullable<bool> ProjectTaskNotificationUpdate { get; set; }
    public virtual System.Nullable<bool> ProjectTaskNotificationCompletion { get; set; }
    public virtual System.Nullable<bool> ProjectTaskNotificationOverdue { get; set; }
    public virtual System.Nullable<System.DateTime> ProjectTaskNotificationCreateDate { get; set; }
    public virtual System.Nullable<int> ProjectTaskNotificationProjectId { get; set; }
    public virtual System.Nullable<int> ProjectTaskNotificationStaffId { get; set; }

    private IList<ProjectNotificationInstance> _projectNotificationInstances = new List<ProjectNotificationInstance>();

    public virtual IList<ProjectNotificationInstance> ProjectNotificationInstances
    {
      get { return _projectNotificationInstances; }
      set { _projectNotificationInstances = value; }
    }

    public virtual Staff ProjectTaskNotificationStaff { get; set; }

    public virtual Project ProjectTaskNotificationProject { get; set; }

    public virtual ProjectTask ProjectTaskNotificationProjectTask { get; set; }

    static partial void CustomizeMappingDocument(System.Xml.Linq.XDocument mappingDocument);

    internal static System.Xml.Linq.XDocument MappingXml
    {
      get
      {
        var mappingDocument = System.Xml.Linq.XDocument.Parse(@"<?xml version='1.0' encoding='utf-8' ?>
<hibernate-mapping xmlns='urn:nhibernate-mapping-2.2'
                   assembly='" + typeof(ProjectTaskNotification).Assembly.GetName().Name + @"'
                   namespace='ProjectOpen'
                   >
  <class name='ProjectTaskNotification'
         table='ProjectTaskNotification'
         >
    <id name='ProjectTaskNotificationId'
        column='ProjectTaskNotification_id'
        >
      <generator class='identity'>
      </generator>
    </id>
    <property name='ProjectTaskNotificationProjectTaskId'
              column='ProjectTaskNotification_projectTaskId'
              insert='false'
              update='false'
              />
    <property name='ProjectTaskNotificationUpdate'
              column='ProjectTaskNotification_update'
              />
    <property name='ProjectTaskNotificationCompletion'
              column='ProjectTaskNotification_completion'
              />
    <property name='ProjectTaskNotificationOverdue'
              column='ProjectTaskNotification_overdue'
              />
    <property name='ProjectTaskNotificationCreateDate'
              column='ProjectTaskNotification_createDate'
              />
    <property name='ProjectTaskNotificationProjectId'
              column='ProjectTaskNotification_projectId'
              insert='false'
              update='false'
              />
    <property name='ProjectTaskNotificationStaffId'
              column='ProjectTaskNotification_staffId'
              insert='false'
              update='false'
              />
    <bag name='ProjectNotificationInstances'
          inverse='false'
          >
      <key column='ProjectNotificationInstance_notificationId' />
      <one-to-many class='ProjectNotificationInstance' />
    </bag>
    <many-to-one name='ProjectTaskNotificationStaff' class='Staff' column='ProjectTaskNotification_staffId' />
    <many-to-one name='ProjectTaskNotificationProject' class='Project' column='ProjectTaskNotification_projectId' />
    <many-to-one name='ProjectTaskNotificationProjectTask' class='ProjectTask' column='ProjectTaskNotification_projectTaskId' />
  </class>
</hibernate-mapping>");
        CustomizeMappingDocument(mappingDocument);
        return mappingDocument;
      }
    }
  }

  [System.CodeDom.Compiler.GeneratedCode("NHibernateModelGenerator", "1.0.0.0")]
  public partial class ProjectTaskType
  {
    public virtual int ProjectTaskTypeId { get; set; }
    [Length(Max=64)]
    public virtual string ProjectTaskTypeDescription { get; set; }

    private IList<ProjectTask> _projectTasks = new List<ProjectTask>();

    public virtual IList<ProjectTask> ProjectTasks
    {
      get { return _projectTasks; }
      set { _projectTasks = value; }
    }

    static partial void CustomizeMappingDocument(System.Xml.Linq.XDocument mappingDocument);

    internal static System.Xml.Linq.XDocument MappingXml
    {
      get
      {
        var mappingDocument = System.Xml.Linq.XDocument.Parse(@"<?xml version='1.0' encoding='utf-8' ?>
<hibernate-mapping xmlns='urn:nhibernate-mapping-2.2'
                   assembly='" + typeof(ProjectTaskType).Assembly.GetName().Name + @"'
                   namespace='ProjectOpen'
                   >
  <class name='ProjectTaskType'
         table='ProjectTaskType'
         lazy='false'
         >
    <id name='ProjectTaskTypeId'
        column='ProjectTaskType_id'
        >
      <generator class='identity'>
      </generator>
    </id>
    <property name='ProjectTaskTypeDescription'
              column='ProjectTaskType_description'
              />
    <bag name='ProjectTasks'
          inverse='true'
          >
      <key column='ProjectTask_projectTaskTypeId' />
      <one-to-many class='ProjectTask' />
    </bag>
  </class>
</hibernate-mapping>");
        CustomizeMappingDocument(mappingDocument);
        return mappingDocument;
      }
    }
  }

  [System.CodeDom.Compiler.GeneratedCode("NHibernateModelGenerator", "1.0.0.0")]
  public partial class ProjectType
  {
    public virtual short ProjectTypeId { get; set; }
    [Length(Max=32)]
    public virtual string ProjectTypeDescription { get; set; }

    private IList<Project> _projects = new List<Project>();

    public virtual IList<Project> Projects
    {
      get { return _projects; }
      set { _projects = value; }
    }

    static partial void CustomizeMappingDocument(System.Xml.Linq.XDocument mappingDocument);

    internal static System.Xml.Linq.XDocument MappingXml
    {
      get
      {
        var mappingDocument = System.Xml.Linq.XDocument.Parse(@"<?xml version='1.0' encoding='utf-8' ?>
<hibernate-mapping xmlns='urn:nhibernate-mapping-2.2'
                   assembly='" + typeof(ProjectType).Assembly.GetName().Name + @"'
                   namespace='ProjectOpen'
                   >
  <class name='ProjectType'
         table='ProjectType'
         lazy='false'
         >
    <id name='ProjectTypeId'
        column='ProjectType_id'
        >
      <generator class='identity'>
      </generator>
    </id>
    <property name='ProjectTypeDescription'
              column='ProjectType_description'
              />
    <bag name='Projects'
          inverse='false'
          >
      <key column='Project_projectTypeId' />
      <one-to-many class='Project' />
    </bag>
  </class>
</hibernate-mapping>");
        CustomizeMappingDocument(mappingDocument);
        return mappingDocument;
      }
    }
  }

  [System.CodeDom.Compiler.GeneratedCode("NHibernateModelGenerator", "1.0.0.0")]
  public partial class ProjectUpdate
  {
    public virtual int ProjectUpdateId { get; set; }
    [NotNull]
    public virtual System.DateTime ProjectUpdateCreateDate { get; set; }
    [NotNull]
    public virtual System.DateTime ProjectUpdatePostDate { get; set; }
    public virtual System.Nullable<short> ProjectUpdateUpdateTypeId { get; set; }
    public virtual System.Nullable<int> ProjectUpdateProjectTaskId { get; set; }
    [Length(Max=300)]
    public virtual string ProjectUpdateDescription { get; set; }

    public virtual ProjectTask ProjectUpdateProjectTask { get; set; }

    public virtual ProjectUpdateType ProjectUpdateUpdateType { get; set; }

    static partial void CustomizeMappingDocument(System.Xml.Linq.XDocument mappingDocument);

    internal static System.Xml.Linq.XDocument MappingXml
    {
      get
      {
        var mappingDocument = System.Xml.Linq.XDocument.Parse(@"<?xml version='1.0' encoding='utf-8' ?>
<hibernate-mapping xmlns='urn:nhibernate-mapping-2.2'
                   assembly='" + typeof(ProjectUpdate).Assembly.GetName().Name + @"'
                   namespace='ProjectOpen'
                   >
  <class name='ProjectUpdate'
         table='ProjectUpdate'
         lazy='false'
         >
    <id name='ProjectUpdateId'
        column='ProjectUpdate_id'
        >
      <generator class='identity'>
      </generator>
    </id>
    <property name='ProjectUpdateCreateDate'
              column='ProjectUpdate_createDate'
              />
    <property name='ProjectUpdatePostDate'
              column='ProjectUpdate_postDate'
              />
    <property name='ProjectUpdateUpdateTypeId'
              column='ProjectUpdate_updateTypeId'
              insert='false'
              update='false'
              />
    <property name='ProjectUpdateProjectTaskId'
              column='ProjectUpdate_projectTaskId'
              insert='false'
              update='false'
              />
    <property name='ProjectUpdateDescription'
              column='ProjectUpdate_description'
              />
    <many-to-one name='ProjectUpdateProjectTask' class='ProjectTask' column='ProjectUpdate_projectTaskId' />
    <many-to-one name='ProjectUpdateUpdateType' class='ProjectUpdateType' column='ProjectUpdate_updateTypeId' />
  </class>
</hibernate-mapping>");
        CustomizeMappingDocument(mappingDocument);
        return mappingDocument;
      }
    }
  }

  [System.CodeDom.Compiler.GeneratedCode("NHibernateModelGenerator", "1.0.0.0")]
  public partial class ProjectUpdateType
  {
    public virtual short ProjectUpdateTypeId { get; set; }
    [Length(Max=32)]
    public virtual string ProjectUpdateTypeDescription { get; set; }

    private IList<ProjectUpdate> _projectUpdates = new List<ProjectUpdate>();

    public virtual IList<ProjectUpdate> ProjectUpdates
    {
      get { return _projectUpdates; }
      set { _projectUpdates = value; }
    }

    static partial void CustomizeMappingDocument(System.Xml.Linq.XDocument mappingDocument);

    internal static System.Xml.Linq.XDocument MappingXml
    {
      get
      {
        var mappingDocument = System.Xml.Linq.XDocument.Parse(@"<?xml version='1.0' encoding='utf-8' ?>
<hibernate-mapping xmlns='urn:nhibernate-mapping-2.2'
                   assembly='" + typeof(ProjectUpdateType).Assembly.GetName().Name + @"'
                   namespace='ProjectOpen'
                   >
  <class name='ProjectUpdateType'
         table='ProjectUpdateType'
         lazy='false'
         >
    <id name='ProjectUpdateTypeId'
        column='ProjectUpdateType_id'
        >
      <generator class='identity'>
      </generator>
    </id>
    <property name='ProjectUpdateTypeDescription'
              column='ProjectUpdateType_description'
              />
    <bag name='ProjectUpdates'
          inverse='false'
          >
      <key column='ProjectUpdate_updateTypeId' />
      <one-to-many class='ProjectUpdate' />
    </bag>
  </class>
</hibernate-mapping>");
        CustomizeMappingDocument(mappingDocument);
        return mappingDocument;
      }
    }
  }

  [System.CodeDom.Compiler.GeneratedCode("NHibernateModelGenerator", "1.0.0.0")]
  public partial class RequestForWork
  {
    public virtual int RequestForWorkId { get; set; }
    public virtual System.Nullable<int> RequestForWorkRequestorId { get; set; }
    public virtual System.Nullable<System.DateTime> RequestForWorkCreateDate { get; set; }
    public virtual System.Nullable<int> RequestForWorkAuthorisedById { get; set; }
    public virtual System.Nullable<System.DateTime> RequestForWorkAuthorisationDate { get; set; }
    [Length(Max=8)]
    public virtual string RequestForWorkCostCentre { get; set; }
    [Length(Max=1024)]
    public virtual string RequestForWorkDescription { get; set; }
    [Length(Max=1024)]
    public virtual string RequestForWorkReason { get; set; }
    [Length(Max=1024)]
    public virtual string RequestForWorkBusinessBenefits { get; set; }
    [Length(Max=128)]
    public virtual string RequestForWorkCostSavings { get; set; }
    public virtual System.Nullable<short> RequestForWorkDepartmentId { get; set; }
    [Length(Max=64)]
    public virtual string RequestForWorkTitle { get; set; }

    public virtual Grouping RequestForWorkDepartment { get; set; }

    public virtual Staff RequestForWorkAuthorisedBy { get; set; }

    public virtual Staff RequestForWorkRequestor { get; set; }

    static partial void CustomizeMappingDocument(System.Xml.Linq.XDocument mappingDocument);

    internal static System.Xml.Linq.XDocument MappingXml
    {
      get
      {
        var mappingDocument = System.Xml.Linq.XDocument.Parse(@"<?xml version='1.0' encoding='utf-8' ?>
<hibernate-mapping xmlns='urn:nhibernate-mapping-2.2'
                   assembly='" + typeof(RequestForWork).Assembly.GetName().Name + @"'
                   namespace='ProjectOpen'
                   >
  <class name='RequestForWork'
         table='RequestForWork'
         >
    <id name='RequestForWorkId'
        column='RequestForWork_id'
        >
      <generator class='identity'>
      </generator>
    </id>
    <property name='RequestForWorkRequestorId'
              column='RequestForWork_requestorId'
              insert='false'
              update='false'
              />
    <property name='RequestForWorkCreateDate'
              column='RequestForWork_createDate'
              />
    <property name='RequestForWorkAuthorisedById'
              column='RequestForWork_authorisedById'
              insert='false'
              update='false'
              />
    <property name='RequestForWorkAuthorisationDate'
              column='RequestForWork_authorisationDate'
              />
    <property name='RequestForWorkCostCentre'
              column='RequestForWork_costCentre'
              />
    <property name='RequestForWorkDescription'
              column='RequestForWork_description'
              />
    <property name='RequestForWorkReason'
              column='RequestForWork_reason'
              />
    <property name='RequestForWorkBusinessBenefits'
              column='RequestForWork_businessBenefits'
              />
    <property name='RequestForWorkCostSavings'
              column='RequestForWork_costSavings'
              />
    <property name='RequestForWorkDepartmentId'
              column='RequestForWork_department'
              insert='false'
              update='false'
              />
    <property name='RequestForWorkTitle'
              column='RequestForWork_title'
              />
    <many-to-one name='RequestForWorkDepartment' class='Grouping' column='RequestForWork_department' />
    <many-to-one name='RequestForWorkAuthorisedBy' class='Staff' column='RequestForWork_authorisedById' />
    <many-to-one name='RequestForWorkRequestor' class='Staff' column='RequestForWork_requestorId' />
  </class>
</hibernate-mapping>");
        CustomizeMappingDocument(mappingDocument);
        return mappingDocument;
      }
    }
  }

  [System.CodeDom.Compiler.GeneratedCode("NHibernateModelGenerator", "1.0.0.0")]
  public partial class ProjectNote
  {
    public virtual int ProjectNoteId { get; set; }
    [Length(Max=250)]
    public virtual string ProjectNoteDescription { get; set; }
    public virtual System.Nullable<int> ProjectNoteProjectTaskId { get; set; }

    public virtual ProjectTask ProjectNoteProjectTask { get; set; }

    static partial void CustomizeMappingDocument(System.Xml.Linq.XDocument mappingDocument);

    internal static System.Xml.Linq.XDocument MappingXml
    {
      get
      {
        var mappingDocument = System.Xml.Linq.XDocument.Parse(@"<?xml version='1.0' encoding='utf-8' ?>
<hibernate-mapping xmlns='urn:nhibernate-mapping-2.2'
                   assembly='" + typeof(ProjectNote).Assembly.GetName().Name + @"'
                   namespace='ProjectOpen'
                   >
  <class name='ProjectNote'
         table='ProjectNote'
         >
    <id name='ProjectNoteId'
        column='ProjectNote_id'
        >
      <generator class='identity'>
      </generator>
    </id>
    <property name='ProjectNoteDescription'
              column='ProjectNote_description'
              />
    <property name='ProjectNoteProjectTaskId'
              column='ProjectNote_projectTaskId'
              insert='false'
              update='false'
              />
    <many-to-one name='ProjectNoteProjectTask' class='ProjectTask' column='ProjectNote_projectTaskId' />
  </class>
</hibernate-mapping>");
        CustomizeMappingDocument(mappingDocument);
        return mappingDocument;
      }
    }
  }

  [System.CodeDom.Compiler.GeneratedCode("NHibernateModelGenerator", "1.0.0.0")]
  public partial class ProjectIssue
  {
    public virtual int ProjectIssueId { get; set; }
    public virtual System.Nullable<bool> ProjectIssueRiskFlag { get; set; }
    public virtual System.Nullable<bool> ProjectIssueIssueFlag { get; set; }
    [Length(Max=512)]
    public virtual string ProjectIssueDescription { get; set; }
    [Length(Max=32)]
    public virtual string ProjectIssueShortDescription { get; set; }
    public virtual System.Nullable<System.DateTime> ProjectIssueCreateDate { get; set; }
    public virtual System.Nullable<System.DateTime> ProjectIssueResolutionDate { get; set; }
    [Length(Max=512)]
    public virtual string ProjectIssueMitigation { get; set; }
    public virtual System.Nullable<short> ProjectIssueSeverityId { get; set; }
    public virtual System.Nullable<int> ProjectIssueProjectTaskId { get; set; }
    public virtual System.Nullable<int> ProjectIssueProjectId { get; set; }
    public virtual System.Nullable<System.DateTime> ProjectIssueCompletionDate { get; set; }

    public virtual Project ProjectIssueProject { get; set; }

    public virtual ProjectIssueSeverity ProjectIssueSeverity { get; set; }

    public virtual ProjectTask ProjectIssueProjectTask { get; set; }

    static partial void CustomizeMappingDocument(System.Xml.Linq.XDocument mappingDocument);

    internal static System.Xml.Linq.XDocument MappingXml
    {
      get
      {
        var mappingDocument = System.Xml.Linq.XDocument.Parse(@"<?xml version='1.0' encoding='utf-8' ?>
<hibernate-mapping xmlns='urn:nhibernate-mapping-2.2'
                   assembly='" + typeof(ProjectIssue).Assembly.GetName().Name + @"'
                   namespace='ProjectOpen'
                   >
  <class name='ProjectIssue'
         table='ProjectIssue'
         lazy='false'
         >
    <id name='ProjectIssueId'
        column='ProjectIssue_id'
        >
      <generator class='identity'>
      </generator>
    </id>
    <property name='ProjectIssueRiskFlag'
              column='ProjectIssue_riskFlag'
              />
    <property name='ProjectIssueIssueFlag'
              column='ProjectIssue_issueFlag'
              />
    <property name='ProjectIssueDescription'
              column='ProjectIssue_description'
              />
    <property name='ProjectIssueShortDescription'
              column='ProjectIssue_shortDescription'
              />
    <property name='ProjectIssueCreateDate'
              column='ProjectIssue_createDate'
              />
    <property name='ProjectIssueResolutionDate'
              column='ProjectIssue_resolutionDate'
              />
    <property name='ProjectIssueMitigation'
              column='ProjectIssue_mitigation'
              />
    <property name='ProjectIssueSeverityId'
              column='ProjectIssue_severityId'
              insert='false'
              update='false'
              />
    <property name='ProjectIssueProjectTaskId'
              column='ProjectIssue_projectTaskId'
              insert='false'
              update='false'
              />
    <property name='ProjectIssueProjectId'
              column='ProjectIssue_projectId'
              insert='false'
              update='false'
              />
    <property name='ProjectIssueCompletionDate'
              column='ProjectIssue_completionDate'
              />
    <many-to-one name='ProjectIssueProject' class='Project' column='ProjectIssue_projectId' />
    <many-to-one name='ProjectIssueSeverity' class='ProjectIssueSeverity' column='ProjectIssue_severityId' />
    <many-to-one name='ProjectIssueProjectTask' class='ProjectTask' column='ProjectIssue_projectTaskId' />
  </class>
</hibernate-mapping>");
        CustomizeMappingDocument(mappingDocument);
        return mappingDocument;
      }
    }
  }

  [System.CodeDom.Compiler.GeneratedCode("NHibernateModelGenerator", "1.0.0.0")]
  public partial class ProjectDocument
  {
    public virtual int ProjectDocumentId { get; set; }
    [Length(Max=32)]
    public virtual string ProjectDocumentTitle { get; set; }
    public virtual System.Nullable<int> ProjectDocumentTypeId { get; set; }
    public virtual byte[] ProjectDocumentBlob { get; set; }
    [Length(Max=250)]
    public virtual string ProjectDocumentDescription { get; set; }
    public virtual System.Nullable<int> ProjectDocumentProjectId { get; set; }
    public virtual System.Nullable<int> ProjectDocumentProjectTaskId { get; set; }
    public virtual System.Nullable<int> ProjectDocumentUserId { get; set; }
    public virtual System.Nullable<System.DateTime> ProjectDocumentCreateDate { get; set; }

    public virtual Staff ProjectDocumentUser { get; set; }

    public virtual Project ProjectDocumentProject { get; set; }

    public virtual ProjectTask ProjectDocumentProjectTask { get; set; }

    static partial void CustomizeMappingDocument(System.Xml.Linq.XDocument mappingDocument);

    internal static System.Xml.Linq.XDocument MappingXml
    {
      get
      {
        var mappingDocument = System.Xml.Linq.XDocument.Parse(@"<?xml version='1.0' encoding='utf-8' ?>
<hibernate-mapping xmlns='urn:nhibernate-mapping-2.2'
                   assembly='" + typeof(ProjectDocument).Assembly.GetName().Name + @"'
                   namespace='ProjectOpen'
                   >
  <class name='ProjectDocument'
         table='ProjectDocument'
         lazy='false'
         >
    <id name='ProjectDocumentId'
        column='ProjectDocument_id'
        >
      <generator class='identity'>
      </generator>
    </id>
    <property name='ProjectDocumentTitle'
              column='ProjectDocument_title'
              />
    <property name='ProjectDocumentTypeId'
              column='ProjectDocument_typeId'
              />
    <property name='ProjectDocumentBlob'
              column='ProjectDocument_blob'
              />
    <property name='ProjectDocumentDescription'
              column='ProjectDocument_description'
              />
    <property name='ProjectDocumentProjectId'
              column='ProjectDocument_projectId'
              insert='false'
              update='false'
              />
    <property name='ProjectDocumentProjectTaskId'
              column='ProjectDocument_projectTaskId'
              insert='false'
              update='false'
              />
    <property name='ProjectDocumentUserId'
              column='ProjectDocument_userId'
              insert='false'
              update='false'
              />
    <property name='ProjectDocumentCreateDate'
              column='ProjectDocument_createDate'
              />
    <many-to-one name='ProjectDocumentUser' class='Staff' column='ProjectDocument_userId' />
    <many-to-one name='ProjectDocumentProject' class='Project' column='ProjectDocument_projectId' />
    <many-to-one name='ProjectDocumentProjectTask' class='ProjectTask' column='ProjectDocument_projectTaskId' />
  </class>
</hibernate-mapping>");
        CustomizeMappingDocument(mappingDocument);
        return mappingDocument;
      }
    }
  }


  /// <summary>
  /// Provides a NHibernate configuration object containing mappings for this model.
  /// </summary>
  public static class ConfigurationHelper
  {
    /// <summary>
    /// Creates a NHibernate configuration object containing mappings for this model.
    /// </summary>
    /// <returns>A NHibernate configuration object containing mappings for this model.</returns>
    public static Configuration CreateConfiguration()
    {
      var configuration = new Configuration();
      configuration.Configure();
      ApplyConfiguration(configuration);
      return configuration;
    }

    /// <summary>
    /// Adds mappings for this model to a NHibernate configuration object.
    /// </summary>
    /// <param name="configuration">A NHibernate configuration object to which to add mappings for this model.</param>
    public static void ApplyConfiguration(Configuration configuration)
    {
      configuration.AddXml(ModelMappingXml.ToString());
      configuration.AddXml(Grouping.MappingXml.ToString());
      configuration.AddXml(Staff.MappingXml.ToString());
      configuration.AddXml(GroupingType.MappingXml.ToString());
      configuration.AddXml(Project.MappingXml.ToString());
      configuration.AddXml(ProjectIssueSeverity.MappingXml.ToString());
      configuration.AddXml(ProjectNotificationInstance.MappingXml.ToString());
      configuration.AddXml(ProjectTask.MappingXml.ToString());
      configuration.AddXml(ProjectTaskNotification.MappingXml.ToString());
      configuration.AddXml(ProjectTaskType.MappingXml.ToString());
      configuration.AddXml(ProjectType.MappingXml.ToString());
      configuration.AddXml(ProjectUpdate.MappingXml.ToString());
      configuration.AddXml(ProjectUpdateType.MappingXml.ToString());
      configuration.AddXml(RequestForWork.MappingXml.ToString());
      configuration.AddXml(ProjectNote.MappingXml.ToString());
      configuration.AddXml(ProjectIssue.MappingXml.ToString());
      configuration.AddXml(ProjectDocument.MappingXml.ToString());
      configuration.AddAssembly(typeof(ConfigurationHelper).Assembly);
    }

    /// <summary>
    /// Provides global mappings not associated with a specific entity.
    /// </summary>
    public static System.Xml.Linq.XDocument ModelMappingXml
    {
      get
      {
        var mappingDocument = System.Xml.Linq.XDocument.Parse(@"<?xml version='1.0' encoding='utf-8' ?>
<hibernate-mapping xmlns='urn:nhibernate-mapping-2.2'
                   assembly='" + typeof(ConfigurationHelper).Assembly.GetName().Name + @"'
                   namespace='ProjectOpen'
                   >
</hibernate-mapping>");
        return mappingDocument;
      }
    }
  }
}
