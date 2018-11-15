using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Validation;

namespace Cdb.Tickets.BusinessObjects.DomainComponent
{
    [DomainComponent]
    public interface ITicketType
    {
        [RuleRequiredField("RuleRequiredField for TicketType.Ticket_Type", DefaultContexts.Save)]
        string Ticket_Type { get; set; }
    }
}
