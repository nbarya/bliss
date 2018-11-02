using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Security;
using System;

namespace Cdb.Tickets.BusinessObjects.DomainComponent
{
    [DomainComponent]
    public interface ITicketComment
    {        
        string Comments { get; set; }
        ICustomUser CommentedBy { get; set; }
        DateTime CommentedOn { get; set; }
        // one-to-many Ticket-TicketComments relationship
        ITicket Ticket { get; set; }
    }
}
