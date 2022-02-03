using FixedAsset.Models.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixedAsset.Repository.Report
{
  public  interface IRptFAWrittenOffRepo :IDisposable

    {
        IEnumerable<RptFAWrittenOff> GetFAFAWrittenOff(string Branchcode, string FAClass, DateTime startdate, DateTime eddate);
    }
}
