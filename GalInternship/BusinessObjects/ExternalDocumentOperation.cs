using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using PromAktiv.Core.Module;
using PromAktiv.Module.Активы;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Galaktika.External.Module.BusinessObjects
{
    [Persistent("eamExternalDocumentOperation")]
    public class ExternalDocumentOperation : PromAktiv.Core.Module.БазоваяСущность
    {
        public ExternalDocumentOperation(Session session)
            : base(session)
        {

        }

        private int _Number;
        private decimal _qty;
        public int Number
        {
            get
            {
                return _Number;
            }
            set
            {
                SetPropertyValue<int>("Number", ref _Number, value);
            }
        }

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
        [Association("Operations - Materials"), Aggregated]
        public XPCollection<ExternalDocumentMaterial> Materials
        {
            get { return GetCollection<ExternalDocumentMaterial>("Materials"); }
        }
        private DateTime _dateBegin;
        public DateTime DateBegin
        {
            get
            {
                return _dateBegin;
            }
            set
            {
                SetPropertyValue<DateTime>("DateBegin", ref _dateBegin, value);
            }
        }

        private DateTime _dateEnd;
        public DateTime DateEnd
        {
            get
            {
                return _dateEnd;
            }
            set
            {
                SetPropertyValue<DateTime>("DateEnd", ref _dateEnd, value);
            }
        }
        private TimeSpan _duration;
        public TimeSpan Duration
        {
            get
            {
                return _duration;
            }
            set
            {
                SetPropertyValue<TimeSpan>("Duration", ref _duration, value);
            }
        }
        private ExternalDocument _doc;
        [Association("ExternalDoc-Operations")]
        public ExternalDocument Doc
        {
            get
            {
                return _doc;
            }
            set
            {
                SetPropertyValue<ExternalDocument>("Doc", ref _doc, value);
            }
        }
        public void CalculateSumma()
        {
            decimal summa = 0m;
            foreach (var mat in Materials)
                summa += mat.Sum;
            Sum = summa;
        }

        protected override void OnChanged(string propertyName, object oldValue, object newValue)
        {
            base.OnChanged(propertyName, oldValue, newValue);
            if (propertyName == "Sum")
            {
                RunDelayed(Doc.CalculateSumma);
            }
            switch (propertyName)
            {
                case "DateBgin":
                    Dcs.OnChanged(this, "DateBgin", oldValue, newValue);

                    break;

                case "DateEnd":
                    Dcs.OnChanged(this, "DateEnd", oldValue, newValue);

                    break;

                case "Duration":
                    Dcs.OnChanged(this, "Duration", oldValue, newValue);

                    break;
            }

        }
        protected override void OnDeleted()
        {

            base.OnDeleted();
            RunDelayed(Doc.CalculateSumma);
        }
        static DurationCalculationLogic _Dcs = new DurationCalculationLogic();
        public static DurationCalculationLogic Dcs
        {
            get { return _Dcs; }
        }
        public class DurationCalculationLogic : DependentFieldsLogic<ExternalDocumentOperation>
        {
            public override void Calculate(ExternalDocumentOperation instance, string propertyName, object oldValue, object newValue)
            {
                if (instance == null && oldValue != newValue)
                    return;
                switch (propertyName)
                {
                    case "DateBegin":
                        {
                            instance.Duration = instance.DateEnd - instance.DateBegin;
                            break;
                        }
                    case "DateEnd":
                        {
      
                                instance.Duration = instance.DateEnd - instance.DateBegin;
                            break;
                        }
                    case "Duration":
                            {
                            instance.DateEnd = instance.DateBegin.Add(instance.Duration);
                            break;
                        }



                }
            }
        }
    }
}
