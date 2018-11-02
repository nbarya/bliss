using DevExpress.ExpressApp.DC;

namespace Cdb.Tickets.BusinessObjects.DomainComponent
{
    [DomainComponent]
    public interface ITicketClient: ITicketTarget
    {
        string ClientName { get; set; }
    }
}
