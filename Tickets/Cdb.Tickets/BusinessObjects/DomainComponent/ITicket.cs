using Cdb.Tickets.BusinessObjects.DomainComponent;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Security;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Cdb.Tickets.BusinessObjects.DomainComponent
{    
    [DomainComponent]    
    public interface ITicket
    {
        [BackReferenceProperty("ReporterTickets")]
        ICustomUser Reporter { get; set; }
        ITicketType Type { get; set; }
        ITicketState State { get; set; }
        DateTime TicketDate { get; set; }
        DateTime ErrorDate { get; set; }
        ITicketSource Source { get; set; }
        ITicketClient Client { get; set; }
        ITicketPriority Priority { get; set; }
        DateTime ReportDate { get; set; }
        DateTime SourceDate { get; set; }
        [BackReferenceProperty("AssigneeTickets")]
        ICustomUser Assignee { get; set; }

        // many-to-many Tickets-Users relationship   
        [BackReferenceProperty("WatcherTickets")]
        IList<ICustomUser> Watchers { get;  }

        // one-to-many Ticket-TicketComments relationship       
        IList<ITicketComment> Comments { get; }
    }
}
