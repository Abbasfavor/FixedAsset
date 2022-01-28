using FixedAsset.Models;
using FixedAsset.Models.HelperModel;
using FixedAsset.Models.Setup.Role;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FixedAsset.Repository.Setup
{
    public class Role : IRole
    {
        private readonly FixedAssetEntities _entity = new FixedAssetEntities();

        public Role(FixedAssetEntities entity)
        {

            _entity = entity;
        }

        public ReturnModel setup_Role(RoleModel model)
        {

            var retVal = new ReturnModel();
            SqlParameter Retval3 = new SqlParameter("@retval", SqlDbType.Int);
            Retval3.Direction = System.Data.ParameterDirection.Output;

            SqlParameter RetMsg3 = new SqlParameter("@retmesg", SqlDbType.VarChar, 150);
            RetMsg3.Direction = System.Data.ParameterDirection.Output;
            try
            {
                var AppList = _entity.Database.ExecuteSqlCommand("InsRole @rolename,@roleDesc,@isoperation,@roleLevel,@canAuth," +
                    "@userid,@authid,@retval output,@retmesg output",
                    new SqlParameter("@rolename", model.role_name),
                    new SqlParameter("@roleDesc", model.roledesc),
                    new SqlParameter("@isoperation", model.isoperation),
                    new SqlParameter("@roleLevel", model.role_level),
                    new SqlParameter("@canAuth", model.canauth),
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

        public ReturnModel Up_Role(RoleModel model)
        {
            if (model.access_days == null) {
                model.access_days = 0;
            }
            if (model.reqLimit == null)
            {
                model.reqLimit = 0;
            }
            if (model.Commitee == null)
            {
                model.Commitee = false;
            }
            //if (model.access_days == null)
            //{
            //    model.access_days = 0;
            //}
            var retVal = new ReturnModel();
            SqlParameter Retval3 = new SqlParameter("@retval", SqlDbType.Int);
            Retval3.Direction = System.Data.ParameterDirection.Output;

            SqlParameter RetMsg3 = new SqlParameter("@retmesg", SqlDbType.VarChar, 150);
            RetMsg3.Direction = System.Data.ParameterDirection.Output;
            try
            {
                var AppList = _entity.Database.ExecuteSqlCommand("Proc_UpRole @Id, @rolename,@roleDesc,@accessdays,@isoperation,@requelimit,@roleLevel,@canAuth,@committee," +
                    "@userid,@authid,@retval output,@retmesg output",
                    new SqlParameter("@Id", model.role_id),
                    new SqlParameter("@rolename", model.role_name),
                    new SqlParameter("@roleDesc", model.roledesc),
                    new SqlParameter("@accessdays", model.access_days),
                    new SqlParameter("@isoperation", model.isoperation),
                    new SqlParameter("@requelimit", model.reqLimit),
                    new SqlParameter("@roleLevel", model.role_level),
                    new SqlParameter("@canAuth", model.canauth),
                    new SqlParameter("@committee", model.Commitee),
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



        public IEnumerable<RoleModel> GetRole()
        {
            var CatList = new List<RoleModel>();
            try
            {
                CatList = _entity.Database.SqlQuery<RoleModel>("Proc_GetRole").ToList();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return CatList;
        }
        
        public RoleModel GetRoleByID(int? Id)
        {
            var CatList = new RoleModel();
            try
            {
                CatList = _entity.Database.SqlQuery<RoleModel>("Proc_getRoleByID @Id",
                    new SqlParameter("@Id", Id)).FirstOrDefault();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return CatList;
        }
        public ReturnModel DeleteRole(RoleModel model)
        {
            var retVal = new ReturnModel();
            SqlParameter Retval3 = new SqlParameter("@retval", SqlDbType.Int);
            Retval3.Direction = System.Data.ParameterDirection.Output;

            SqlParameter RetMsg3 = new SqlParameter("@retmesg", SqlDbType.VarChar, 150);
            RetMsg3.Direction = System.Data.ParameterDirection.Output;
            try
            {
                var datat = _entity.Database.ExecuteSqlCommand("Proc_DeleteRole @Id,"+
                     "@userid,@authid,@retval output,@retmesg output",
                    new SqlParameter("@Id", model.role_id),
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