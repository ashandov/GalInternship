using System;
using PromAktiv.Core.Module.LogicControllers;
using Galaktika.External.Module.BusinessObjects;

namespace PromAktiv.Module.LogicControllers
{
    /// <summary>
    /// LogicController для обработки прикладной логики класса ВнешнийДокумент на визуальных формах.
    /// </summary>
    public class ExternalDocumentLogicController : LogicControllerBase<ExternalDocument>
    {
        public static ExternalDocumentLogicController CreateInstance()
        {
            return new ExternalDocumentLogicController();
        }

        /// <summary>
        /// Изменение свойства
        /// </summary>
        public override void PropertyValueChanging(object entity, string propertyName, object newValue, object oldValue)
        {
            base.PropertyValueChanging(entity, propertyName, newValue, oldValue);
            ExternalDocument extDoc = entity as ExternalDocument;
            if (extDoc == null)
                return;

            switch (propertyName)
            {

                case "Asset":
                    extDoc.ExternalDocumentStatus = null;
                    extDoc.DocumentKind = null;
                    extDoc.DateBegin = DateTime.MinValue;
                    extDoc.DateEnd = DateTime.MinValue;
                    extDoc.Sum = 0;
                    extDoc.Operations.Session.Delete(extDoc.Operations);
                    break;
            
            }
        }


        public override void UpdatePropertyVisualisationInfo(object entity)
        {
            base.UpdatePropertyVisualisationInfo(entity);
            var doc = entity as ExternalDocument;
            if (doc == null)
                return;

            if (doc.GetMemberValue("Asset") == null)
                AddPropertyEditingInfo("Operations", false, "Недоступно т.к не задан Объект ремонта.");
                AddPropertyEditingInfo("DateBegin", false, "Недоступно т.к не задан Объект ремонта.");
                AddPropertyEditingInfo("DateEnd", false, "Недоступно т.к не задан Объект ремонта.");
                AddPropertyEditingInfo("DocumentKind", false, "Недоступно т.к не задан Объект ремонта.");
                AddPropertyEditingInfo("ExternalDocumentStatus", false, "Недоступно т.к не задан Объект ремонта.");
                AddPropertyEditingInfo("Sum", false, "Недоступно т.к не задан Объект ремонта.");
        }
    }
}
