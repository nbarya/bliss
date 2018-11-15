using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Validation;

namespace Cdb.Tickets.BusinessObjects.DomainComponent
{
    [DomainComponent]
    public interface ITicketState
    {
        [RuleRequiredField("RuleRequiredField for TicketState.Ticket_State", DefaultContexts.Save)]
        string Ticket_State { get; set; }
    }
}
