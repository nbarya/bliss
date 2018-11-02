using Cdb.Tickets.BusinessObjects.DomainComponent;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Security;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.BaseImpl.PermissionPolicy;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdb.Tickets.BusinessObjects.DefaultClasses
{
    [NavigationItem("Ticket")]
    [DefaultProperty("TicketDate")]
    public class Ticket : XPObject, ITicket
    {
        public Ticket() : base()
        {
            // This constructor is used when an object is loaded from a persistent storage.
            // Do not place any code here.
        }

        public Ticket(Session session) : base(session)
        {
            // This constructor is used when an object is loaded from a persistent storage.
            // Do not place any code here.
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place here your initialization code.

            //Set current date
            TicketDate = DateTime.Now;
            ErrorDate = DateTime.Now;
            ReportDate = DateTime.Now;
            SourceDate = DateTime.Now;

        }

        [RuleRequiredField("RuleRequiredField for Ticket.Reporter", DefaultContexts.Save)]
        [Association("Reporter-Tickets")]
        [BackReferenceProperty("ReporterTickets")]
        public CustomUser Reporter { get; set; }
        ICustomUser ITicket.Reporter { get { return Reporter; } set { Reporter = (CustomUser)value; } }

        public TicketType Type { get; set; }
        ITicketType ITicket.Type { get { return Type; } set { Type = (TicketType)value; } }

        public TicketState State { get; set; }
        ITicketState ITicket.State { get { return State; } set { State = (TicketState)value; } }

        public DateTime TicketDate { get; set; }
        public DateTime ErrorDate { get; set; }

        public TicketSource Source { get; set; }
        ITicketSource ITicket.Source { get { return Source; } set { Source = (TicketSource)value; } }

        public TicketClient Client { get; set; }
        ITicketClient ITicket.Client { get { return Client; } set { Client = (TicketClient)value; } }

        public TicketPriority Priority { get; set; }
        ITicketPriority ITicket.Priority { get { return Priority; } set { Priority = (TicketPriority)value; } }

        [ModelDefault("AllowEdit", "False")]
        public DateTime ReportDate { get; set; }
        public DateTime SourceDate { get; set; }

        [RuleRequiredField("RuleRequiredField for Ticket.Assignee", DefaultContexts.Save)]
        [Association("Assignee-Tickets")]
        [BackReferenceProperty("AssigneeTickets")]
        public CustomUser Assignee { get; set; }
        ICustomUser ITicket.Assignee { get { return Assignee; } set { Assignee = (CustomUser)value; } }

        // many-to-many Watchers-Tickets relationship
        [Association("Watchers-Tickets")]
        [BackReferenceProperty("WatcherTickets")]
        public XPCollection<CustomUser> Watchers
        {
            get { return GetCollection<CustomUser>(nameof(Watchers)); }
        }
        private GenericCollection<CustomUser, ICustomUser> watchers;
        IList<ICustomUser> ITicket.Watchers
        {
            get
            {
                if (watchers == null)
                    watchers = new GenericCollection<CustomUser, ICustomUser>(Watchers);
                return watchers;
            }
        }
        //

        // one-to-many Ticket-TicketComments relationship
        [Association("Ticket-TicketComments"), DevExpress.Xpo.Aggregated]
        public XPCollection<TicketComment> Comments
        {
            get { return GetCollection<TicketComment>(nameof(Comments)); }
        }
        private GenericCollection<TicketComment, ITicketComment> comments;
        IList<ITicketComment> ITicket.Comments
        {
            get
            {
                if (comments == null)
                    comments = new GenericCollection<TicketComment, ITicketComment>(Comments);
                return comments;
            }
        }
        //
    }
}
