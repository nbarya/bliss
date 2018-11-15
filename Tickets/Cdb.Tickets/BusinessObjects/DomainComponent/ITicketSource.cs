using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Validation;

namespace Cdb.Tickets.BusinessObjects.DomainComponent
{
    [DomainComponent]
    public interface ITicketSource
    {
        [RuleRequiredField("RuleRequiredField for TicketSource.Ticket_Source", DefaultContexts.Save)]
        string Ticket_Source { get; set; }
    }
}
