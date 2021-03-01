using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace haushaltsbuch.Models
{
    public class Debit
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("price")]
        public string Id { get; set; }
        public decimal Price { get; set; }
        [BsonElement("category")]
        public string Category { get; set; }
        [BsonElement("comment")]
        public string Comment { get; set; }

    }
}
