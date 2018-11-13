using System;
using System.Text;
using System.Linq;
using DevExpress.ExpressApp;
using System.ComponentModel;
using DevExpress.ExpressApp.DC;
using System.Collections.Generic;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Updating;
using DevExpress.ExpressApp.Model.Core;
using DevExpress.ExpressApp.Model.DomainLogics;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.Xpo;
using Cdb.Tickets.BusinessObjects.DefaultClasses;
using Cdb.Tickets.BusinessObjects.DomainComponent;
using DevExpress.ExpressApp.Utils;
using DevExpress.ExpressApp.Design;

namespace Cdb.Tickets {
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppModuleBasetopic.aspx.
    public sealed partial class TicketsModule : ModuleBase {

        public TicketsModule() {
            InitializeComponent();
			BaseObject.OidInitializationMode = OidInitializationMode.AfterConstruction;
        }

        public override IEnumerable<ModuleUpdater> GetModuleUpdaters(IObjectSpace objectSpace, Version versionFromDB)
        {
            ModuleUpdater updater = new DatabaseUpdate.Updater(objectSpace, versionFromDB, this);
            return new ModuleUpdater[] { updater };
        }

        public override void Setup(XafApplication application) {
            base.Setup(application);
            // Manage various aspects of the application UI and behavior at the module level.
        }

        public override void CustomizeTypesInfo(ITypesInfo typesInfo) {
            base.CustomizeTypesInfo(typesInfo);
            CalculatedPersistentAliasHelper.CustomizeTypesInfo(typesInfo);
        }

        //*****************************************************************************************************************//
        #region DataTypes

        protected override IEnumerable<Type> GetDeclaredExportedTypes()
        {
            return new Type[] {
                typeof(Ticket), typeof(TicketComment),
                typeof(TicketPriority),typeof(TicketSource),
                typeof(TicketState),typeof(TicketTarget),
                typeof(TicketType)
            };
        }

        //protected override IEnumerable<Type> GetDeclaredControllerTypes()
        //{
        //    return new Type[]
        //    {
        //        typeof(TicketTestController)
        //    };
        //}

        #region Ticket DataType
        private bool isTicketDataTypeInitialized;

        private Type ticketDataType;
        [TypeConverter(typeof(BusinessClassTypeConverter<ITicket>))]
        public Type TicketDataType
        {
            get
            {
                if (!isTicketDataTypeInitialized)
                {
                    isTicketDataTypeInitialized = true;
                    ticketDataType = FindDefaultTicketDataType();
                }
                return ticketDataType;
            }
            set
            {
                if (value != null)
                {
                    Guard.TypeArgumentIs(typeof(ITicket), value, nameof(TicketDataType));
                }
                isTicketDataTypeInitialized = true;
                ticketDataType = value;
            }
        }
        public static Type FindDefaultTicketDataType()
        {
            return typeof(Ticket);
        }
        #endregion

        #region TicketComment DataType
        private bool isTicketCommentDataTypeInitialized;

        private Type ticketCommentDataType;
        [TypeConverter(typeof(BusinessClassTypeConverter<ITicketComment>))]
        public Type TicketCommentDataType
        {
            get
            {
                if (!isTicketCommentDataTypeInitialized)
                {
                    isTicketCommentDataTypeInitialized = true;
                    ticketCommentDataType = FindDefaultTicketCommentDataType();
                }
                return ticketCommentDataType;
            }
            set
            {
                if (value != null)
                {
                    Guard.TypeArgumentIs(typeof(ITicketComment), value, nameof(TicketCommentDataType));
                }
                isTicketCommentDataTypeInitialized = true;
                ticketCommentDataType = value;
            }
        }
        public static Type FindDefaultTicketCommentDataType()
        {
            return typeof(TicketComment);
        }
        #endregion

        #region TicketPriority DataType
        private bool isTicketPriorityDataTypeInitialized;

        private Type ticketPriorityDataType;
        [TypeConverter(typeof(BusinessClassTypeConverter<ITicketPriority>))]
        public Type TicketPriorityDataType
        {
            get
            {
                if (!isTicketPriorityDataTypeInitialized)
                {
                    isTicketPriorityDataTypeInitialized = true;
                    ticketPriorityDataType = FindDefaultTicketPriorityDataType();
                }
                return ticketPriorityDataType;
            }
            set
            {
                if (value != null)
                {
                    Guard.TypeArgumentIs(typeof(ITicketPriority), value, nameof(TicketPriorityDataType));
                }
                isTicketPriorityDataTypeInitialized = true;
                ticketPriorityDataType = value;
            }
        }
        public static Type FindDefaultTicketPriorityDataType()
        {
            return typeof(TicketPriority);
        }
        #endregion

        #region TicketSource DataType
        private bool isTicketSourceDataTypeInitialized;

        private Type ticketSourceDataType;
        [TypeConverter(typeof(BusinessClassTypeConverter<ITicketSource>))]
        public Type TicketSourceDataType
        {
            get
            {
                if (!isTicketSourceDataTypeInitialized)
                {
                    isTicketSourceDataTypeInitialized = true;
                    ticketSourceDataType = FindDefaultTicketSourceDataType();
                }
                return ticketSourceDataType;
            }
            set
            {
                if (value != null)
                {
                    Guard.TypeArgumentIs(typeof(ITicketSource), value, nameof(TicketSourceDataType));
                }
                isTicketSourceDataTypeInitialized = true;
                ticketSourceDataType = value;
            }
        }
        public static Type FindDefaultTicketSourceDataType()
        {
            return typeof(TicketSource);
        }
        #endregion

        #region TicketState DataType
        private bool isTicketStateDataTypeInitialized;

        private Type ticketStateDataType;
        [TypeConverter(typeof(BusinessClassTypeConverter<ITicketState>))]
        public Type TicketStateDataType
        {
            get
            {
                if (!isTicketStateDataTypeInitialized)
                {
                    isTicketStateDataTypeInitialized = true;
                    ticketStateDataType = FindDefaultTicketStateDataType();
                }
                return ticketStateDataType;
            }
            set
            {
                if (value != null)
                {
                    Guard.TypeArgumentIs(typeof(ITicketState), value, nameof(TicketStateDataType));
                }
                isTicketStateDataTypeInitialized = true;
                ticketStateDataType = value;
            }
        }
        public static Type FindDefaultTicketStateDataType()
        {
            return typeof(TicketState);
        }
        #endregion

        #region TicketTarget DataType
        private bool isTicketTargetDataTypeInitialized;

        private Type ticketTargetDataType;
        [TypeConverter(typeof(BusinessClassTypeConverter<ITicketTarget>))]
        public Type TicketTargetDataType
        {
            get
            {
                if (!isTicketTargetDataTypeInitialized)
                {
                    isTicketTargetDataTypeInitialized = true;
                    ticketTargetDataType = FindDefaultTicketTargetDataType();
                }
                return ticketTargetDataType;
            }
            set
            {
                if (value != null)
                {
                    Guard.TypeArgumentIs(typeof(ITicketTarget), value, nameof(TicketTargetDataType));
                }
                isTicketTargetDataTypeInitialized = true;
                ticketTargetDataType = value;
            }
        }
        public static Type FindDefaultTicketTargetDataType()
        {
            return typeof(TicketTarget);
        }
        #endregion

        #region TicketType DataType
        private bool isTicketTypeDataTypeInitialized;

        private Type ticketTypeDataType;
        [TypeConverter(typeof(BusinessClassTypeConverter<ITicketType>))]
        public Type TicketTypeDataType
        {
            get
            {
                if (!isTicketTypeDataTypeInitialized)
                {
                    isTicketTypeDataTypeInitialized = true;
                    ticketTypeDataType = FindDefaultTicketTypeDataType();
                }
                return ticketTypeDataType;
            }
            set
            {
                if (value != null)
                {
                    Guard.TypeArgumentIs(typeof(ITicketType), value, nameof(TicketTypeDataType));
                }
                isTicketTypeDataTypeInitialized = true;
                ticketTypeDataType = value;
            }
        }
        public static Type FindDefaultTicketTypeDataType()
        {
            return typeof(TicketType);
        }
        #endregion

        #endregion
        //*****************************************************************************************************************//
    }
}
