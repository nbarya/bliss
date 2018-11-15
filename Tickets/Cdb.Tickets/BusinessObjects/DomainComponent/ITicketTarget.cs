using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Validation;
using System.Collections.Generic;

namespace Cdb.Tickets.BusinessObjects.DomainComponent
{
    [DomainComponent]
    public interface ITicketTarget
    {
        [RuleRequiredField("RuleRequiredField for TicketTarget.Target", DefaultContexts.Save)]
        string Target { get; set; }
        IList<ITicket> Tickets { get; }
    }
}
