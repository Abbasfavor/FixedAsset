using FixedAsset.Models;
using FixedAsset.Models.Reports;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FixedAsset.Repository.Report
{
    public class RptFAWrittenOffRepo : IRptFAWrittenOffRepo
    {
        private readonly FixedAssetEntities _entity = new FixedAssetEntities();

        public RptFAWrittenOffRepo(FixedAssetEntities entity)
        {
            _entity = entity;

        }

        public IEnumerable<RptFAWrittenOff> GetFAFAWrittenOff(string Branchcode, string FAClass, DateTime startdate, DateTime eddate)
        {
            var CatList = new List<RptFAWrittenOff>();
            try
            {
                CatList = _entity.Database.SqlQuery<RptFAWrittenOff>("proc_rptFADisposed  @Branchcode,@FAClass @startdate @eddate",
                   new SqlParameter("@startdate", startdate),
                   new SqlParameter("@eddate", eddate),
                   new SqlParameter("@Branchcode", Branchcode),
                   new SqlParameter("@FAClass", FAClass)).ToList();

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
