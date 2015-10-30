using System.Collections.Generic;
using System.Linq;
using System.Web.Configuration;

namespace GuitarApi.handlers
{
    public class CorsOptions
    {
        public CorsOptions()
        {
            SetAllowedOrigins();
        }

        public virtual IEnumerable<string> AllowedOrigins { get; private set; }

        private void SetAllowedOrigins()
        {
            string appSettingValue = WebConfigurationManager.AppSettings["AllowedCORSOriginsCommaSeperated"];

            var origins = new List<string>();

            if (!string.IsNullOrEmpty(appSettingValue))
            {
                var originsSplit = appSettingValue.ToLower().Split(',');

                origins.AddRange(originsSplit.Select(s => s.Trim()));
            }

            AllowedOrigins = origins;
        }
    }
}
