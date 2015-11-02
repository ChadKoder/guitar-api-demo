using System.Net;
using System.Net.Http;
using System.Web.Http;
using GuitarApi.Commands;
using GuitarApi.Formatters;
using GuitarApi.Queries;
using MongoDB.Bson;
using MongoDB.Driver;

namespace GuitarApi.controllers
{
    public class GuitarController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var client = new MongoClient("mongodb://localhost/");
            var database = client.GetDatabase("GuitarApiDB");
            var collection = database.GetCollection<Guitar>("Products");
            var allGuitars = collection.Find(_ => true).ToListAsync().Result;
            
            return Request.CreateResponse(HttpStatusCode.OK, allGuitars, new JsonpMediaTypeFormatter(Request));
        }

        public HttpResponseMessage Get(string searchText)
        {
            var client = new MongoClient("mongodb://localhost/");
            var database = client.GetDatabase("GuitarApiDB");
            var collection = database.GetCollection<Guitar>("Products");
          //  var allGuitars = collection.Find(_ => true).ToListAsync().Result;

            var filter = Builders<Guitar>.Filter.Eq("Company", searchText);
            //var searchResults = collection.Find(filter).FirstAsync();
            //if (searchResults.)
            //{
                
            //}
            var searchResults = collection.Find(filter).ToListAsync().Result;

            return Request.CreateResponse(HttpStatusCode.OK, searchResults, new JsonpMediaTypeFormatter(Request));
        }
    }
}
