using Cdb.Tickets.BusinessObjects.DomainComponent;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System.ComponentModel;

namespace Cdb.Tickets.BusinessObjects.DefaultClasses
{
    [NavigationItem("Ticket")]
    [DefaultProperty("Ticket_Source")]
    public class TicketSource: XPObject, ITicketSource
    {
        public TicketSource() : base()
        {
            // This constructor is used when an object is loaded from a persistent storage.
            // Do not place any code here.
        }

        public TicketSource(Session session) : base(session)
        {
            // This constructor is used when an object is loaded from a persistent storage.
            // Do not place any code here.
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place here your initialization code.
        }

        [RuleRequiredField("RuleRequiredField for TicketSource.Ticket_Source", DefaultContexts.Save)]
        public string Ticket_Source { get; set; }
    }
}
