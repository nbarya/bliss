using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using Cdb.Tickets.BusinessObjects.DomainComponent;

namespace Cdb.Tickets.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class TicketController : ViewController
    {
        Type ticketCommentType;

        public TicketController()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
            TargetObjectType = typeof(ITicket);
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
            var module = this.Application.Modules.FindModule<TicketsModule>();
            ticketCommentType = module.TicketCommentDataType;
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }       

        private void popupShowTicketComment_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {
            e.PopupWindowView.ObjectSpace.CommitChanges();
            ITicket ticket = (ITicket)View.CurrentObject;
            ITicketComment comment = (ITicketComment)View.ObjectSpace.GetObject(e.PopupWindowViewCurrentObject);

            ticket.Comments.Add(comment);
            ObjectSpace.CommitChanges();
            //View.Close();
        }

        private void popupShowTicketComment_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            //IObjectSpace objectSpace = Application.CreateObjectSpace(ticketCommentType);
            IObjectSpace objectSpace = ObjectSpace.CreateNestedObjectSpace();
            ITicketComment pca = objectSpace.CreateObject(ticketCommentType) as ITicketComment;
            e.View = Application.CreateDetailView(objectSpace, pca, true);
            
        }
    }
}
