using DevExpress.ExpressApp.DC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdb.Tickets.BusinessObjects.DomainComponent
{
    [DomainComponent]
    public interface IObjectNotificationDetails
    {
        int ObjectOid { get; set; }
        string ObjectType { get; set; }
        string UsersToSendEmail { get; set; }
        string TemplateForSave { get; set; }
        string TemplateForUpdate { get; set; }
        string TemplateForDelete { get; set; }
    }
}
