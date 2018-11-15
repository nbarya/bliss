using Cdb.Tickets.BusinessObjects.DomainComponent;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Security;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.ComponentModel;
using DevExpress.ExpressApp;
using DevExpress.Persistent.BaseImpl.PermissionPolicy;

namespace Cdb.Tickets.BusinessObjects.DefaultClasses
{    
    [DefaultProperty("Comments")]
    public class TicketComment: XPObject, ITicketComment
    {
        public TicketComment() : base()
        {
            // This constructor is used when an object is loaded from a persistent storage.
            // Do not place any code here.
        }

        public TicketComment(Session session) : base(session)
        {
            // This constructor is used when an object is loaded from a persistent storage.
            // Do not place any code here.
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place here your initialization code.
            //Set current date
            CommentedOn = DateTime.Now;
            if (SecuritySystem.CurrentUser != null)
            {
                CustomUser user = Session.GetObjectByKey<CustomUser>(SecuritySystem.CurrentUserId);
                //set current user // CommentedBy = 
                CommentedBy = user;
            }
        }
                
        [Size(SizeAttribute.Unlimited)]
        public string Comments { get; set; }

        [ModelDefault("AllowEdit", "False")]
        public CustomUser CommentedBy { get; set; }
        ICustomUser ITicketComment.CommentedBy
        {
            get { return CommentedBy; }
            set { CommentedBy = (CustomUser)value; }
        }

        [ModelDefault("AllowEdit", "False")]
        public DateTime CommentedOn { get; set; }
        
        // one-to-many Ticket-TicketComments relationship
        [Association("Ticket-TicketComments")]
        public Ticket Ticket { get; set; }
        ITicket ITicketComment.Ticket
        {
            get { return Ticket; }
            set
            {
                Ticket = (Ticket)value;
            }
        }

    }
}
