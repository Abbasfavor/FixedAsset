using FixedAsset.Models.HelperModel;
using FixedAsset.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixedAsset.Repository.User
{
 public   interface IUserRepo:IDisposable
    {
        ReturnModel InsUser(UserModel model);
        ReturnModel Up_User(UserModel model);
        ReturnModel DeactivateUser(UserModel model);
        IEnumerable<UserModel> Get_Users();
        UserModel GetUserByID(string Userid);
    }
}
