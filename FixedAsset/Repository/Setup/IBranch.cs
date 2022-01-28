using FixedAsset.Models.HelperModel;
using FixedAsset.Models.Setup.Branch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixedAsset.Repository.Setup
{
  public  interface IBranch:IDisposable
    {
        ReturnModel setup_Branch(BrancModel model);
        ReturnModel Up_Branch(BrancModel model);
        IEnumerable<BrancModel> GetBranch();
        BrancModel GetBranchByCode(string BranchCode);
        ReturnModel DeleteBranch(BrancModel model);
    }
}
