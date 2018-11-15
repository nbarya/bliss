using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Validation;

namespace Cdb.Tickets.BusinessObjects.DomainComponent
{
    [DomainComponent]
    public interface ITicketPriority
    {
        [RuleRequiredField("RuleRequiredField for TicketPriority.Ticket_Priority", DefaultContexts.Save)]
        string Ticket_Priority { get; set; }
    }
}
