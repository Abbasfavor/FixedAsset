using FixedAsset.Models.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixedAsset.Repository.Report
{
  public  interface IRptFARegisterRepo:IDisposable
    {
        IEnumerable<Models.Reports.RptFARegister> GetFARegister(string Branchcode, string FAClass);
    }
}
