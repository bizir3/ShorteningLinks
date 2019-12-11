using MongoDB.Driver;
using ShorteningLinks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShorteningLinks.Services
{
    public class LinkService
    {
        private readonly IMongoCollection<Link> _links;

        public LinkService(IShorteningLinksDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _links = database.GetCollection<Link>(settings.ShorteningLinksCollectionName);
        }

        public List<Link> Get() =>
            _links.Find(link => true).ToList();

        public Link Get(string id) =>
            _links.Find<Link>(link => link.Id == id).FirstOrDefault();

        public Link Create(Link link)
        {
            _links.InsertOne(link);
            return link;
        }

        public List<Link> GetByGuid(string guid) =>
            _links.Find<Link>(link => link.Guid == guid).ToList();

        public void Update(string id, Link linkIn) =>
            _links.ReplaceOne(link => link.Id == id, linkIn);

        internal Link GetByUrlShort(string shortUrl) =>
            _links.Find<Link>(link => link.ShortUrl == shortUrl).FirstOrDefault();
    }
}
