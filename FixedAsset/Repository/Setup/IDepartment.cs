using FixedAsset.Models.HelperModel;
using FixedAsset.Models.Setup.Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixedAsset.Repository.Setup
{
   public interface IDepartment:IDisposable
    {
        ReturnModel setup_Department(DepartModel model);
        ReturnModel Up_Department(DepartModel model);
        IEnumerable<DepartModel> GetDepartment();
        DepartModel GetDeprtByCode(string DeptCode);
        ReturnModel DeleteDepartment(DepartModel model);

    }
}
