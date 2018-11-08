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
using Cdb.Tickets.BusinessObjects.DefaultClasses;

namespace Cdb.Tickets.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class CommentController : ViewController
    {
        #region Variables
        private bool IsNewObject;
        #endregion

        public CommentController()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
            TargetObjectType = typeof(ITicketComment);
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
            ObjectSpace.ObjectSaved += ObjectSpace_ObjectSaved;
            ObjectSpace.ObjectSaving += ObjectSpace_ObjectSaving;
        }

        private void ObjectSpace_ObjectSaving(object sender, ObjectManipulatingEventArgs e)
        {
            TicketComment objTicket = (TicketComment)e.Object;
            if (ObjectSpace != null && objTicket != null)
                IsNewObject = ObjectSpace.IsNewObject(objTicket);
        }

        private void ObjectSpace_ObjectSaved(object sender, ObjectManipulatingEventArgs e)
        {
            if (IsNewObject)
            {
                TicketComment objTicketCmnt = (TicketComment)e.Object;
                if (objTicketCmnt != null)
                    SaveObjectNotificationTemplate(objTicketCmnt);
            }
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

        private void SaveObjectNotificationTemplate(TicketComment prm_objTicketCmnt)
        {
            IsNewObject = false;//Clear flag
            if (prm_objTicketCmnt.Oid > 0)
            {
                string strCommentedby, strTicketType, strClient;

                IObjectNotificationDetails objNotDetl = (ObjectNotificationDetails)
                    ObjectSpace.CreateObject(typeof(ObjectNotificationDetails)) as IObjectNotificationDetails;
                strTicketType = prm_objTicketCmnt.Ticket.Type == null ? "" : prm_objTicketCmnt.Ticket.Type.Ticket_Type;
                strClient = prm_objTicketCmnt.Ticket.Client == null ? "" : prm_objTicketCmnt.Ticket.Client.ClientName;
                strCommentedby = prm_objTicketCmnt.CommentedBy == null ? "" : prm_objTicketCmnt.CommentedBy.UserName;

                objNotDetl.ObjectOid = prm_objTicketCmnt.Oid;
                objNotDetl.ObjectType = prm_objTicketCmnt.GetType().ToString();

                objNotDetl.TemplateForSave = "Ticket Commented!" + strCommentedby + " has commented on Ticket, Ticket Type: "
                + strTicketType + ", Client: " + strClient;

                objNotDetl.TemplateForUpdate = "Ticket Comment Edited!" + strCommentedby + " has edited the comment on Ticket, Ticket Type: "
               + strTicketType + ", Client: " + strClient;

                objNotDetl.TemplateForDelete = "Ticket Comment Deleted!" + strCommentedby + " has deleted the comment on Ticket, Ticket Type: "
               + strTicketType + ", Client: " + strClient;

                //Get All user ids (except the posting user) 

                if (prm_objTicketCmnt.Ticket.Assignee != null)
                    objNotDetl.UsersToSendEmail = prm_objTicketCmnt.Ticket.Assignee.Oid.ToString();
                foreach (CustomUser watcher in prm_objTicketCmnt.Ticket.Watchers)
                {
                    objNotDetl.UsersToSendEmail += "|" + watcher.Oid.ToString();
                }

                ObjectSpace.CommitChanges();
            }
        }
    }
}
