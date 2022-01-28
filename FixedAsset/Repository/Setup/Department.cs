using FixedAsset.Models;
using FixedAsset.Models.HelperModel;
using FixedAsset.Models.Setup.Branch;
using FixedAsset.Models.Setup.Department;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FixedAsset.Repository.Setup
{
    public class Department : IDepartment
    {

        private readonly FixedAssetEntities _entity = new FixedAssetEntities();

        public Department(FixedAssetEntities entity)
        {

            _entity = entity;
        }

        public ReturnModel setup_Department(DepartModel model)
        {

            var retVal = new ReturnModel();
            SqlParameter Retval3 = new SqlParameter("@retval", SqlDbType.Int);
            Retval3.Direction = System.Data.ParameterDirection.Output;

            SqlParameter RetMsg3 = new SqlParameter("@retmesg", SqlDbType.VarChar, 150);
            RetMsg3.Direction = System.Data.ParameterDirection.Output;
            try
            {
                var AppList = _entity.Database.ExecuteSqlCommand("Proc_InsDepartment @DeptId,@Deptname,@DeptShortName," +
                    "@userid,@authid,@retval output,@retmesg output",
                    new SqlParameter("@DeptId", model.Deptid),
                    new SqlParameter("@Deptname", model.DeptName),
                    new SqlParameter("@DeptShortName", model.DeptShortname),
                    new SqlParameter("@userid", model.userid),
                    new SqlParameter("@authid", model.authid),
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

        public ReturnModel Up_Department(DepartModel model)
        {

            var retVal = new ReturnModel();
            SqlParameter Retval3 = new SqlParameter("@retval", SqlDbType.Int);
            Retval3.Direction = System.Data.ParameterDirection.Output;

            SqlParameter RetMsg3 = new SqlParameter("@retmesg", SqlDbType.VarChar, 150);
            RetMsg3.Direction = System.Data.ParameterDirection.Output;
            try
            {
                var AppList = _entity.Database.ExecuteSqlCommand("Proc_UpDepartment @DeptId,@Deptname,@DeptShortName," +
                    "@userid,@authid,@retval output,@retmesg output",

                    new SqlParameter("@DeptId", model.Deptid),
                    new SqlParameter("@Deptname", model.DeptName),
                    new SqlParameter("@DeptShortName", model.DeptShortname),
                    new SqlParameter("@userid", model.userid),
                    new SqlParameter("@authid", model.authid),
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

        

        public IEnumerable<DepartModel> GetDepartment()
        {
            var CatList = new List<DepartModel>();
            try
            {
                CatList = _entity.Database.SqlQuery<DepartModel>("Proc_GetDepartmnet").ToList();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return CatList;
        }
        public DepartModel GetDeprtByCode(string DeptCode)
        {
            var CatList = new DepartModel();
            try
            {
                CatList = _entity.Database.SqlQuery<DepartModel>("Proc_GetDepartByCode @DeptId",
                    new SqlParameter("@DeptId", DeptCode)).FirstOrDefault();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return CatList;
        }

        public ReturnModel DeleteDepartment(DepartModel model)
        {
            var retVal = new ReturnModel();
            SqlParameter Retval3 = new SqlParameter("@retval", SqlDbType.Int);
            Retval3.Direction = System.Data.ParameterDirection.Output;

            SqlParameter RetMsg3 = new SqlParameter("@retmesg", SqlDbType.VarChar, 150);
            RetMsg3.Direction = System.Data.ParameterDirection.Output;
            try
            {
                var datat = _entity.Database.ExecuteSqlCommand("Proc_DeleteDepartment @DeptId," +
                     "@userid,@authid,@retval output,@retmesg output",
                    new SqlParameter("@DeptId", model.Deptid),
                    new SqlParameter("@userid", model.userid),
                    new SqlParameter("@authid", model.authid),
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