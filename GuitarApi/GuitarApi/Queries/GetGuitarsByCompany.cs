using System.Collections.Generic;
using System.Linq;
using GuitarApi.Interfaces;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace GuitarApi.Queries
{
    public class GetGuitarsByCompany : IGetGuitarsByCompany
    {
        public virtual List<Guitar> Select(string searchText)
        {
            var client = new MongoClient("mongodb://localhost/");
            var database = client.GetDatabase("GuitarApiDB");
            var productsCollection = database.GetCollection<Guitar>("Products");
            var result = productsCollection.AsQueryable().Where(guitar => guitar.Company.ToLower().Contains(searchText));
            
            return result.ToList();
        }
    }
}
