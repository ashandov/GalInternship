using DevExpress.ExpressApp.DC;
using DevExpress.XtraLayout.Customization;
using Galaktika.External.Module.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xafari.BC;
using Xafari.Reports;

namespace Galaktika.External.Module.Reports
{
    [DomainComponent, XafDisplayName("External Document report parameters")]
    public interface ExtDocParametrs : XafariReportParametersBase
    {
        [ContextProperty(ObjectsCriteria = "Number!=''")]
        //IList<ExternalDocument> Doc { get; }
        string Filter { get; set; }
    }
}   
