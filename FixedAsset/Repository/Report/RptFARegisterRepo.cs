using FixedAsset.Models;
using FixedAsset.Models.Reports;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FixedAsset.Repository.Report
{
    public class RptFARegisterRepo : IRptFARegisterRepo
    {
        private readonly FixedAssetEntities _entity = new FixedAssetEntities();

        public RptFARegisterRepo(FixedAssetEntities entity)
        {
            _entity = entity;

        }
        public IEnumerable<Models.Reports.RptFARegister> GetFARegister(string Branchcode, string FAClass)
        {
            var CatList = new List<Models.Reports.RptFARegister>();
            try
            {
                CatList = _entity.Database.SqlQuery<RptFARegister>("proc_rptFARegister @Branchcode,@FAClass",
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