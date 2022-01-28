using FixedAsset.Models.HelperModel;
using FixedAsset.Models.Setup.AncillaryCost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixedAsset.Repository.Setup
{
  public  interface IAncillaryCost:IDisposable
    {
        ReturnModel setup_AncillaryCost(AncillaryCostm model);
        ReturnModel Update_AncillaryCost(AncillaryCostm model);
        IEnumerable<AncillaryCostm> GetAncillaryCost();
        AncillaryCostm GetAncillaryCostByCode(string CostCode);
        ReturnModel DeleteAncillaryCost(AncillaryCostm model);
    }
}
