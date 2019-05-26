using DevExpress.ExpressApp;
using DevExpress.Xpo;
using PromAktiv.Core.Module;
using PromAktiv.Core.Module.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PromAktiv.Utils.DB;

namespace Galaktika.External.Module.Converters
{
        [Description("Переименовывает таблицу ExternalDocument  в eamExternalDocument.")]
        [NonPersistent]
        [RequiredVersion(1, 0, 6521,27510)]
        [MultipleExecute(false)]
        [BreakConvertWhenFailed(false)]
        [Number(1015)]
        public class ChangeNameConverter : BaseConverter
        {
            public ChangeNameConverter(IObjectSpace objectSpace, Version currentDBVersion, Type moduleType)
               : base(objectSpace, currentDBVersion, moduleType)
            { }

            protected override void ExecuteCore()
            {
                var dbManager = EAMDBFactory.DBManager;
                if (dbManager != null)
                {
                    if (dbManager.IsTableExists("ExternalDocument") && !(dbManager.IsTableExists("eamExternalDocument")))
                        dbManager.RenameTable("ExternalDocument", "eamExternalDocument");
                }
            }
        }
    }

