using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GuitarApi.Commands;
using GuitarApi.Formatters;
using MongoDB.Driver;

namespace GuitarApi.controllers
{
    public class GuitarController : ApiController
    {
        public HttpResponseMessage Get(string searchText)
        {
            var client = new MongoClient("mongodb://localhost/");
            var database = client.GetDatabase("GuitarApiDB");
            var collection = database.GetCollection<Guitar>("Products");
            List<Guitar> results;

            if (string.IsNullOrEmpty(searchText))
            {
                results = collection.Find(_ => true).ToListAsync().Result;
            }
            else
            {
                var filter = Builders<Guitar>.Filter.Eq("Company", searchText);
                results = collection.Find(filter).ToListAsync().Result;
            }

            return Request.CreateResponse(HttpStatusCode.OK, results, new JsonpMediaTypeFormatter(Request));
        }
    }
}
