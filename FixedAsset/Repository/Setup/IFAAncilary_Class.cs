using FixedAsset.Models.HelperModel;
using FixedAsset.Models.Setup.FAAncilaryClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixedAsset.Repository.Setup
{
   public interface IFAAncilary_Class:IDisposable
    {
        FAAncilaryClassModel GetAncilaryClassByClassCode(string classcode);
        IEnumerable<FAAncilaryClassModel> GetFAAncilaryClass();
        ReturnModel Del_FAAncilaryClass(FAAncilaryClassModel model);
        ReturnModel Up_FAAncilaryClass(FAAncilaryClassModel model);
        ReturnModel setup_FAAncilryClass(FAAncilaryClassModel model);

    }
}
