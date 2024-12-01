using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PhilosophersApi.Models
{
    public class Quote
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("philosopher")]
        public string Philosopher { get; set; }

        [BsonElement("text")]
        public string Text { get; set; }
    }
}
