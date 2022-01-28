using FixedAsset.Models.AssetAcuisition;
using FixedAsset.Models.HelperModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixedAsset.Repository.AssetAcquis
{
  public  interface IAssetAcquisition:IDisposable
    {
        AssetModel GetFixedAssetByCode(string classcode);
        IEnumerable<AssetModel> Get_FixedAsset();
        ReturnModel Del_FixedAsset(AssetModel model);
        ReturnModel Up_FixedAsset(AssetModel model);
        ReturnModel InsFixedAsset(AssetModel model);
    }
}
