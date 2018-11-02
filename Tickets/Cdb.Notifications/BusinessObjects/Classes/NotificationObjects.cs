using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdb.Notifications.BusinessObjects.Classes
{
    public class NotificationObjects
    {
        public Type ObjectType { get; set; }
        public string ObjectCriteria { get; set; }
        public bool IsNotificationForCreation { get; set; }
        public bool IsNotificationForUpdation { get; set; }
        public bool IsNotificationForDeletion { get; set; }
    }
}
