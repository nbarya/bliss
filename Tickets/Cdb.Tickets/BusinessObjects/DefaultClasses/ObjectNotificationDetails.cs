using Cdb.Tickets.BusinessObjects.DomainComponent;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdb.Tickets.BusinessObjects.DefaultClasses
{
    public class ObjectNotificationDetails: XPObject, IObjectNotificationDetails
    {
        public ObjectNotificationDetails() : base()
        {
            // This constructor is used when an object is loaded from a persistent storage.
            // Do not place any code here.
        }

        public ObjectNotificationDetails(Session session) : base(session)
        {
            // This constructor is used when an object is loaded from a persistent storage.
            // Do not place any code here.
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place here your initialization code.
            //Set current date
        }

        public int ObjectOid { get; set; }

        [Size(500)]
        public string ObjectType { get; set; }
        [Size(500)]
        public string UsersToSendEmail { get; set; }
        [Size(SizeAttribute.Unlimited)]
        public string TemplateForSave { get; set; }
        [Size(SizeAttribute.Unlimited)]
        public string TemplateForUpdate { get; set; }
        [Size(SizeAttribute.Unlimited)]
        public string TemplateForDelete { get; set; }
    }
}
