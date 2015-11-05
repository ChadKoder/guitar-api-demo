using System.Collections.Generic;
using GuitarApi.Interfaces;
using MongoDB.Driver;

namespace GuitarApi.Queries
{
    public class GetAllGuitars : IGetAllGuitars
    {
        public virtual List<Guitar> Select()
        {
            var client = new MongoClient("mongodb://localhost/");
            var database = client.GetDatabase("GuitarApiDB");
            var collection = database.GetCollection<Guitar>("Products");
            return collection.Find(_ => true).ToListAsync().Result;
        }
    }
}
