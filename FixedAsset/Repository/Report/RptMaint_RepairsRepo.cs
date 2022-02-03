using FixedAsset.Models;
using FixedAsset.Models.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FixedAsset.Repository.Report
{
    public class RptMaint_RepairsRepo : IRptMaint_RepairsRepo
    {
        private readonly FixedAssetEntities _entity = new FixedAssetEntities();

        public RptMaint_RepairsRepo(FixedAssetEntities entity)
        {
            _entity = entity;

        }

        public IEnumerable<RptMaint_Repairs> GetMaint_Repairs()
        {
            var CatList = new List<RptMaint_Repairs>();
            try
            {
                CatList = _entity.Database.SqlQuery<RptMaint_Repairs>("proc_rptMaint_Repairs").ToList();



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
#pragma warning disable CS0162 // Unreachable code detected
            _entity.Dispose();
#pragma warning restore CS0162 // Unreachable code detected
        }



    }
}