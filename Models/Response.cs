using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShorteningLinks.Models
{
    public class Response<T>
    {
        public List<string> Errors { get; set; }
        public T Object{ get; set; }
        
    }
}
