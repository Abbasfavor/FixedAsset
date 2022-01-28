using FixedAsset.Models.HelperModel;
using FixedAsset.Models.Setup.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixedAsset.Repository.Setup
{
  public  interface IRole:IDisposable
    {
        ReturnModel setup_Role(RoleModel model);
        ReturnModel Up_Role(RoleModel model);
        IEnumerable<RoleModel> GetRole();
        RoleModel GetRoleByID(int? Id);
        ReturnModel DeleteRole(RoleModel model);
    }
}
