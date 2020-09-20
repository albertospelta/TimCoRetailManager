using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using TRMDataManager.Library.DataAccess;
using TRMDataManager.Library.Model;

namespace TRMDataManager.Controllers
{
    [Authorize]
    public class UserController : ApiController
    {
        public List<UserModel> GetById()
        {
            var data = new UserData();
            var userId = RequestContext.Principal.Identity.GetUserId();
            return data.GetUserById(userId);
        }
    }
}
