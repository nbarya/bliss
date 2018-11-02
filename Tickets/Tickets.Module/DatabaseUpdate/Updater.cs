using System;
using System.Linq;
using DevExpress.ExpressApp;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.Updating;
using DevExpress.Xpo;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Persistent.BaseImpl;
using Cdb.Tickets.BusinessObjects.DefaultClasses;

namespace Tickets.Module.DatabaseUpdate {
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppUpdatingModuleUpdatertopic.aspx
    public class Updater : ModuleUpdater {
        public Updater(IObjectSpace objectSpace, Version currentDBVersion) :
            base(objectSpace, currentDBVersion) {
        }
        public override void UpdateDatabaseAfterUpdateSchema() {
            base.UpdateDatabaseAfterUpdateSchema();

            CustomUserRole adminEmployeeRole = ObjectSpace.FindObject<CustomUserRole>(
               new BinaryOperator("Name", "Admin"));
            if (adminEmployeeRole == null)
            {
                adminEmployeeRole = ObjectSpace.CreateObject<CustomUserRole>();
                adminEmployeeRole.Name = "Admin";
                adminEmployeeRole.IsAdministrative = true;
                adminEmployeeRole.Save();
            }
            CustomUser adminEmployee = ObjectSpace.FindObject<CustomUser>(
                new BinaryOperator("UserName", "Admin"));
            if (adminEmployee == null)
            {
                adminEmployee = ObjectSpace.CreateObject<CustomUser>();
                adminEmployee.UserName = "Admin";
                adminEmployee.SetPassword("");
                adminEmployee.Roles.Add(adminEmployeeRole);
            }

            ObjectSpace.CommitChanges(); //Uncomment this line to persist created object(s).
        }
        public override void UpdateDatabaseBeforeUpdateSchema() {
            base.UpdateDatabaseBeforeUpdateSchema();
            //if(CurrentDBVersion < new Version("1.1.0.0") && CurrentDBVersion > new Version("0.0.0.0")) {
            //    RenameColumn("DomainObject1Table", "OldColumnName", "NewColumnName");
            //}
        }
    }
}
