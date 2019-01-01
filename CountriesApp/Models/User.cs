using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CountriesApp.Models
{
    public class User
    {
        [BsonElement("_id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("firstName")]
        public string FirstName { get; set; }

        [BsonElement("lastName")]
        public string LastName { get; set; }

        [BsonElement("password")]
        public string Password { get; set; }

        [BsonElement("role")]
        public string Role { get; set; }

        [BsonElement("token")]
        public string Token { get; set; }
    }
}
