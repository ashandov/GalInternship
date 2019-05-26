using DevExpress.ExpressApp.Actions;
using DevExpress.Persistent.Base;
using Galaktika.External.Module.BusinessObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xafari.BC;
using Xafari.BC.BusinessOperations;
using Xafari.BC.BusinessOperations.Attributes;

namespace Galaktika.External.Module.BusinessOperations
{
    [DisplayName("Установка даты завершения для операций")]
    [Description("Находит все операции с незаполненной датой окончания для выбранного документа и устанавливает для них введенную дату .")]
    [ImageName("BO_Sale")]
    [ExecutionWay(ExecutionWays.Synchronous)]
    [ContextViewType(ContextViewType.Any)]
    [BusinessOperationCategory("Операции"), BusinessOperationCategory]
    [DefaultOperationService(typeof(ExternalDocumentCompleteOperationService))]
    public class ExternalDocumentCompleteOperation : Xafari.BC.BusinessOperations.BusinessOperationManagedBase
    {

        [ContextProperty(ObjectsCriteria = "[Number] != '00000'",
         ObjectsCriteriaMode = TargetObjectsCriteriaMode.TrueForAll)]
        public ICollection<ExternalDocumentOperation> Operations { get; set; }
        [DevExpress.Xpo.DisplayName("Дата")]
        public DateTime Date { get; set; }
    }
}