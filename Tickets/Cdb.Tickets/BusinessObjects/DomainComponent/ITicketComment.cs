using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Security;
using DevExpress.Persistent.Validation;
using System;

namespace Cdb.Tickets.BusinessObjects.DomainComponent
{
    [DomainComponent]
    public interface ITicketComment
    {
        [RuleRequiredField("RuleRequiredField for TicketComment.Comments", DefaultContexts.Save)]
        string Comments { get; set; }
        ICustomUser CommentedBy { get; set; }
        DateTime CommentedOn { get; set; }
        // one-to-many Ticket-TicketComments relationship
        ITicket Ticket { get; set; }
    }
}
