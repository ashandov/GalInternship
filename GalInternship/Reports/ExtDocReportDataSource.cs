using DevExpress.Persistent.Base;
using Galaktika.External.Module.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xafari.Reports;

namespace Galaktika.External.Module.Reports
{
    [VisibleInReports(true)]
    public class ExtDocReportDataSource : XafariReportDataBase
    {
        public string Caption { get; set; }
        public IList<ExternalDocument> Documents { get; set; }
    }
}
