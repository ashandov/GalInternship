using PromAktiv.Module.Активы;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xafari.Reports.File;

namespace Galaktika.External.Module.Reports
{
    public class ExtDocReportFileGenerator : XafariFileReportGenerator<ExtDocReportDataSource, ExtDocParametrs>
    {
        protected override void GenerateCore()
        {
            var stream = GetStream("ExternalDocSumma.txt");
            var writer = new StreamWriter(stream, Encoding.UTF8);
            writer.WriteLine("=== {0} ===", ReportData.Caption);
            foreach (var document in ReportData.Documents)
            {
                var asset=(ОбъектРемонта)(document.GetMemberValue("Asset"));
                writer.WriteLine("{0}, {1}, {2}, {3}", document.Номер,asset.Код,asset.Наименование);
            }
            writer.Flush();
        }

    }
}
