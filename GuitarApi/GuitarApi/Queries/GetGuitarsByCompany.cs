using System.Collections.Generic;
using GuitarApi.Interfaces;
using MongoDB.Driver;

namespace GuitarApi.Queries
{
    public class GetGuitarsByCompany : IGetGuitarsByCompany
    {
        public virtual List<Guitar> Select(string searchText)
        {
            var client = new MongoClient("mongodb://localhost/");
            var database = client.GetDatabase("GuitarApiDB");
            var collection = database.GetCollection<Guitar>("Products");
            
            var filter = Builders<Guitar>.Filter.Eq("Company", searchText);
            return collection.Find(filter).ToListAsync().Result;
        }
    }
}
