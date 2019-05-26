using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using PromAktiv.Common.Enums;
using PromAktiv.Core.CD.Module.ITM;
using PromAktiv.Core.Module;
using PromAktiv.Module.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaktika.External.Module.BusinessObjects
{
    [Persistent("eamExternalDocumentMaterial")]
    public class ExternalDocumentMaterial : PromAktiv.Core.Module.БазоваяСущность
    {
        public ExternalDocumentMaterial(Session session)
            : base(session)
        {

        }
        private int _number;
        public int Number
        {
            get
            {
                return _number;
            }
            set
            {
                SetPropertyValue<int>("Number", ref _number, value);
            }
        }
        private decimal _qty;
        public decimal Qty
        {
            get
            {
                return _qty;
            }
            set
            {
                SetPropertyValue<decimal>("Qty", ref _qty, value);
            }
        }
        private decimal _sum;


        public decimal Sum
        {
            get
            {
                return _sum;
            }
            set
            {
                SetPropertyValue<decimal>("Sum", ref _sum, value);
            }
        }

        private decimal _price;


        public decimal Price
        {
            get
            {
                return _price;
            }
            set
            {
                SetPropertyValue<decimal>("Price", ref _price, value);
            }
        }
        private НоменклатурнаяПозиция _material;
        public НоменклатурнаяПозиция Material
        {
            get
            {
                return _material;
            }
            set
            {
                SetPropertyValue<НоменклатурнаяПозиция>("Material", ref _material, value);
            }
        }
        private ExternalDocumentOperation _operation;
        [Association("Operations - Materials")]
        public ExternalDocumentOperation Operation
        {
            get
            {
                return _operation;
            }
            set
            {
                SetPropertyValue<ExternalDocumentOperation>("Operation", ref _operation, value);
            }
        }
       static MaterialCostCalculationLogic _Mccs = new MaterialCostCalculationLogic();
        public  static MaterialCostCalculationLogic Mccs
        {
            get { return _Mccs; }
        }

     
          

        protected  override void OnChanged(string propertyName, object oldValue, object newValue)
        {
            switch (propertyName)
            {
                case "Qty":
                    Mccs.OnChanged(this, "Qty", oldValue, newValue);
                   
                    break;

                case "Price":
                    Mccs.OnChanged(this, "Price", oldValue, newValue);
                    
                    break;

                case "Sum":
                    RunDelayed(Operation.CalculateSumma);
                    Mccs.OnChanged(this, "Sum", oldValue, newValue);
                    
                    break;
            }
        }
        protected override void OnDeleted()
        {
            base.OnDeleted();
            RunDelayed(Operation.CalculateSumma);
        }
        public class MaterialCostCalculationLogic : DependentFieldsLogic<ExternalDocumentMaterial>
        {
            /// <summary>
            /// Пересчет полей ЦенаЗаЕдиницу. КоличествоМатериалаВсего, СтоимостьМатериала
            /// Обработка изменения полей ЦенаЗаЕдиницу, КоличествоМатериалаВсего, СтоимостьМатериала
            /// </summary>
            /// <param name="instance"></param>
            /// <param name="propertyName"></param>
            /// <param name="oldValue"></param>
            /// <param name="newValue"></param>            
            public override void Calculate(ExternalDocumentMaterial instance, string propertyName, object oldValue, object newValue)
            {
                if (instance == null)
                    return;
                switch (propertyName)
                {
                    case "Price":
                        var _Sum = instance._sum;
                        ПересчетыHelper.ПересчетИзмениласьЦена((decimal)newValue, instance.Qty, ВходимостьНалогов.Входят, 0m, ref _Sum);
                        if (_Sum != instance.Sum)
                            instance._sum = _Sum;
                        break;

                    case "Sum":
                        var _Price = instance.Price;
                        var _Qty = instance.Qty;
                        ПересчетыHelper.ПересчетИзмениласьСумма((decimal)newValue, ВходимостьНалогов.Входят, 0m, ref _Price, ref _Qty);
                        if (instance.Price != _Price)
                            instance.Price = _Price;
                        if (instance.Qty != _Qty)
                            instance.Qty = _Qty;
                        break;

                    case "Qty":
                        var _Summa = instance.Sum;
                        ПересчетыHelper.ПересчетИзменилосьКоличество(instance.Price, (decimal)newValue, ВходимостьНалогов.Входят, 0m, ref _Summa);
                        if (_Summa != instance.Sum)
                            instance.Sum = _Summa;
                        break;

                }
            }

        }
    }
}



