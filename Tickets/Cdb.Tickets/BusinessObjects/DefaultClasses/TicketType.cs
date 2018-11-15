using Cdb.Tickets.BusinessObjects.DomainComponent;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System.ComponentModel;

namespace Cdb.Tickets.BusinessObjects.DefaultClasses
{
    [NavigationItem("Ticket")]
    [DefaultProperty("Ticket_Type")]
    public class TicketType: XPObject, ITicketType
    {
        public TicketType() : base()
        {
            // This constructor is used when an object is loaded from a persistent storage.
            // Do not place any code here.
        }

        public TicketType(Session session) : base(session)
        {
            // This constructor is used when an object is loaded from a persistent storage.
            // Do not place any code here.
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place here your initialization code.
        }

        
        public string Ticket_Type { get; set; }
    }
}
