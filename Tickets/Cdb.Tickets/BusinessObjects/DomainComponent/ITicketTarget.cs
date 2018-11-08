using DevExpress.ExpressApp.DC;
using System.Collections.Generic;

namespace Cdb.Tickets.BusinessObjects.DomainComponent
{
    [DomainComponent]
    public interface ITicketTarget
    {
        string Target { get; set; }
        IList<ITicket> Tickets { get; }
    }
}
