using DevExpress.ExpressApp;
using PromAktiv.Module.Работы;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using PromAktiv.Module.BusinessOperations;
using System.Threading.Tasks;
using Xafari.BC.BusinessOperations;
using Xafari.BC.BusinessOperations.Attributes;
using DevExpress.ExpressApp.Utils;

namespace Galaktika.External.BusinessOperations
{
    [System.ComponentModel.DisplayName("Создать операцию журнала работ")]
    [Description("Создание операции журнала работ")]
    [BusinessOperation(typeof(AssetCreateServiceJournalItemOperation))]

    public class AssetCreateServiceJournalItemOperationServiceExternal : PromAktiv.Core.Module.BusinessOperations.RecoverableOperationServiceBase
    {
        public override void Execute(IBusinessOperation businessOperation)
        {
            using (var objectSpace = BusinessOperationManager.Instance.Application.CreateObjectSpace())
            {
                var bo = (AssetCreateServiceJournalItemOperation)businessOperation;
                var newOperation = objectSpace.CreateObject<ОперацияЖР>();
                ЖурналРабот serviceJournalItem = null;
                if (bo.ServiceJournalItem == null)
                {
                    bo.Process.NextStep("Создание операции",0,4, "Для операции не задан журнал работ", Xafari.ManagedOperations.TraceMessageTypes.Error);
                }
                else
                {
                    serviceJournalItem = objectSpace.GetObject(bo.ServiceJournalItem);
                    serviceJournalItem.Операции.Add(newOperation);
                   bo.Process.NextStep("Операция успешно создана");
                    objectSpace.CommitChanges();
                    bo.ResultObject = newOperation;
                }
            }
        }

    }
}
