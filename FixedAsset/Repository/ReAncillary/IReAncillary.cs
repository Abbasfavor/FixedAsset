using FixedAsset.Models.HelperModel;
using FixedAsset.Models.ReAncillary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FixedAsset.Repository.ReAncillary
{

 
    public interface IReAncillary : IDisposable
    {


        IEnumerable<ReAncillaryModel> GetACillaryCost();

        ReturnModel CraeteAnciCost(ReAncillaryModel model);

        ReturnModel UpdateAnciCost(ReAncillaryModel model);

        ReAncillaryModel GetAncillaryId(int Id);

        ReturnModel DeleteAnciCost(ReAncillaryModel model);



    }
}