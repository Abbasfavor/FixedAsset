using FixedAsset.Models;
using FixedAsset.Models.HelperModel;
using FixedAsset.Models.Setup.FAAncilaryClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FixedAsset.Repository.Setup
{
    public class FAAncilary_class : IFAAncilary_Class
    {
        private readonly FixedAssetEntities _entity = new FixedAssetEntities();

        public FAAncilary_class(FixedAssetEntities entity)
        {

            _entity = entity;
        }

        public ReturnModel setup_FAAncilryClass(FAAncilaryClassModel model)
        {

            var retVal = new ReturnModel();
            SqlParameter Retval3 = new SqlParameter("@retval", SqlDbType.Int);
            Retval3.Direction = System.Data.ParameterDirection.Output;

            SqlParameter RetMsg3 = new SqlParameter("@retmesg", SqlDbType.VarChar, 150);
            RetMsg3.Direction = System.Data.ParameterDirection.Output;
            try
            {
                var AppList = _entity.Database.ExecuteSqlCommand("Proc_FAAncillaryClass @classcode,@costcode" +
                    ",@userid,@authid,@retval output,@retmesg output",
                    new SqlParameter("@classcode", model.ClassCode),
                    new SqlParameter("@costcode", model.CostCode),
                    new SqlParameter("@userid", model.UserID),
                    new SqlParameter("@authid", model.AuthID),
                    Retval3, RetMsg3);

                retVal.retVal = Convert.ToInt32(Retval3.Value);
                retVal.retmsg = RetMsg3.Value.ToString();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return retVal;
        }

        public ReturnModel Up_FAAncilaryClass(FAAncilaryClassModel model)
        {

            var retVal = new ReturnModel();
            SqlParameter Retval3 = new SqlParameter("@retval", SqlDbType.Int);
            Retval3.Direction = System.Data.ParameterDirection.Output;

            SqlParameter RetMsg3 = new SqlParameter("@retmesg", SqlDbType.VarChar, 150);
            RetMsg3.Direction = System.Data.ParameterDirection.Output;
            try
            {
                var AppList = _entity.Database.ExecuteSqlCommand("Proc_UpFAAncillaryClass @Id, @classcode,@costcode,@userid," +
                    "@authid,@retval output,@retmesg output",
                    new SqlParameter("@Id", model.Id),
                    new SqlParameter("@classcode", model.ClassCode),
                    new SqlParameter("@costcode", model.CostCode),
                    new SqlParameter("@userid", model.UserID),
                    new SqlParameter("@authid", model.AuthID),
                    Retval3, RetMsg3);

                retVal.retVal = Convert.ToInt32(Retval3.Value);
                retVal.retmsg = RetMsg3.Value.ToString();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return retVal;
        }

        public ReturnModel Del_FAAncilaryClass(FAAncilaryClassModel model)
        {

            var retVal = new ReturnModel();
            SqlParameter Retval3 = new SqlParameter("@retval", SqlDbType.Int);
            Retval3.Direction = System.Data.ParameterDirection.Output;

            SqlParameter RetMsg3 = new SqlParameter("@retmesg", SqlDbType.VarChar, 150);
            RetMsg3.Direction = System.Data.ParameterDirection.Output;
            try
            {
                var AppList = _entity.Database.ExecuteSqlCommand("Proc_RemFAAncillaryClass @Id,@retval output,@retmesg output",
                    new SqlParameter("@Id", model.Id),
                    Retval3, RetMsg3);

                retVal.retVal = Convert.ToInt32(Retval3.Value);
                retVal.retmsg = RetMsg3.Value.ToString();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return retVal;
        }

        public IEnumerable<FAAncilaryClassModel> GetFAAncilaryClass()
        {
            var CatList = new List<FAAncilaryClassModel>();
            try
            {
                CatList = _entity.Database.SqlQuery<FAAncilaryClassModel>("Proc_GetAAncilaryClass").ToList();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return CatList;
        }
        public FAAncilaryClassModel GetAncilaryClassByClassCode(string classcode)
        {
            var CatList = new FAAncilaryClassModel();
            try
            {
                CatList = _entity.Database.SqlQuery<FAAncilaryClassModel>("Proc_GetAAncilaryClassBy_cclasscode @classcode",
                    new SqlParameter("@classcode", classcode)).FirstOrDefault();

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