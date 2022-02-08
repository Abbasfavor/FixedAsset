using FixedAsset.Models;
using FixedAsset.Models.AssetRelocation;
using FixedAsset.Models.HelperModel;
using FixedAsset.Models.Setup.Branch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FixedAsset.Repository.AssetRelocation
{
    public interface IRelocation : IDisposable
    {


        ReturnModel CraeteAsetRelocat(AssetRelocationModel model);

        ReturnModel UpdateAsetRelocat(AssetRelocationModel model);

        AssetRelocationModel GetFalocationId(int Id);

        IEnumerable<AssetRelocationModel> GetRelocation();

        ReturnModel DeleteRelocatiom(AssetRelocationModel model);

        //IEnumerable<BrancModel> GetBranch();

        IEnumerable<AssetRelocationModel> GetFAClass();




    }
}