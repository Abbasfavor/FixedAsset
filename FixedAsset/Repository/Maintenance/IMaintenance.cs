using FixedAsset.Models.HelperModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FixedAsset.Models;
using FixedAsset.Models.maintenance;

namespace FixedAsset.Repository.Maintenance
{
    public interface IMaintenance : IDisposable
    {
        IEnumerable<AmortiseSet> Get_AmortiseType();
        ReturnModel CraeteMaintances(maintenance model);
        ReturnModel UpdateMaintances(maintenance model);
        IEnumerable<maintenance> GetMaintances();
        maintenance GetMaintainId(int Id);

        ReturnModel DeleteMaintain(maintenance model);
    }
}
