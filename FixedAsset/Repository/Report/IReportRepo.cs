using FixedAsset.Models.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixedAsset.Repository.Report
{
  public  interface IReportRepo:IDisposable
    {
        IEnumerable<Models.Reports.RptFARegister> GetFARegister(string Branchcode, string FAClass);
        IEnumerable<RptFADisposed> GetFADisposed(string Branchcode, string FAClass, DateTime startdate, DateTime eddate);
        IEnumerable<RptFAWrittenOff> GetFAWrittenOff(string Branchcode, string FAClass, DateTime startdate, DateTime eddate);
        IEnumerable<RptFAMaint_Repairs> GetFAMaint_Repairs();
        IEnumerable<RptMaintRepairByCode> GetFAMaintRepairByCode(string FaCode, int retportType);
    }
}
