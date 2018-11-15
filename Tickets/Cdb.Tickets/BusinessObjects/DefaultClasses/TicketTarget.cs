using Cdb.Tickets.BusinessObjects.DomainComponent;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System.Collections.Generic;
using System.ComponentModel;

namespace Cdb.Tickets.BusinessObjects.DefaultClasses
{
    [NavigationItem("Ticket")]
    [DefaultProperty("TicketTarget")]
    public class TicketTarget: XPObject, ITicketTarget
    {
        public TicketTarget() : base()
        {
            // This constructor is used when an object is loaded from a persistent storage.
            // Do not place any code here.
        }

        public TicketTarget(Session session) : base(session)
        {
            // This constructor is used when an object is loaded from a persistent storage.
            // Do not place any code here.
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place here your initialization code.
        }
                
        public string Target { get; set; }

        public IList<ITicket> Tickets { get; }
    }
}
