using FixedAsset.Models;
using FixedAsset.Models.HelperModel;
using FixedAsset.Models.User;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FixedAsset.Repository.User
{
    public class UserRepo : IUserRepo
    {
        private readonly FixedAssetEntities _entity = new FixedAssetEntities();

        public UserRepo(FixedAssetEntities entity)
        {
            _entity = entity;

        }

        public ReturnModel InsUser(UserModel model)
        {
            if(model.firstname!=null && model.lastname!=null || model.othername == null)
            {
                model.fullname = model.lastname + " " + model.firstname + " " + model.othername;
            }
            var retVal = new ReturnModel();
            SqlParameter Retval3 = new SqlParameter("@retval", SqlDbType.Int);
            Retval3.Direction = System.Data.ParameterDirection.Output;

            SqlParameter RetMsg3 = new SqlParameter("@retmesg", SqlDbType.VarChar, 150);
            RetMsg3.Direction = System.Data.ParameterDirection.Output;
            try
            {
                var AppList = _entity.Database.ExecuteSqlCommand("Proc_InsUser @userId,@fullname,@firstname,@lastname,@othername,@email,@phone,@password,@authorizer,@depcode,@branch,@role_id," +
                    "@authid,@retval output,@retmesg output",
                    new SqlParameter("@userId", model.Userid),
                    new SqlParameter("@fullname", model.fullname),
                    new SqlParameter("@firstname", model.firstname),
                    new SqlParameter("@lastname", model.lastname),
                    new SqlParameter("@othername", model.othername),
                    new SqlParameter("@email", model.email),
                    new SqlParameter("@phone", model.phoneno),
                    new SqlParameter("@password", model.userpassword),
                    new SqlParameter("@authorizer", model.Authoriser),
                    new SqlParameter("@depcode", model.deptcode),
                    new SqlParameter("@branch", model.branchcode),
                    new SqlParameter("@role_id", model.Role_id),
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

        public ReturnModel Up_User(UserModel model)
        {
            if (model.firstname != null && model.lastname != null || model.othername == null)
            {
                model.fullname = model.lastname + " " + model.firstname + " " + model.othername;
            }
            if (model.othername == null)
            {
                model.othername = "";
            }
            var retVal = new ReturnModel();
            SqlParameter Retval3 = new SqlParameter("@retval", SqlDbType.Int);
            Retval3.Direction = System.Data.ParameterDirection.Output;

            SqlParameter RetMsg3 = new SqlParameter("@retmesg", SqlDbType.VarChar, 150);
            RetMsg3.Direction = System.Data.ParameterDirection.Output;
            try
            {
                var AppList = _entity.Database.ExecuteSqlCommand("Proc_UpUser @userId, @fullname,@firstname,@lastname,@othername,@email,@phone,@authorizer,@depcode,@branch,@role_id," +
                      "@authid,@retval output,@retmesg output",
                      new SqlParameter("@userId", model.Userid),
                    new SqlParameter("@fullname", model.fullname),
                    new SqlParameter("@firstname", model.firstname),
                    new SqlParameter("@lastname", model.lastname),
                    new SqlParameter("@othername", model.othername),
                    new SqlParameter("@email", model.email),
                    new SqlParameter("@phone", model.phoneno),
                    new SqlParameter("@authorizer", model.Authoriser),
                    new SqlParameter("@depcode", model.deptcode),
                    new SqlParameter("@branch", model.branchcode),
                    new SqlParameter("@role_id", model.Role_id),
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

        public ReturnModel DeactivateUser(UserModel model)
        {

            var retVal = new ReturnModel();
            SqlParameter Retval3 = new SqlParameter("@retval", SqlDbType.Int);
            Retval3.Direction = System.Data.ParameterDirection.Output;

            SqlParameter RetMsg3 = new SqlParameter("@retmesg", SqlDbType.VarChar, 150);
            RetMsg3.Direction = System.Data.ParameterDirection.Output;
            try
            {
                var AppList = _entity.Database.ExecuteSqlCommand("Proc_DeActivateUser @userId,@authId, @flag,@retval output,@retmesg output",
                    new SqlParameter("@userId", model.Userid),
                    new SqlParameter("@authId", model.authid),
                    new SqlParameter("@flag", 0),
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

        public IEnumerable<UserModel> Get_Users()
        {
            var CatList = new List<UserModel>();
            try
            {
                CatList = _entity.Database.SqlQuery<UserModel>("Proc_getUsers").ToList();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return CatList;
        }
        public UserModel GetUserByID(string Userid)
        {
            var CatList = new UserModel();
            try
            {
                CatList = _entity.Database.SqlQuery<UserModel>("Proc_GetUserByUserId @userId",
                    new SqlParameter("@userId", Userid)).FirstOrDefault();

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