using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Security;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Base.Security;
using DevExpress.Persistent.BaseImpl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdb.Tickets.BusinessObjects.DomainComponent
{
    [DomainComponent]
    public interface ICustomUser : ISecurityUser, IAuthenticationStandardUser
        ,ISecurityUserWithRoles, IPermissionPolicyUser
    {
        // one-to-many Reporter-Tickets relationship
        IList<ITicket> ReporterTickets { get; }
        // one-to-many Assignee-Tickets relationship
        IList<ITicket> AssigneeTickets { get; }
        // many-to-many Watchers-Tickets relationship
        IList<ITicket> WatcherTickets { get; }
    }
}
