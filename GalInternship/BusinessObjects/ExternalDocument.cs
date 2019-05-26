using System;
using DevExpress.Xpo;
using DevExpress.Persistent.Base;
using PromAktiv.Module.Активы;
using DevExpress.ExpressApp.Model;
using System.Linq;
using Xafari.SmartDesign;
using System.ComponentModel;
using PromAktiv.Core.Module;
using System.Collections.Generic;

namespace Galaktika.External.Module.BusinessObjects
{
    //[Persistent("eamExternalDocument")]
    [SmartDesignStrategy(typeof(XafariSmartDesignStrategy))]
    [CreateListView(Layout = "Номер;Sum;ДатаДокумента;Asset;ExternalDocumentStatus;DocumentKind;DateBegin;DateEnd")]
    [CreateListView(IsDefaultTreeListView = true, Layout = "Код;Наименование;")]
    [CreateDetailView(Layout = "Номер;Sum;ДатаДокумента;Asset;ExternalDocumentStatus;DocumentKind;DateBegin;DateEnd;Operations;DocumentRemarks.Remarks;СвязиФайлы")]
    [CreateListView(Id = "ExternalDocument_LookupListView", Layout = "Image;Код;Наименование", ListViewType = ListViewType.LookupListView)]
    public class ExternalDocument : PromAktiv.Core.Module.Документ
    {
        public ExternalDocument(Session session)
            : base(session)
        {

        }


        private decimal _sum;
        public void CalculateSumma()
        {
            decimal summa = 0m;
            foreach (var oper in Operations)
                summa += oper.Sum;
            Sum = summa;
        }
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
        private ExternalDocumentStatus _externalDocumentStatus;
        public ExternalDocumentStatus ExternalDocumentStatus
        {
            get
            {
                return _externalDocumentStatus;
            }
            set
            {
                SetPropertyValue<ExternalDocumentStatus>("ExternalDocumentStatus", ref _externalDocumentStatus, value);
            }
        }
        private ExternalDocumentKind _documentKind;
        public ExternalDocumentKind DocumentKind
        {
            get
            {
                return _documentKind;
            }
            set
            {
                SetPropertyValue<ExternalDocumentKind>("DocumentKind", ref _documentKind, value);
            }
        }
        [Association("ExternalDoc-Operations"), Aggregated]
        public XPCollection<ExternalDocumentOperation> Operations
        {
            get { return GetCollection<ExternalDocumentOperation>("Operations"); }
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

        //protected override void OnChanged(string propertyName, object oldValue, object newValue)
        //{
        //    base.OnChanged(propertyName, oldValue, newValue);
        //    if (propertyName == "Asset")
        //    { 
        //    }
        //}

    }

}