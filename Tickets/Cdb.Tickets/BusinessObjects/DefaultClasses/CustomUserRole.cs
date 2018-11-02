using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.PermissionPolicy;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdb.Tickets.BusinessObjects.DefaultClasses
{
    [NavigationItem("User")]
    [ImageName("BO_Role")]
    public class CustomUserRole : PermissionPolicyRoleBase, IPermissionPolicyRoleWithUsers
    {
        public CustomUserRole(Session session)
        : base(session)
        {
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place here your initialization code.
        }

        [Association("CustomUsers-CustomRoles")]
        public XPCollection<CustomUser> Users
        {
            get
            {
                return GetCollection<CustomUser>("Users");
            }
        }

        IEnumerable<IPermissionPolicyUser> IPermissionPolicyRoleWithUsers.Users
        {
            get { return Users.OfType<IPermissionPolicyUser>(); }
        }
    }
}
