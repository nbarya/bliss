using DevExpress.ExpressApp.DC;
using System.Collections.Generic;

namespace Cdb.Tickets.BusinessObjects.DomainComponent
{
    [DomainComponent]
    public interface ITicketTarget
    {
        IList<ITicket> Tickets { get; }
    }
}
