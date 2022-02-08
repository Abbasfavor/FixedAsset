using FixedAsset.Models.maintenance;
using FixedAsset.Repository.Maintenance;
using FixedAsset.Models.HelperModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FixedAsset.Models;
using System.Data.SqlClient;
using System.Data;

namespace FixedAsset.Repository.Maintenance
{
    public class Maintenance : IMaintenance
    {
        private readonly FixedAssetEntities _db = new FixedAssetEntities();

        public Maintenance(FixedAssetEntities db)
        {
            _db = db;

        }

        public IEnumerable<AmortiseSet> Get_AmortiseType()
        {
            var CatList = new List<AmortiseSet>();
            try
            {
                CatList = _db.Database.SqlQuery<AmortiseSet>("GetAmortiseype").ToList();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return CatList;
        }

        public IEnumerable<maintenance> GetMaintances()
        {
            var CatList = new List<maintenance>();
            try
            {
                CatList = _db.Database.SqlQuery<maintenance>("Proc_GetMaintainRecord").ToList();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return CatList;
        }





        public ReturnModel CraeteMaintances(maintenance model)
        {

            var retVal = new ReturnModel();
            SqlParameter Retval3 = new SqlParameter("@retval", SqlDbType.Int);
            Retval3.Direction = System.Data.ParameterDirection.Output;

            SqlParameter RetMsg3 = new SqlParameter("@retmesg", SqlDbType.VarChar, 150);
            RetMsg3.Direction = System.Data.ParameterDirection.Output;
            try
            {
                var AppList = _db.Database.ExecuteSqlCommand("Proc_InsMaintainenace @OperaType, @FACode,@Description,@MaintDate,@NextMaintDate,@Amount,@Capitalisetype,@DRGL,@CRGL," +
               "@userid,@authid,@retval output,@retmesg output",
               new SqlParameter("@OperaType", model.OperaType),
               new SqlParameter("@FACode", model.FACode),
                new SqlParameter("@Description", model.Description),
               new SqlParameter("@MaintDate", model.MaintDate),
               new SqlParameter("@NextMaintDate", model.NextMaintDate),
               new SqlParameter("@Amount", model.Amount),
               new SqlParameter("@Capitalisetype", model.CapitaliseTpe),
               new SqlParameter("@DRGL", model.DRAccount),
               new SqlParameter("@CRGL", model.CRAccount),
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







        public ReturnModel UpdateMaintances(maintenance model)
        {

            var retVal = new ReturnModel();
            SqlParameter Retval3 = new SqlParameter("@retval", SqlDbType.Int);
            Retval3.Direction = System.Data.ParameterDirection.Output;

            SqlParameter RetMsg3 = new SqlParameter("@retmesg", SqlDbType.VarChar, 150);
            RetMsg3.Direction = System.Data.ParameterDirection.Output;
            try
            {
                var AppList = _db.Database.ExecuteSqlCommand("Proc_UpdateMaintainenace @Id, @OperaType, @FACode,@Description,@MaintDate,@NextMaintDate,@Amount,@Capitalisetype,@DRGL,@CRGL," +
               "@userid,@authid,@retval output,@retmesg output",
               new SqlParameter("@Id", model.Id),
               new SqlParameter("@OperaType", model.OperaType),
               new SqlParameter("@FACode", model.FACode),
               new SqlParameter("@Description", model.Description),
               new SqlParameter("@MaintDate", model.MaintDate),
               new SqlParameter("@NextMaintDate", model.NextMaintDate),
               new SqlParameter("@Amount", model.Amount),
               new SqlParameter("@Capitalisetype", model.CapitaliseTpe),
               new SqlParameter("@DRGL", model.DRAccount),
               new SqlParameter("@CRGL", model.CRAccount),
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




        public maintenance GetMaintainId(int Id)
        {
            var CatList = new maintenance();
            try
            {
                CatList = _db.Database.SqlQuery<maintenance>("Proc_GetMantainId @Id",
                    new SqlParameter("@Id", Id)).FirstOrDefault();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return CatList;
        }





        public ReturnModel DeleteMaintain(maintenance model)
        {
            var retVal = new ReturnModel();
            SqlParameter Retval3 = new SqlParameter("@retval", SqlDbType.Int);
            Retval3.Direction = System.Data.ParameterDirection.Output;

            SqlParameter RetMsg3 = new SqlParameter("@retmesg", SqlDbType.VarChar, 150);
            RetMsg3.Direction = System.Data.ParameterDirection.Output;
            try
            {
                var datat = _db.Database.ExecuteSqlCommand("Proc_DeleteMaintain @Id," +
                "@userid,@authid,@retval output,@retmesg output",
                 new SqlParameter("@Id", model.Id),
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


        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}