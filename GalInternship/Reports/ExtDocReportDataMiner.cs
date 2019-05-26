
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xafari.Reports;
using Xafari.Utils;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;

namespace Galaktika.External.Module.Reports
{
    //Алгоритм наполнения источника                     
    public class ExtDocReportDataMiner : DataMinerOperationBase<ExtDocReportDataSource, ExtDocParametrs>
    {
        public override void CollectData()
        {
            ReportData.Caption = Parameters.Name;   
            base.CollectData();
        }

        protected  override  CriteriaOperator GetCriteria(string propertyName)
        {
            if (propertyName == MemberHelper.MemberName<ExtDocReportDataSource>(m => m.Documents))
                return base.GetCriteria(propertyName);
                return Parameters.Filter;

        }

    }
}
