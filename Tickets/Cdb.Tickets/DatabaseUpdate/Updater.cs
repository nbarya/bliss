using System;
using System.Linq;
using DevExpress.ExpressApp;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.Updating;
using DevExpress.Xpo;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Persistent.BaseImpl;
using Cdb.Tickets.BusinessObjects.DomainComponent;

namespace Cdb.Tickets.DatabaseUpdate {
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppUpdatingModuleUpdatertopic.aspx
    public class Updater : ModuleUpdater {

        TicketsModule module;

        public Updater(IObjectSpace objectSpace, Version currentDBVersion, TicketsModule module) :
            base(objectSpace, currentDBVersion) {
            this.module = module;
        }
        public override void UpdateDatabaseAfterUpdateSchema() {
            base.UpdateDatabaseAfterUpdateSchema();

            // Ticket Type//
            Type dataType = module.TicketTypeDataType;

            foreach (string name in new[] { "Task", "Idea", "Error" })
            {
                ITicketType type = null;
                type = ObjectSpace.FindObject(dataType, new BinaryOperator(nameof(type.Ticket_Type), name)) as ITicketType;
                if (type == null)
                {
                    type = ObjectSpace.CreateObject(dataType) as ITicketType;
                    type.Ticket_Type = name;
                }
            }

            ObjectSpace.CommitChanges();

            //Ticket Priority//
            Type dtTypeTicketPriority = module.TicketPriorityDataType;

            foreach (string name in new[] { "High", "Medium", "Low" })
            {
                ITicketPriority typePriority = null;
                typePriority = 
                    ObjectSpace.FindObject(dtTypeTicketPriority, new BinaryOperator(nameof(typePriority.Ticket_Priority), name)) as ITicketPriority;
                if (typePriority == null)
                {
                    typePriority = ObjectSpace.CreateObject(dtTypeTicketPriority) as ITicketPriority;
                    typePriority.Ticket_Priority = name;
                }
            }

            ObjectSpace.CommitChanges();

            //string name = "MyName";
            //DomainObject1 theObject = ObjectSpace.FindObject<DomainObject1>(CriteriaOperator.Parse("Name=?", name));
            //if(theObject == null) {
            //    theObject = ObjectSpace.CreateObject<DomainObject1>();
            //    theObject.Name = name;
            //}

            //ObjectSpace.CommitChanges(); //Uncomment this line to persist created object(s).
        }
        public override void UpdateDatabaseBeforeUpdateSchema() {
            base.UpdateDatabaseBeforeUpdateSchema();
            //if(CurrentDBVersion < new Version("1.1.0.0") && CurrentDBVersion > new Version("0.0.0.0")) {
            //    RenameColumn("DomainObject1Table", "OldColumnName", "NewColumnName");
            //}
        }
    }
}
