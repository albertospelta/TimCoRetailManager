using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TRMDesktopUI.Library.Models;

namespace TRMDesktopUI.Library.Api
{
    public class ProductEndpoint : IProductEndpoint
    {
        private readonly IApiHelper _apiHelper;

        public ProductEndpoint(IApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public async Task<IList<ProductModel>> GetAll()
        {
            using (var response = await _apiHelper.ApiClient.GetAsync("api/Product"))
            {
                if (response.IsSuccessStatusCode == false)
                    throw new Exception(response.ReasonPhrase);

                var products = await response.Content.ReadAsAsync<IList<ProductModel>>();
                return products;
            }
        }
    }
}
