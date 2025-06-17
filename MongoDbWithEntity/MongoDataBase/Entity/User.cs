using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.EntityFrameworkCore;

namespace MongoDbWithEntity.MongoDataBase.Entity
{
    [Collection("users")]
    public class User
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public int age { get; set; }
        public string Name { get; set; }
        public List<string> Hoppies { get; set; }
    }
}
