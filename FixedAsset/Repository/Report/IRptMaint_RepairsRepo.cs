using FixedAsset.Models.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixedAsset.Repository.Report
{
    interface IRptMaint_RepairsRepo:IDisposable
    {
        IEnumerable<RptMaint_Repairs> GetMaint_Repairs();
    }
}
