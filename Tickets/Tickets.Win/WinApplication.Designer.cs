namespace Tickets.Win {
    partial class TicketsWindowsFormsApplication {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.module1 = new DevExpress.ExpressApp.SystemModule.SystemModule();
            this.module2 = new DevExpress.ExpressApp.Win.SystemModule.SystemWindowsFormsModule();
            this.module3 = new Tickets.Module.TicketsModule();
            this.module4 = new Tickets.Module.Win.TicketsWindowsFormsModule();
            this.ticketsModule2 = new Cdb.Tickets.TicketsModule();
            this.notificationsModule2 = new Cdb.Notifications.NotificationsModule();
            this.securityModule1 = new DevExpress.ExpressApp.Security.SecurityModule();
            this.validationModule1 = new DevExpress.ExpressApp.Validation.ValidationModule();
            this.ticketsModule1 = new Cdb.Tickets.TicketsModule();
            this.notificationsModule1 = new Cdb.Notifications.NotificationsModule();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // ticketsModule2
            // 
            this.ticketsModule2.TicketCommentDataType = typeof(Cdb.Tickets.BusinessObjects.DefaultClasses.TicketComment);
            this.ticketsModule2.TicketDataType = typeof(Cdb.Tickets.BusinessObjects.DefaultClasses.Ticket);
            this.ticketsModule2.TicketPriorityDataType = typeof(Cdb.Tickets.BusinessObjects.DefaultClasses.TicketPriority);
            this.ticketsModule2.TicketSourceDataType = typeof(Cdb.Tickets.BusinessObjects.DefaultClasses.TicketSource);
            this.ticketsModule2.TicketStateDataType = typeof(Cdb.Tickets.BusinessObjects.DefaultClasses.TicketState);
            this.ticketsModule2.TicketTargetDataType = typeof(Cdb.Tickets.BusinessObjects.DefaultClasses.TicketTarget);
            this.ticketsModule2.TicketTypeDataType = typeof(Cdb.Tickets.BusinessObjects.DefaultClasses.TicketType);
            // 
            // notificationsModule2
            // 
            this.notificationsModule2.NotificationObjects = null;
            // 
            // validationModule1
            // 
            this.validationModule1.AllowValidationDetailsAccess = true;
            this.validationModule1.IgnoreWarningAndInformationRules = false;
            // 
            // ticketsModule1
            // 
            this.ticketsModule1.TicketCommentDataType = typeof(Cdb.Tickets.BusinessObjects.DefaultClasses.TicketComment);
            this.ticketsModule1.TicketDataType = typeof(Cdb.Tickets.BusinessObjects.DefaultClasses.Ticket);
            this.ticketsModule1.TicketPriorityDataType = typeof(Cdb.Tickets.BusinessObjects.DefaultClasses.TicketPriority);
            this.ticketsModule1.TicketSourceDataType = typeof(Cdb.Tickets.BusinessObjects.DefaultClasses.TicketSource);
            this.ticketsModule1.TicketStateDataType = typeof(Cdb.Tickets.BusinessObjects.DefaultClasses.TicketState);
            this.ticketsModule1.TicketTargetDataType = typeof(Cdb.Tickets.BusinessObjects.DefaultClasses.TicketTarget);
            this.ticketsModule1.TicketTypeDataType = typeof(Cdb.Tickets.BusinessObjects.DefaultClasses.TicketType);
            // 
            // notificationsModule1
            // 
            this.notificationsModule1.NotificationObjects = null;
            // 
            // TicketsWindowsFormsApplication
            // 
            this.ApplicationName = "Tickets";
            this.CheckCompatibilityType = DevExpress.ExpressApp.CheckCompatibilityType.DatabaseSchema;
            this.Modules.Add(this.module1);
            this.Modules.Add(this.module2);
            this.Modules.Add(this.module3);
            this.Modules.Add(this.validationModule1);
            this.Modules.Add(this.module4);
            this.Modules.Add(this.securityModule1);
            this.Modules.Add(this.ticketsModule1);
            this.Modules.Add(this.notificationsModule1);
            this.UseOldTemplates = false;
            this.DatabaseVersionMismatch += new System.EventHandler<DevExpress.ExpressApp.DatabaseVersionMismatchEventArgs>(this.TicketsWindowsFormsApplication_DatabaseVersionMismatch);
            this.CustomizeLanguagesList += new System.EventHandler<DevExpress.ExpressApp.CustomizeLanguagesListEventArgs>(this.TicketsWindowsFormsApplication_CustomizeLanguagesList);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.ExpressApp.SystemModule.SystemModule module1;
        private DevExpress.ExpressApp.Win.SystemModule.SystemWindowsFormsModule module2;
        private Tickets.Module.TicketsModule module3;
        private Tickets.Module.Win.TicketsWindowsFormsModule module4;
        private Cdb.Tickets.TicketsModule ticketsModule2;
        private Cdb.Notifications.NotificationsModule notificationsModule2;
        private DevExpress.ExpressApp.Security.SecurityModule securityModule1;
        private DevExpress.ExpressApp.Validation.ValidationModule validationModule1;
        private Cdb.Tickets.TicketsModule ticketsModule1;
        private Cdb.Notifications.NotificationsModule notificationsModule1;
    }
}
