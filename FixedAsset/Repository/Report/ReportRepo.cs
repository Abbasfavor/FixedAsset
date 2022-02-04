using FixedAsset.Models;
using FixedAsset.Models.Reports;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FixedAsset.Repository.Report
{
    public class ReportRepo : IReportRepo
    {
        private readonly FixedAssetEntities _entity = new FixedAssetEntities();

        public ReportRepo(FixedAssetEntities entity)
        {
            _entity = entity;

        }
        public IEnumerable<RptFARegister> GetFARegister(string Branchcode, string FAClass)
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
        public IEnumerable<RptFADisposed> GetFADisposed(string Branchcode, string FAClass, DateTime startdate, DateTime eddate)
        {
            var CatList = new List<RptFADisposed>();
            try
            {
                CatList = _entity.Database.SqlQuery<RptFADisposed>("proc_rptFADisposed  @Branchcode,@FAClass @startdate @eddate",
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
        public IEnumerable<RptFAWrittenOff> GetFAWrittenOff(string Branchcode, string FAClass, DateTime startdate, DateTime eddate)
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
        public IEnumerable<RptFAMaint_Repairs> GetFAMaint_Repairs()
        {
            var CatList = new List<RptFAMaint_Repairs>();
            try
            {
                CatList = _entity.Database.SqlQuery<RptFAMaint_Repairs>("proc_rptMaint_Repairs").ToList();



            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return CatList;
        }

        public IEnumerable<RptMaintRepairByCode> GetFAMaintRepairByCode(string FaCode, int retportType)
        {
            var CatList = new List<RptMaintRepairByCode>();
            try
            {
                CatList = _entity.Database.SqlQuery<RptMaintRepairByCode>("proc_rptMaintRepairByCode @FaCode,@retportType",
                    new SqlParameter("@Branchcode", FaCode),
                    new SqlParameter("@FAClass", retportType)).ToList();

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