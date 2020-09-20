using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRMDataManager.Library.Internal.DataAccess;
using TRMDataManager.Library.Model;

namespace TRMDataManager.Library.DataAccess
{
    public class UserData
    {
        public List<UserModel> GetUserById(string id)
        {
            var sql = new SqlDataAccess();

            var parameters = new
            {
                Id = id
            };

            var users = sql.LoadData<UserModel, dynamic>("dbo.spUserLookup", parameters, "TRMData");

            return users;
        }
    }
}
