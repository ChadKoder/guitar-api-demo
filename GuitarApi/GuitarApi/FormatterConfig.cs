using System.Net.Http.Formatting;
using GuitarApi.Formatters;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace GuitarApi
{
    public class FormatterConfig
    {
        public static void RegisterFormatters(MediaTypeFormatterCollection formatters)
        {
            formatters.Remove(formatters.JsonFormatter);
            formatters.Insert(0, new JsonpMediaTypeFormatter
            {
                SerializerSettings = new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                }
            });
        }
    }
}
