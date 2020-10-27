using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PeopleApi.Models
{
    public class People
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string PersonId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
    }
}
