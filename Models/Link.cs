using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ShorteningLinks.Models
{
    public class Link
    {
        [JsonIgnore]
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string FullUrl { get; set; }

        public string ShortUrl { get; set; }
        public int СlickThroughs { get; set; }
        [JsonIgnore]
        public string Guid { get; set; }
    }
}
