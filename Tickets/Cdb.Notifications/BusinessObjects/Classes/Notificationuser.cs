using Cdb.Notifications.BusinessObjects.Interfaces;
using DevExpress.ExpressApp.Security;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.PermissionPolicy;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdb.Notifications.BusinessObjects.Classes
{
    [NavigationItem("Notification")]
    [DefaultProperty("User.UserName")]
    public class NotificationUser: XPObject, INotificationUser
    {
        public const string EmailRegularExpression = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
        
        public NotificationUser() : base()
        {
            // This constructor is used when an object is loaded from a persistent storage.
            // Do not place any code here.
        }

        public NotificationUser(Session session) : base(session)
        {
            // This constructor is used when an object is loaded from a persistent storage.
            // Do not place any code here.
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place here your initialization code.
        }

        public Tickets.BusinessObjects.DefaultClasses.CustomUser SecurityUser { get; set; }
        ISecurityUser INotificationUser.SecurityUser
        {
            get
            {
                return SecurityUser;
            }
            set { SecurityUser = (Tickets.BusinessObjects.DefaultClasses.CustomUser)value; }
        }

        [RuleRegularExpression(DefaultContexts.Save, EmailRegularExpression, CustomMessageTemplate = "Invalid email format!")]
        public string Email { get; set; }

    }
}
