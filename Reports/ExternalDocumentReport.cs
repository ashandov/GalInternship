using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xafari.BC;
using Xafari.Reports;

namespace Galaktika.External.Module.Reports
{
    [XafDisplayName("External document report"), ImageName("BO_Person")]
    
    public  class ExternalDocumentReport : XafariReport<ExtDocReportDataSource, ExtDocParametrs, ExtDocReportDataMiner> { }
}
