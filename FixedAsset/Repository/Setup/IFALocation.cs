using FixedAsset.Models.FALocation;
using FixedAsset.Models.HelperModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixedAsset.Repository.Setup
{
   public interface IFALocation:IDisposable
    {
        FALocationModel GetClassByClassCode(string locationCode);
        IEnumerable<FALocationModel> GetFALocation();
        ReturnModel Del_FALocation(FALocationModel model);
        ReturnModel Up_FAlocation(FALocationModel model);
        ReturnModel setup_Location(FALocationModel model);

    }
}
