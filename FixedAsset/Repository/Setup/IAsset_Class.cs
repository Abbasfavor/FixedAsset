using FixedAsset.Models.HelperModel;
using FixedAsset.Models.Setup.FAClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixedAsset.Repository.Setup
{
   public interface IAsset_Class:IDisposable
    {
        ReturnModel setup_FAClass(FAClassModel model);
        ReturnModel Up_FAClass(FAClassModel model);
        ReturnModel Del_FAClass(FAClassModel model);
        IEnumerable<FAClassModel> GetFAClass();
        FAClassModel GetClassByClassCode(string classcode);
    }
}
