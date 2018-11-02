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
using Cdb.Tickets.BusinessObjects.DefaultClasses;
using Cdb.Tickets.BusinessObjects.DomainComponent;

namespace Cdb.Tickets.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class TicketController : ViewController
    {
        #region Variables
        private bool IsNewObject;
        #endregion

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
            ObjectSpace.ObjectSaved += ObjectSpace_ObjectSaved;
            ObjectSpace.ObjectSaving += ObjectSpace_ObjectSaving;
        }

        private void ObjectSpace_ObjectSaving(object sender, ObjectManipulatingEventArgs e)
        {
            try
            {
                Ticket objTicket = (Ticket)e.Object;
                if (ObjectSpace != null && objTicket != null)
                    IsNewObject = ObjectSpace.IsNewObject(objTicket);
            }
            catch (Exception ex)
            {

            }
        }

        private void ObjectSpace_ObjectSaved(object sender, ObjectManipulatingEventArgs e)
        {
            try
            {
                if(IsNewObject)
                {
                    Ticket objTicket = (Ticket)e.Object;
                    if (objTicket != null)
                        SaveObjectNotificationTemplate(objTicket);
                }                
            }
            catch (Exception ex)
            {

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
            ObjectSpace.ObjectSaved -= ObjectSpace_ObjectSaved;
            ObjectSpace.ObjectSaving -= ObjectSpace_ObjectSaving;
            base.OnDeactivated();
        }

        private void SaveObjectNotificationTemplate(Ticket prm_objTicket)
        {
            try
            {
                IsNewObject = false;//Clear flag

                string strTicketType, strClient, strPriority;

                IObjectNotificationDetails objNotDetl = (ObjectNotificationDetails)
                    ObjectSpace.CreateObject(typeof(ObjectNotificationDetails)) as IObjectNotificationDetails;
                strTicketType = prm_objTicket.Type == null ? "" : prm_objTicket.Type.Ticket_Type;
                strClient = prm_objTicket.Client == null ? "" : prm_objTicket.Client.ClientName;
                strPriority = prm_objTicket.Priority == null ? "" : prm_objTicket.Priority.Ticket_Priority;

                objNotDetl.ObjectOid = prm_objTicket.Oid;
                objNotDetl.ObjectType = prm_objTicket.GetType().ToString();

                objNotDetl.TemplateForSave = "Ticket Created!" + "Ticket Type: " +
                    strTicketType + ", Client: " + strClient + ", Priority: " + strPriority + " is created on " + DateTime.Now;

                objNotDetl.TemplateForUpdate = "Ticket Updated!" + "Ticket Type: " + strTicketType + ", Client: " + strClient +
               ", Priority: " + strPriority + " has been updated on " + System.DateTime.Now;

                objNotDetl.TemplateForDelete = "Ticket Deleted!" + "Ticket Type: " + strTicketType + ", Client: " + strClient +
               ", Priority: " + strPriority + " has been deleted on " + System.DateTime.Now;

                //Get All user ids (except the posting user) 

                if (prm_objTicket.Assignee != null)
                    objNotDetl.UsersToSendEmail = prm_objTicket.Assignee.Oid.ToString();
                foreach (CustomUser watcher in prm_objTicket.Watchers)
                {
                    objNotDetl.UsersToSendEmail += "|" + watcher.Oid.ToString();
                }

                ObjectSpace.CommitChanges();
            }
            catch (Exception ex)
            {
            }
        }
    }
}
