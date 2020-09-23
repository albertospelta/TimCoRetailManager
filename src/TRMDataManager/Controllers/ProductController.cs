using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TRMDataManager.Library.DataAccess;
using TRMDataManager.Library.Model;

namespace TRMDataManager.Controllers
{
    [Authorize]
    public class ProductController : ApiController
    {
        public IEnumerable<ProductModel> Get()
        {
            var data = new ProductData();
            var products = data.GetProducts();
            return products;
        }
    }
}
