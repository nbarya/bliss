using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Cdb.Notifications.BusinessObjects.Classes.Notification;

namespace Cdb.Notifications.BusinessObjects.Interfaces
{
    public interface INotification
    {
        string Email { get; set; }
        NotificationTypeEnum NotificationType { get; set; }
        DateTime EmailDate { get; set; }
        string Message { get; set; }
        EmailNotificationStatusEnum Status { get; set; }
                
    }
}
