using System.Net;
using System.Net.Http;
using System.Web.Http;
using GuitarApi.Formatters;
using GuitarApi.Queries;

namespace GuitarApi.controllers
{
    public class GuitarController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage Get()
        {
            const string connectionString =
                @"Data Source=localhost\SQLEXPRESS;Initial Catalog=GuitarDB;Integrated Security=SSPI;";
              
            using (var db = new Database(connectionString, "System.Data.SqlClient"))
            {
                var guitars = new GetAllGuitars(db).Execute();
                
                return Request.CreateResponse(HttpStatusCode.OK, guitars, new JsonpMediaTypeFormatter(Request));
            }
        }
    }
}
