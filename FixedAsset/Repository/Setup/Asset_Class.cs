using FixedAsset.Models;
using FixedAsset.Models.HelperModel;
using FixedAsset.Models.Setup.FAClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FixedAsset.Repository.Setup
{
    public class Asset_Class : IAsset_Class
    {

        private readonly FixedAssetEntities _entity = new FixedAssetEntities();

        public Asset_Class(FixedAssetEntities entity)
        {

            _entity = entity;
        }

        public ReturnModel setup_FAClass(FAClassModel model)
        {

            var retVal = new ReturnModel();
            SqlParameter Retval3 = new SqlParameter("@retval", SqlDbType.Int);
            Retval3.Direction = System.Data.ParameterDirection.Output;

            SqlParameter RetMsg3 = new SqlParameter("@retmesg", SqlDbType.VarChar, 150);
            RetMsg3.Direction = System.Data.ParameterDirection.Output;
            try
            {
                var AppList = _entity.Database.ExecuteSqlCommand("Proc_InsFAClass @Catcode,@classcode,@classname,@depMethod,@depRate,@lifespan" +
                    ",@userid,@authid,@retval output,@retmesg output",
                    new SqlParameter("@Catcode", model.CatCode),
                    new SqlParameter("@classcode", model.ClassCode),
                    new SqlParameter("@classname", model.ClassName),
                    new SqlParameter("@depMethod", model.DepMethod),
                    new SqlParameter("@depRate", model.DepRate),
                    new SqlParameter("@lifespan", model.LifeSpan),
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

        public ReturnModel Up_FAClass(FAClassModel model)
        {

            var retVal = new ReturnModel();
            SqlParameter Retval3 = new SqlParameter("@retval", SqlDbType.Int);
            Retval3.Direction = System.Data.ParameterDirection.Output;

            SqlParameter RetMsg3 = new SqlParameter("@retmesg", SqlDbType.VarChar, 150);
            RetMsg3.Direction = System.Data.ParameterDirection.Output;
            try
            {
                var AppList = _entity.Database.ExecuteSqlCommand("Proc_UpFAclass @CatCode,@classcode,@classname,@depMethod,@depRate,@lifespan,@userid," +
                    "@authid,@retval output,@retmesg output",
                    new SqlParameter("@CatCode", model.CatCode),
                    new SqlParameter("@classcode", model.ClassCode),
                    new SqlParameter("@classname", model.ClassName),
                    new SqlParameter("@depMethod", model.DepMethod),
                    new SqlParameter("@depRate", model.DepRate),
                    new SqlParameter("@lifespan", model.LifeSpan),
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

        public ReturnModel Del_FAClass(FAClassModel model)
        {

            var retVal = new ReturnModel();
            SqlParameter Retval3 = new SqlParameter("@retval", SqlDbType.Int);
            Retval3.Direction = System.Data.ParameterDirection.Output;

            SqlParameter RetMsg3 = new SqlParameter("@retmesg", SqlDbType.VarChar, 150);
            RetMsg3.Direction = System.Data.ParameterDirection.Output;
            try
            {
                var AppList = _entity.Database.ExecuteSqlCommand("Proc_RemFAClass @classcode,@userid,@authid,@retval output,@retmesg output",
                    new SqlParameter("@classcode", model.ClassCode),
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

        public IEnumerable<FAClassModel> GetFAClass()
        {
            var CatList = new List<FAClassModel>();
            try
            {
                CatList = _entity.Database.SqlQuery<FAClassModel>("Proc_GetFAClass").ToList();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return CatList;
        }
        public FAClassModel GetClassByClassCode(string classcode)
        {
            var CatList = new FAClassModel();
            try
            {
                CatList = _entity.Database.SqlQuery<FAClassModel>("Proc_GetFAClassByClassCode @classcode",
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