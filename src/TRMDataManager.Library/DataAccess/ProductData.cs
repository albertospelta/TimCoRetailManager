using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRMDataManager.Library.Internal.DataAccess;
using TRMDataManager.Library.Model;

namespace TRMDataManager.Library.DataAccess
{
    public class ProductData
    {
        public List<ProductModel> GetProducts()
        {
            var sql = new SqlDataAccess();

            var parameters = new
            {
            };

            var products = sql.LoadData<ProductModel, dynamic>("dbo.spProductGetAll", parameters, "TRMData");

            return products;
        }
    }
}
