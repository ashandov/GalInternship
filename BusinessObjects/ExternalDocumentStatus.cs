using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PromAktiv.Core.Module;
using DevExpress.Xpo;
using Xafari.SmartDesign;
using DevExpress.Persistent.Base;
using Xafari.Base;
using Xafari.BC.HierarchicalData;

namespace Galaktika.External.Module.BusinessObjects
{


    [SmartDesignStrategy(typeof(XafariSmartDesignStrategy))]
    [CreateListView(Layout = "Image;Код;Наименование")]
    [CreateDetailView(Layout = "Код;ImageName;Наименование;СвязиФайлы")]
    [CreateListView(Id ="ExternalDocumentStatus_LookupListView",Layout = "Код;Image;Наименование", ListViewType = ListViewType.LookupListView)]

    public class ExternalDocumentStatus : PromAktiv.Core.Module.Справочник
    {
        public ExternalDocumentStatus(DevExpress.Xpo.Session session)
            : base(session)
        {
        }
       
        }
    }

