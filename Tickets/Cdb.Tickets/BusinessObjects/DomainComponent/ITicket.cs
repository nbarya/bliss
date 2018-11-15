using Cdb.Tickets.BusinessObjects.DefaultClasses;
using Cdb.Tickets.BusinessObjects.DomainComponent;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Security;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Cdb.Tickets.BusinessObjects.DomainComponent
{    
    [DomainComponent]    
    public interface ITicket
    {
        [RuleRequiredField("RuleRequiredField for Ticket.Reporter", DefaultContexts.Save)]
        [BackReferenceProperty("ReporterTickets")]
        ICustomUser Reporter { get; set; }
        ITicketType Type { get; set; }
        ITicketState State { get; set; }
        DateTime TicketDate { get; set; }
        DateTime ErrorDate { get; set; }
        ITicketSource Source { get; set; }
        ITicketTarget Target { get; set; }
        ITicketPriority Priority { get; set; }
        DateTime ReportDate { get; set; }
        DateTime SourceDate { get; set; }
        [RuleRequiredField("RuleRequiredField for Ticket.Assignee", DefaultContexts.Save)]
        [BackReferenceProperty("AssigneeTickets")]
        ICustomUser Assignee { get; set; }

        // many-to-many Tickets-Users relationship   
        [BackReferenceProperty("WatcherTickets")]
        IList<ICustomUser> Watchers { get;  }

        // one-to-many Ticket-TicketComments relationship       
        IList<ITicketComment> Comments { get; }
    }

    [DomainLogic(typeof(ITicket))]
    public class AdditionalTicketLogic
    {
        public static void AfterConstruction(ITicket instance, IObjectSpace objectSpace)
        {
            //Set current date
            instance.TicketDate = DateTime.Now;
            instance.ErrorDate = DateTime.Now;
            instance.ReportDate = DateTime.Now;
            instance.SourceDate = DateTime.Now;

            if (SecuritySystem.CurrentUser != null)
            {
                //////////
                //initialize with the current user
                CustomUser user = objectSpace.GetObjectByKey<CustomUser>(SecuritySystem.CurrentUserId);
                instance.Reporter = user;
                //////////
                //initialize with the first priority
                Type typeofPriority = TicketsModule.FindDefaultTicketPriorityDataType();
                instance.Priority =
                   objectSpace.FindObject(typeofPriority, CriteriaOperator.Parse("Ticket_Priority = 'High'")) as ITicketPriority;
            }

            //// TODO: initialize new instnace of ticket
            //instance.TicketDate = DateTime.Now;
            //// how to initialize with the current user???
            //instance.Reporter = null;
            //// initialize with the first priority found in database
            //instance.Priority = null;
        }
    }
}
