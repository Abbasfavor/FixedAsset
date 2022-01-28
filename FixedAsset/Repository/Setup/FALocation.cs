using FixedAsset.Models;
using FixedAsset.Models.FALocation;
using FixedAsset.Models.HelperModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FixedAsset.Repository.Setup
{
    public class FALocation:IFALocation
    {
        private readonly FixedAssetEntities _entity = new FixedAssetEntities();

        public FALocation(FixedAssetEntities entity)
        {

            _entity = entity;
        }

        public ReturnModel setup_Location(FALocationModel model)
        {

            var retVal = new ReturnModel();
            SqlParameter Retval3 = new SqlParameter("@retval", SqlDbType.Int);
            Retval3.Direction = System.Data.ParameterDirection.Output;

            SqlParameter RetMsg3 = new SqlParameter("@retmesg", SqlDbType.VarChar, 150);
            RetMsg3.Direction = System.Data.ParameterDirection.Output;
            try
            {
                var AppList = _entity.Database.ExecuteSqlCommand("Proc_InsFALocation @FACode,@FALocationCode,@ReceiptStatus," +
                    ",@UserId,@AuthId,@ReceiptBy,@AssetGL,@AccumeDepGL,@DepExpenseGL,@retval output,@retmesg output",
                    new SqlParameter("@FACode", model.FACode),
                    new SqlParameter("@FALocationCode", model.FALocationCode),
                    new SqlParameter("@ReceiptStatus", model.ReceiptStatus),
                    new SqlParameter("@UserId", model.UserID),
                    new SqlParameter("@AuthId", model.AuthID),
                    new SqlParameter("@ReceiptBy", model.ReceiptBy),
                    new SqlParameter("@AssetGL", model.AssetGL),
                    new SqlParameter("@AccumeDepGL", model.AccumDepGL),
                    new SqlParameter("@DepExpenseGL", model.DepExpenseGL),
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

        public ReturnModel Up_FAlocation(FALocationModel model)
        {

            var retVal = new ReturnModel();
            SqlParameter Retval3 = new SqlParameter("@retval", SqlDbType.Int);
            Retval3.Direction = System.Data.ParameterDirection.Output;

            SqlParameter RetMsg3 = new SqlParameter("@retmesg", SqlDbType.VarChar, 150);
            RetMsg3.Direction = System.Data.ParameterDirection.Output;
            try
            {
                var AppList = _entity.Database.ExecuteSqlCommand("Proc_UpFALocation @Id, @FACode,@FALocationCode,@ReceiptStatus,@UserId,@AuthId,@ReceiptBy" +
                    ",@AssetGL,@AccumeDepGL,@DepExpenseGL," +
                    "@retval output,@retmesg output",
                    new SqlParameter("@Id", model.Id),
                    new SqlParameter("@FACode", model.FACode),
                    new SqlParameter("@FALocationCode", model.FALocationCode),
                    new SqlParameter("@ReceiptStatus", model.ReceiptStatus),
                    new SqlParameter("@UserId", model.UserID),
                    new SqlParameter("@AuthId", model.AuthID),
                    new SqlParameter("@ReceiptBy", model.ReceiptBy),
                    new SqlParameter("@AssetGL", model.UserID),
                    new SqlParameter("@AccumeDepGL", model.AuthID),
                    new SqlParameter("@DepExpenseGL", model.AuthID),
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

        public ReturnModel Del_FALocation(FALocationModel model)
        {

            var retVal = new ReturnModel();
            SqlParameter Retval3 = new SqlParameter("@retval", SqlDbType.Int);
            Retval3.Direction = System.Data.ParameterDirection.Output;

            SqlParameter RetMsg3 = new SqlParameter("@retmesg", SqlDbType.VarChar, 150);
            RetMsg3.Direction = System.Data.ParameterDirection.Output;
            try
            {
                var AppList = _entity.Database.ExecuteSqlCommand("Proc_RemFAllocation @Id,@retval output,@retmesg output",
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

        public IEnumerable<FALocationModel> GetFALocation()
        {
            var CatList = new List<FALocationModel>();
            try
            {
                CatList = _entity.Database.SqlQuery<FALocationModel>("Proc_GetFAAllocation").ToList();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return CatList;
        }
        public FALocationModel GetClassByClassCode(string locationCode)
        {
            var CatList = new FALocationModel();
            try
            {
                CatList = _entity.Database.SqlQuery<FALocationModel>("Proc_GetFAAllocationByFAAllocationCode @FALocationCode",
                    new SqlParameter("@FALocationCode", locationCode)).FirstOrDefault();

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