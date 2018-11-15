namespace Cdb.Tickets.Controllers
{
    partial class TicketController
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.popupShowTicketComment = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            // 
            // popupShowTicketComment
            // 
            this.popupShowTicketComment.AcceptButtonCaption = null;
            this.popupShowTicketComment.CancelButtonCaption = null;
            this.popupShowTicketComment.Caption = "Ticket Comment";
            this.popupShowTicketComment.ConfirmationMessage = null;
            this.popupShowTicketComment.Id = "e1c95adf-2016-4601-89cf-00f7c6c694f4";
            this.popupShowTicketComment.TargetObjectType = typeof(Cdb.Tickets.BusinessObjects.DefaultClasses.Ticket);
            this.popupShowTicketComment.TargetViewType = DevExpress.ExpressApp.ViewType.DetailView;
            this.popupShowTicketComment.ToolTip = "Ticket Comment";
            this.popupShowTicketComment.TypeOfView = typeof(DevExpress.ExpressApp.DetailView);
            this.popupShowTicketComment.CustomizePopupWindowParams += new DevExpress.ExpressApp.Actions.CustomizePopupWindowParamsEventHandler(this.popupShowTicketComment_CustomizePopupWindowParams);
            this.popupShowTicketComment.Execute += new DevExpress.ExpressApp.Actions.PopupWindowShowActionExecuteEventHandler(this.popupShowTicketComment_Execute);
            // 
            // TicketController
            // 
            this.Actions.Add(this.popupShowTicketComment);

        }

        #endregion
        private DevExpress.ExpressApp.Actions.PopupWindowShowAction popupShowTicketComment;
    }
}
