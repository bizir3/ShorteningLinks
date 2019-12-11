using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShorteningLinks.Models
{
    public class ShorteningLinksDatabaseSettings : IShorteningLinksDatabaseSettings
    {
        public string ShorteningLinksCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IShorteningLinksDatabaseSettings
    {
        string ShorteningLinksCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
