using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Updating;
using Galaktika.External.Module.Converters;
using PromAktiv.Core.Module.Converters;
using PromAktiv.Module;
using PromAktiv.Module.Converters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Galaktika.External.Module
{
        public class UpdaterBefore : ModuleUpdater
        {
            public UpdaterBefore(IObjectSpace objectSpace, Version currentDBVersion)
                : base(objectSpace, currentDBVersion)
            {
            }

            public override void UpdateDatabaseBeforeUpdateSchema()
            {
                base.UpdateDatabaseBeforeUpdateSchema();
                List<Type> converters = new List<Type>
            {
                #region 3.1.3.0

                typeof(ComponentChangeJournalRenameConverter),
                typeof(ChangeNameConverter),
                typeof(ChangeReleaseVersionTo3_1Converter),

                #endregion 3.1.3.0

                #region 3.2.1.0

                typeof(EamBranchRenameConverter),
                typeof(LongNamesRenameConverter)                
                #endregion 3.2.1.0

                #region 4.1.1.0 
                , typeof(RenameSystemModuleInfoConverter)
                , typeof(RemoveAuditDataConverter)
                , typeof(RenameSystemXPObjectTypeConverter)
                , typeof(RenameSystemBeforeUpdateConverter)
                , typeof(RemoveOldRealizationIDeletedNumbersSupport)
                , typeof(ResizeNamePlaningObject)
                #endregion 4.1.1.0

                #region 4.2.1.0 
                , typeof(MQCleanupCriteriaConverter)
                , typeof(RenameRussianTablesToEnglishConverter)
                , typeof(UpdateSecuritySystemUserObjectTypeConverter)
                , typeof(ResizeBaseWorkServiceNameConverter)
                #endregion 4.2.1.0 
            };
                BaseConverter.ExecuteConverters(this.ObjectSpace, this.CurrentDBVersion, typeof(ExternalModule), converters);

                Trace.TraceInformation("Окончание выполнения функциии UpdateDatabaseBeforeUpdateSchema  в модуле [{0}].", this.GetType().FullName);
            }
        }

    }
