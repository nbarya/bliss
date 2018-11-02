using DevExpress.ExpressApp.DC;

namespace Cdb.Tickets.BusinessObjects.DomainComponent
{
    [DomainComponent]
    public interface ITicketSource
    {
        string Ticket_Source { get; set; }
    }
}
