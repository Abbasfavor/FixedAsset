using FixedAsset.Models.HelperModel;
using FixedAsset.Models.Setup;
using FixedAsset.Models.Setup.FACategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixedAsset.Repository.Setup
{
  public  interface IAsset_Category: IDisposable
    {
        Asset_Categorym GetCategoryById(string catcode);
        IEnumerable<Asset_Categorym> GetCategory();
        ReturnModel setup_FACategory(Asset_Categorym model);
        ReturnModel Up_FACategory(Asset_Categorym model);
        ReturnModel Del_FACategory(Asset_Categorym model);

    }
}
