using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdb.Notifications.BusinessObjects.Interfaces
{
    [DomainComponent]
    public interface INotificationUser
    {
        ISecurityUser SecurityUser { get; set; }
        string Email { get; set; }
    }
}
