using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;


namespace GoByBus.Core.Entities
{
    public class UserEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("Name")]
        public string BookName { get; set; } 

        //public string Email
    }
}
