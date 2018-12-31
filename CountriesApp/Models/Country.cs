using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CountriesApp.Models
{
    public class Country
    {
        [BsonElement("_id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("capitalCity")]
        public string CapitalCity { get; set; }

        [BsonElement("population")]
        public int Population { get; set; }
    }
}
