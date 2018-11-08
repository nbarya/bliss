using Cdb.Tickets.BusinessObjects.DomainComponent;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Security;
using DevExpress.ExpressApp.Security.Strategy;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdb.Tickets.BusinessObjects.DefaultClasses
{
    [NavigationItem("User")]
    [DefaultProperty("UserName")]
    public class CustomUser : XPObject, ICustomUser
    {
        public CustomUser() : base()
        {
            // This constructor is used when an object is loaded from a persistent storage.
            // Do not place any code here.
        }

        public CustomUser(Session session) : base(session)
        {
            // This constructor is used when an object is loaded from a persistent storage.
            // Do not place any code here.
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place here your initialization code.
        }
                
        #region ISecurityUser Members
        private bool isActive = true;
        public bool IsActive
        {
            get { return isActive; }
            set { SetPropertyValue("IsActive", ref isActive, value); }
        }
        private string userName = String.Empty;
        [RuleRequiredField("UserNameRequired", DefaultContexts.Save)]
        [RuleUniqueValue("UserNameIsUnique", DefaultContexts.Save,
            "The login with the entered user name was already registered within the system.")]
        public string UserName
        {
            get { return userName; }
            set { SetPropertyValue("UserName", ref userName, value); }
        }
        #endregion
       
        #region IAuthenticationStandardUser Members
        private bool changePasswordOnFirstLogon;
        public bool ChangePasswordOnFirstLogon
        {
            get { return changePasswordOnFirstLogon; }
            set
            {
                SetPropertyValue("ChangePasswordOnFirstLogon", ref changePasswordOnFirstLogon, value);
            }
        }
        private string storedPassword;
        [Browsable(false), Size(SizeAttribute.Unlimited), Persistent, SecurityBrowsable]
        protected string StoredPassword
        {
            get { return storedPassword; }
            set { storedPassword = value; }
        }
        public bool ComparePassword(string password)
        {
            return PasswordCryptographer.VerifyHashedPasswordDelegate(this.storedPassword, password);
        }
        public void SetPassword(string password)
        {
            this.storedPassword = PasswordCryptographer.HashPasswordDelegate(password);
            OnChanged("StoredPassword");
        }
        #endregion
        
       #region ISecurityUserWithRoles Members
       IList<ISecurityRole> ISecurityUserWithRoles.Roles
       {
           get
           {
               IList<ISecurityRole> result = new List<ISecurityRole>();
               foreach (CustomUserRole role in Roles)
               {
                   result.Add(role);
               }
               return result;
           }
       }

       [Association("CustomUsers-CustomRoles")]
       [RuleRequiredField("RoleIsRequired", DefaultContexts.Save,
       TargetCriteria = "IsActive",
       CustomMessageTemplate = "An active user must have at least one role assigned")]
       public XPCollection<CustomUserRole> Roles
       {
           get
           {
               return GetCollection<CustomUserRole>("Roles");
           }
       }

        #endregion

        #region IPermissionPolicyUser Members
        IEnumerable<IPermissionPolicyRole> IPermissionPolicyUser.Roles
        {
            get { return Roles.OfType<IPermissionPolicyRole>(); }
        }
        #endregion

        // one-to-many Reporter-Tickets relationship
        [ModelDefault("AllowEdit", "False")]
        [Association("Reporter-Tickets")]
        public XPCollection<Ticket> ReporterTickets { get { return GetCollection<Ticket>(nameof(ReporterTickets)); } }
        private GenericCollection<Ticket, ITicket> reportertickets;
        IList<ITicket> ICustomUser.ReporterTickets
        {
            get
            {
                if (reportertickets == null)
                    reportertickets = new GenericCollection<Ticket, ITicket>(ReporterTickets);
                return reportertickets;
            }
        }
        //
        // one-to-many Assignee-Tickets relationship
        [ModelDefault("AllowEdit", "False")]
        [Association("Assignee-Tickets")]
        public XPCollection<Ticket> AssigneeTickets { get { return GetCollection<Ticket>(nameof(AssigneeTickets)); } }
        private GenericCollection<Ticket, ITicket> assigneetickets;
        IList<ITicket> ICustomUser.AssigneeTickets
        {
            get
            {
                if (assigneetickets == null)
                    assigneetickets = new GenericCollection<Ticket, ITicket>(AssigneeTickets);
                return assigneetickets;
            }
        }
        //
        // many-to-many Watchers-Tickets relationship
        [ModelDefault("AllowEdit", "False")]
        [Association("Watchers-Tickets")]
        public XPCollection<Ticket> WatcherTickets { get { return GetCollection<Ticket>(nameof(WatcherTickets)); } }
        private GenericCollection<Ticket, ITicket> watchertickets;
        IList<ITicket> ICustomUser.WatcherTickets
        {
            get
            {
                if (watchertickets == null)
                    watchertickets = new GenericCollection<Ticket, ITicket>(WatcherTickets);
                return watchertickets;
            }
        }
        //                  
    }
}
