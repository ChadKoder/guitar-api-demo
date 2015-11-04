using System.Collections.Generic;
using MongoDB.Driver;

namespace GuitarApi.Queries
{
    public class GetGuitarsByCompany
    {
        public List<Guitar> Select(string searchText)
        {
            var client = new MongoClient("mongodb://localhost/");
            var database = client.GetDatabase("GuitarApiDB");
            var collection = database.GetCollection<Guitar>("Products");
            List<Guitar> results;

            /*TODO: client will handle this, split into two Get's*/
            if (string.IsNullOrEmpty(searchText))
            {
                results = collection.Find(_ => true).ToListAsync().Result;
            }
            else
            {
                var filter = Builders<Guitar>.Filter.Eq("Company", searchText);
                results = collection.Find(filter).ToListAsync().Result;
            }

            return results;
        }
    }
}
