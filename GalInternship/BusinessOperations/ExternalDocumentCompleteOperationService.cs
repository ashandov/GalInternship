using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xafari.BC.BusinessOperations;
using Xafari.BC.BusinessOperations.Attributes;

namespace Galaktika.External.Module.BusinessOperations
/// </summary>
{
    [BusinessOperation(typeof(ExternalDocumentCompleteOperation))]
    [DisplayName("Реализация по умолчанию")]
    [Description("Находит все операции с незаполненной датой окончания для выбранного документа и устанавливает для них введенную дату .")]

    public class ExternalDocumentCompleteOperationService : PromAktiv.Core.Module.BusinessOperations.RecoverableOperationServiceBase
    {
        public override void Execute(IBusinessOperation businessOperation)
        {

            var bo = (ExternalDocumentCompleteOperation)businessOperation;
            var insdate = bo.Date;

            using (var objectSpace = BusinessOperationManager.Instance.Application.CreateObjectSpace())
            {

                var operations = 0;
                foreach (var rawOper in bo.Operations)
                {
                    var oper = objectSpace.GetObject(rawOper); // Операция в текущем ObjectSpace.
                    if (oper.DateEnd == DateTime.MinValue)
                    {
                        oper.DateEnd = insdate;
                        operations++;
                    }
                }
                if (bo.Process != null)

                    bo.Process.NextStep(String.Format("Для {0} операций была проставлена дата окончания", operations));
                objectSpace.CommitChanges();
            }
        }
    }
}

