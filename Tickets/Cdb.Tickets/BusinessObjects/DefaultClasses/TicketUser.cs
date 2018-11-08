using Cdb.Tickets.BusinessObjects.DomainComponent;
using DevExpress.ExpressApp.Security;
using DevExpress.ExpressApp.Security.Strategy;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdb.Tickets.BusinessObjects.DefaultClasses
{
    [NavigationItem("TestUser")]
    [DefaultProperty("TestUser.UserName")]
    public class TicketUser : XPObject, ITicketUser
    {
        public TicketUser() : base()
        {
            // This constructor is used when an object is loaded from a persistent storage.
            // Do not place any code here.
        }

        public TicketUser(Session session) : base(session)
        {
            // This constructor is used when an object is loaded from a persistent storage.
            // Do not place any code here.
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place here your initialization code.
        }

        public SecuritySystemUser TestUser { get; set; }
        ISecurityUser ITicketUser.TestUser { get { return TestUser; } set { TestUser = (SecuritySystemUser)value; } }
    }
}
