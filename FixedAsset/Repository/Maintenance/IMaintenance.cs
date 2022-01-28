using FixedAsset.Models.HelperModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixedAsset.Repository.Maintenance
{
   public interface IMaintenance:IDisposable
    {
        IEnumerable<AmortiseSet> Get_AmortiseType();
    }
}
