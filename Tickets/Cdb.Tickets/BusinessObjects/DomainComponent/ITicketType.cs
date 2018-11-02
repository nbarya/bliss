using DevExpress.ExpressApp.DC;

namespace Cdb.Tickets.BusinessObjects.DomainComponent
{
    [DomainComponent]
    public interface ITicketType
    {
        string Ticket_Type { get; set; }
    }
}
