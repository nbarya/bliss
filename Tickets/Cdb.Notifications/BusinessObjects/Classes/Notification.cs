using Cdb.Notifications.BusinessObjects.Interfaces;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Cdb.Notifications.BusinessObjects.Classes
{
    public class Notification : XPObject, INotification
    {
        public Notification() : base()
        {
            // This constructor is used when an object is loaded from a persistent storage.
            // Do not place any code here.
        }

        public Notification(Session session) : base(session)
        {
            // This constructor is used when an object is loaded from a persistent storage.
            // Do not place any code here.
        }

    [Size(250)]
        public string Email { get; set; }
        public NotificationTypeEnum NotificationType { get; set; }
        public DateTime EmailDate { get; set; }
        [Size(250)]
        public string Message { get; set; }
        public EmailNotificationStatusEnum Status { get; set; }

        public enum NotificationTypeEnum
        {
            TicketCreated = 1, TicketUpdated, TicketDeleted,
            TicketCommentCreated, TicketCommentEdited, TicketCommentDeleted
        }

        public enum EmailNotificationStatusEnum
        {
            Success = 1,
            Cancelled
        }

        public static List<INotification> SendNotification(List<string> prm_lstUserEmail, string prm_strMessage)
        {
            bool blnSuccess = false;

            INotification objNotification;
            List<INotification> lstNotification = new List<INotification>();
            foreach (string strEmail in prm_lstUserEmail)
            {
                //objSendEmailNotif = new SendEmailNotification();
                blnSuccess = SendEmail_Notification(strEmail, prm_strMessage);
                objNotification = new Notification(new DevExpress.Xpo.Session())
                {
                    Email = strEmail,
                    NotificationType = Notification.NotificationTypeEnum.TicketCreated,
                    EmailDate = DateTime.Now,
                    Message = prm_strMessage,
                    Status = blnSuccess ? Notification.EmailNotificationStatusEnum.Success : Notification.EmailNotificationStatusEnum.Cancelled
                };
                lstNotification.Add(objNotification);
            }
            return lstNotification;
        }

        public static bool SendEmail_Notification(string prm_strUserEmail, string prm_strMessage)
        {
            try
            {
                MailMessage mail = new MailMessage("yourEmail@gmail.com", prm_strUserEmail);
                SmtpClient client = new SmtpClient();
                client.Credentials = new System.Net.NetworkCredential("yourEmail@gmail.com", "yourqert123");
                client.Port = 25;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Host = "smtp.gmail.com";
                client.EnableSsl = true;
                mail.Subject = prm_strMessage.Substring(0, 10);
                mail.Body = prm_strMessage;
                //uncomment below line to send email//
                //client.Send(mail);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
