using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRMDesktopUI.Library.Helpers
{
    public class ConfigHelper : IConfigHelper
    {
        public decimal GetTaxRate()
        {
            var value = ConfigurationManager.AppSettings["taxRate"];

            if (decimal.TryParse(value, out var rate))
                return rate / 100;

            throw new ConfigurationErrorsException("Tax rate not set properly");
        }
    }
}
