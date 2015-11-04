using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GuitarApi.Formatters;
using GuitarApi.Queries;
using MongoDB.Driver;

namespace GuitarApi.controllers
{
    public class GuitarController : ApiController
    {
        public HttpResponseMessage Get(string searchText)
        {
            var results = new GetGuitarsByCompany().Select(searchText);

            return Request.CreateResponse(HttpStatusCode.OK, results, new JsonpMediaTypeFormatter(Request));
        }
    }
}
