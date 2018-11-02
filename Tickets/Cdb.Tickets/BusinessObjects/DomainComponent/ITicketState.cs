using DevExpress.ExpressApp.DC;

namespace Cdb.Tickets.BusinessObjects.DomainComponent
{
    [DomainComponent]
    public interface ITicketState
    {
        string Ticket_State { get; set; }
    }
}
