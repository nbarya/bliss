using System;
using System.Text;
using System.Linq;
using DevExpress.ExpressApp;
using System.ComponentModel;
using DevExpress.ExpressApp.DC;
using System.Collections.Generic;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Updating;
using DevExpress.ExpressApp.Model.Core;
using DevExpress.ExpressApp.Model.DomainLogics;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.Xpo;
using Cdb.Notifications.BusinessObjects.Classes;
using Cdb.Tickets.BusinessObjects.DefaultClasses;

namespace Tickets.Module {
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppModuleBasetopic.aspx.
    public sealed partial class TicketsModule : ModuleBase {
        public TicketsModule() {
            InitializeComponent();
			BaseObject.OidInitializationMode = OidInitializationMode.AfterConstruction;
            //Add Tickets Module//
            RequiredModuleTypes.Add(typeof(Cdb.Tickets.TicketsModule));
            //Add Notifications Module//
            RequiredModuleTypes.Add(typeof(Cdb.Notifications.NotificationsModule));
        }
        public override IEnumerable<ModuleUpdater> GetModuleUpdaters(IObjectSpace objectSpace, Version versionFromDB) {
            ModuleUpdater updater = new DatabaseUpdate.Updater(objectSpace, versionFromDB);
            return new ModuleUpdater[] { updater };
        }
        public override void Setup(XafApplication application) {
            base.Setup(application);
            // Manage various aspects of the application UI and behavior at the module level.
            application.LoggedOn += new EventHandler<LogonEventArgs>(application_LoggedOn);
        }
        //
        void application_LoggedOn(object sender, LogonEventArgs e)
        {
            Cdb.Notifications.NotificationsModule notifications = Application.Modules.FindModule<Cdb.Notifications.NotificationsModule>();
            if (notifications != null)
            {
                notifications.NotificationObjects = new List<NotificationObjects>();

                NotificationObjects objNotifObject = new NotificationObjects();
                //Ticket
                objNotifObject.ObjectType = typeof(Ticket);
                objNotifObject.ObjectCriteria = "Type.Ticket_Type = 'Error'";
                objNotifObject.IsNotificationForCreation = true;
                objNotifObject.IsNotificationForUpdation = true;

                notifications.NotificationObjects.Add(objNotifObject);

                //Comment
                objNotifObject = new NotificationObjects();
                objNotifObject.ObjectType = typeof(TicketComment);
                objNotifObject.ObjectCriteria = "";
                objNotifObject.IsNotificationForCreation = true;
                objNotifObject.IsNotificationForDeletion = true;
                notifications.NotificationObjects.Add(objNotifObject);
            }
        }
        //
        public override void CustomizeTypesInfo(ITypesInfo typesInfo) {
            base.CustomizeTypesInfo(typesInfo);
            CalculatedPersistentAliasHelper.CustomizeTypesInfo(typesInfo);
        }
    }
}
