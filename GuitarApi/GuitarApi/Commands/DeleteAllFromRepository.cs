using MongoDB.Bson;
using MongoDB.Driver;

namespace GuitarApi.Commands
{
    class DeleteAllFromRepository
    {
        public void Delete()
        {
            var client = new MongoClient();
            var db = client.GetDatabase("GuitarApiDB");
            var collection = db.GetCollection<Guitar>("Products");
            var filter = new BsonDocument();
            collection.DeleteManyAsync(filter);
        }
    }
}
