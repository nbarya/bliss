using DevExpress.ExpressApp.DC;

namespace Cdb.Tickets.BusinessObjects.DomainComponent
{
    [DomainComponent]
    public interface ITicketPriority
    {
        string Ticket_Priority { get; set; }
    }
}
