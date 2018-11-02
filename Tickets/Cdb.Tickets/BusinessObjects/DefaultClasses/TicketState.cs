using Cdb.Tickets.BusinessObjects.DomainComponent;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System.ComponentModel;

namespace Cdb.Tickets.BusinessObjects.DefaultClasses
{
    [NavigationItem("Ticket")]
    [DefaultProperty("Ticket_State")]
    public class TicketState: XPObject, ITicketState
    {
        public TicketState() : base()
        {
            // This constructor is used when an object is loaded from a persistent storage.
            // Do not place any code here.
        }

        public TicketState(Session session) : base(session)
        {
            // This constructor is used when an object is loaded from a persistent storage.
            // Do not place any code here.
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place here your initialization code.
        }

        [RuleRequiredField("RuleRequiredField for TicketState.Ticket_State", DefaultContexts.Save)]
        public string Ticket_State { get; set; }
    }
}
