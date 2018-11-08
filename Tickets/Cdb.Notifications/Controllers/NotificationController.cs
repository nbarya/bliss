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
using Cdb.Notifications.BusinessObjects.Classes;
using Cdb.Notifications.BusinessObjects.Interfaces;

namespace Cdb.Notifications.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class NotificationController : ViewController
    {
        #region Variables
        private NotificationsModule module;
        private bool IsNewObject,IsDeleted;
        
        private List<string> lstEmails;
        #endregion

        #region Constructor
        public NotificationController()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
        }
        #endregion

        #region Events
        //
        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
            ObjectSpace.ObjectSaved += ObjectSpace_ObjectSaved;
            ObjectSpace.ObjectSaving += ObjectSpace_ObjectSaving;
           
            module = Application.Modules.FindModule<NotificationsModule>();
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
        //
        
        //Saving
        private void ObjectSpace_ObjectSaving(object sender, ObjectManipulatingEventArgs e)
        {
            NotificationObjects objNotifyObj = module.NotificationObjects.Find(obj => obj.ObjectType == e.Object.GetType());

            if (ObjectSpace != null && objNotifyObj != null)
            {
                IsNewObject = ObjectSpace.IsNewObject(objNotifyObj);
                IsDeleted = ObjectSpace.IsDeletedObject(objNotifyObj);

            }
        }
        //Saved
        private void ObjectSpace_ObjectSaved(object sender, ObjectManipulatingEventArgs e)
        {
            NotificationObjects objNotifyCur = module.NotificationObjects.Find(obj => obj.ObjectType == e.Object.GetType());

            if (objNotifyCur != null)
            {
                CriteriaOperator criteria = CriteriaOperator.Parse(objNotifyCur.ObjectCriteria);
                bool? matchCriteria = ObjectSpace.IsObjectFitForCriteria(objNotifyCur.ObjectType, e.Object, criteria);
                if (matchCriteria == true)
                {
                    //Get Emails//                       
                    int intOid = (int)View.ObjectSpace.GetKeyValue(View.CurrentObject);
                    ObjectNotificationDetails objNotfDtl = ObjectSpace.GetObjects<ObjectNotificationDetails>().Where(
                        not => not.ObjectType == objNotifyCur.ObjectType.ToString() && not.ObjectOid == intOid).FirstOrDefault();
                    List<int> lstUserIds = objNotfDtl.UsersToSendEmail.Split('|').Select(Int32.Parse).ToList();
                    lstEmails = ObjectSpace.GetObjects<NotificationUser>().Where(nu => lstUserIds.Contains(nu.Oid)).
                        Select(usr => usr.Email).ToList();

                    List<INotification> lstNotification = new List<INotification>();
                    if (lstEmails.Count > 0)
                    {
                        if (objNotifyCur.IsNotificationForDeletion && IsDeleted)//Deletion
                        {
                            lstNotification = Notification.SendNotification(lstEmails, objNotfDtl.TemplateForDelete);
                        }
                        else
                        {
                            if (objNotifyCur.IsNotificationForCreation && IsNewObject)//Creation
                            {
                                lstNotification = Notification.SendNotification(lstEmails, objNotfDtl.TemplateForSave);
                            }
                            if (objNotifyCur.IsNotificationForUpdation && !IsNewObject)//Updation
                            {
                                lstNotification = Notification.SendNotification(lstEmails, objNotfDtl.TemplateForUpdate);
                            }
                        }

                        //Update Notification table//
                        INotification objNotification;
                        foreach (Notification objNot in lstNotification)
                        {
                            //ObjectSpace.CreateObject(commentType) as IComment;
                            IObjectSpace objObSpc = Application.CreateObjectSpace();
                            objNotification = (Notification)objObSpc.CreateObject(typeof(Notification)) as INotification;
                            objNotification.Email = objNot.Email;
                            objNotification.NotificationType = objNot.NotificationType;
                            objNotification.EmailDate = objNot.EmailDate;
                            objNotification.Message = objNot.Message;
                            objNotification.Status = objNot.Status;
                            objObSpc.CommitChanges();
                        }

                        lstEmails = new List<string>();
                    }
                }
            }
        }
        //
        #endregion

       

      
    }
}
