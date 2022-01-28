using FixedAsset.Models;
using FixedAsset.Models.HelperModel;
using FixedAsset.Models.Setup;
using FixedAsset.Models.Setup.FACategory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FixedAsset.Repository.Setup
{
    public class Asset_Category : IAsset_Category
    {

        private readonly FixedAssetEntities _entity = new FixedAssetEntities();

        public Asset_Category(FixedAssetEntities entity)
        {

            _entity = entity;
        }

        public ReturnModel setup_FACategory(Asset_Categorym model) {
   
            var retVal = new ReturnModel();
            SqlParameter Retval3 = new SqlParameter("@retval", SqlDbType.Int);
            Retval3.Direction = System.Data.ParameterDirection.Output;

            SqlParameter RetMsg3 = new SqlParameter("@retmesg", SqlDbType.VarChar, 150);
            RetMsg3.Direction = System.Data.ParameterDirection.Output;
            try {
                var AppList = _entity.Database.ExecuteSqlCommand("Proc_InsFACategory @CatCode,@CatDesc,@userid,@authid,@retval output,@retmesg output",
                    new SqlParameter("@CatCode", model.CatCode),
                    new SqlParameter("@CatDesc", model.CatDesc),
                    new SqlParameter("@userid", model.UserID),
                    new SqlParameter("@authid", model.AuthID),
                    Retval3, RetMsg3);

                retVal.retVal = Convert.ToInt32(Retval3.Value);
                retVal.retmsg = RetMsg3.Value.ToString();

            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            return retVal;
        }

        public ReturnModel Up_FACategory(Asset_Categorym model)
        {

            var retVal = new ReturnModel();
            SqlParameter Retval3 = new SqlParameter("@retval", SqlDbType.Int);
            Retval3.Direction = System.Data.ParameterDirection.Output;

            SqlParameter RetMsg3 = new SqlParameter("@retmesg", SqlDbType.VarChar, 150);
            RetMsg3.Direction = System.Data.ParameterDirection.Output;
            try
            {
                var AppList = _entity.Database.ExecuteSqlCommand("Proc_UpFACategory @Id @CatCode,@CatDesc,@userid,@authid,@retval output,@retmesg output",
                    new SqlParameter("@Id", model.Id),
                    new SqlParameter("@CatCode", model.CatCode),
                    new SqlParameter("@CatDesc", model.CatDesc),
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

        public ReturnModel Del_FACategory(Asset_Categorym model)
        {

            var retVal = new ReturnModel();
            SqlParameter Retval3 = new SqlParameter("@retval", SqlDbType.Int);
            Retval3.Direction = System.Data.ParameterDirection.Output;

            SqlParameter RetMsg3 = new SqlParameter("@retmesg", SqlDbType.VarChar, 150);
            RetMsg3.Direction = System.Data.ParameterDirection.Output;
            try
            {
                var AppList = _entity.Database.ExecuteSqlCommand("Proc_RemFACategory @Id,@retval output,@retmesg output",
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

        public IEnumerable<Asset_Categorym> GetCategory()
        {
            var CatList = new List<Asset_Categorym>();
            try
            {
                CatList = _entity.Database.SqlQuery<Asset_Categorym>("Proc_GetCategory").ToList();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return CatList;
        }
        public Asset_Categorym GetCategoryById(string catcode)
        {
            var CatList = new Asset_Categorym();
            try
            {
                CatList = _entity.Database.SqlQuery<Asset_Categorym>("Proc_GetCategoryByID @catcode",
                    new SqlParameter("@catcode", catcode)).FirstOrDefault();

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