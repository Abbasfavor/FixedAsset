using FixedAsset.Models;
using FixedAsset.Models.HelperModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FixedAsset.Repository.Maintenance
{
    public class Maintenance : IMaintenance
    {
        private readonly FixedAssetEntities _entity = new FixedAssetEntities();

        public Maintenance(FixedAssetEntities entity)
        {
            _entity = entity;

        }

        public IEnumerable<AmortiseSet> Get_AmortiseType()
        {
            var CatList = new List<AmortiseSet>();
            try
            {
                CatList = _entity.Database.SqlQuery<AmortiseSet>("GetAmortiseype").ToList();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return CatList;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}