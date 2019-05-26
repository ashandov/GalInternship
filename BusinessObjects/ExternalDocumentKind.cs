using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using PromAktiv.Module.Classification;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xafari.Base;
using Xafari.BC.HierarchicalData;
using Xafari.SmartDesign;

namespace Galaktika.External.Module.BusinessObjects


{
    [Persistent("eamExternalDocumentKind")]
    [SmartDesignStrategy(typeof(XafariSmartDesignStrategy))]
    [CreateListView(Layout = "Image;Код;Наименование;Parent", ListViewType = ListViewType.ListView)]
    [CreateListView(Id = "ExternalDocumentKind_TreeView", IsDefaultTreeListView = true, Layout = "Код;Наименование")]
    [CreateDetailView(Layout = "Код;ImageName;Наименование;Parent.Код;Parent;Children;СвязиФайлы")]
    [CreateListView(Id = "ExternalDocumentKind_LookupListView", Layout = "Image;Код;Наименование", ListViewType = ListViewType.LookupListView)]
    public class ExternalDocumentKind : PromAktiv.Core.Module.СправочникИерархическийШаблон<ExternalDocumentKind>, IHierarchyNode
    {
        public ExternalDocumentKind(DevExpress.Xpo.Session session)
            : base(session)
        {

        }
        [Association("ExternalDocumentKind_Hier")]
        [VisibleInListView(false), VisibleInLookupListView(false)]
        [Persistent]
        [NoForeignKey, Indexed]
        [ImmediatePostData]
        [DataSourceCriteria("Oid != '@This.Oid'")]
        [ParentProperty]
        public ExternalDocumentKind Parent
        {
            get { return GetPropertyValue<ExternalDocumentKind>("Parent"); }
            set { SetPropertyValue<ExternalDocumentKind>("Parent", value); }
        }
        [Association("ExternalDocumentKind_Hier")]
        [ChildrenProperty]
        public XPCollection<ExternalDocumentKind> Children
        {
            get
            {
                return GetCollection<ExternalDocumentKind>("Children");
            }
        }


    }
}