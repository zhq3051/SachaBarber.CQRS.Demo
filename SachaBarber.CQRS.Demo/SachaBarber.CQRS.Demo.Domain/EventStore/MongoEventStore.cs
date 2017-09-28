using CQRSlite.Events;
using CQRSlite.Util;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using SachaBarber.CQRS.Demo.Orders.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SachaBarber.CQRS.Demo.Orders.Domain.EventStore
{
    public class MongoEventStore : IRepository<IEvent, Guid>, IEventStore
    {
        protected static IMongoClient _client;
        protected static IMongoDatabase _database;

        private readonly Dictionary<Guid, List<IEvent>> _mongoDB = new Dictionary<Guid, List<IEvent>>();

        //protected internal MongoCollection<IEvent> collection;

        public MongoEventStore() : this(MongoUtil<Guid>.GetDefaultConnectionString())
        {
        }

        public MongoEventStore(string connecting)
        {
            _client = new MongoClient("mongodb://localhost");
            _database = _client.GetDatabase("MongoRepositoryTests");
            BsonClassMap.RegisterClassMap<EventBase>(cm => {
                cm.AutoMap();
                cm.MapIdProperty(c => c.Id);
                //cm.MapProperty(c => c.TimeStamp);
                //cm.MapProperty(c => c.Version);
            });

            
        }

        public IEnumerable<IEvent> Get(Guid aggregateId, int fromVersion)
        {
            var collection =_database.GetCollection<EventInfo>("GameEvents");
            var builder = Builders<BsonDocument>.Filter;
            //var filter = builder.Eq("eventId", aggregateId) & builder.Gt("Version", fromVersion);
            var result = collection.Find(x => x.Id == aggregateId).FirstOrDefault();

            return result != null ? result.changes.Where(c => c.Version > fromVersion) : new List<IEvent>();
        }

        public void Get(Guid aggregateId)
        {
            var collection = _database.GetCollection<EventInfo>("GameEvents");
            var builder = Builders<EventInfo>.Filter;
            var filter = builder.Eq("Id", aggregateId);
            var result = collection.Find<EventInfo>(filter).ToList<EventInfo>().FirstOrDefault();
            
        }

        public void Save(IEvent @event)
        {
            //Dictionary<Guid, IList<IEvent>> evt = new Dictionary<Guid, IList<IEvent>>();
            //List<IEvent> evts = new List<IEvent>();
            //evts.Add(@event);
            //evt.Add(@event.Id, evts);
            //EventInfo evt = new EventInfo();
            //evt.Id = @event.Id;
            //evt.changes = new List<IEvent>() { @event };           
            //KeyValuePair<Guid, List<IEvent>> evt = new KeyValuePair<Guid, List<IEvent>>(@event.Id, new List<IEvent>());

            var collection = _database.GetCollection<EventInfo>("GameEvents");
            var evt = collection.Find(x => x.Id == @event.Id).FirstOrDefault();
            if (evt == null)
            {
                evt = new EventInfo();
                evt.Id = @event.Id;
                evt.changes = new List<IEvent>() { @event };
                collection.InsertOne(evt);
            }
            else
            {
                evt.changes.Add(@event);
                var update = Builders<EventInfo>.Update.Set(c=> c.changes  , evt.changes);
                collection.UpdateOne(c => c.Id == @event.Id, update);
            }          
        }
    }

    //public static class GuidExt
    //{
    //    public static ObjectId AsObjectId(this Guid gid)
    //    {
    //        var bytes = gid.ToByteArray().Take(12).ToArray();
    //        var oid = new ObjectId(bytes);
    //        return oid;
    //    }

    //    public static Guid AsGuid(this ObjectId oid)
    //    {
    //        var bytes = oid.ToByteArray().Concat(new byte[] { 5, 5, 5, 5 }).ToArray();
    //        Guid gid = new Guid(bytes);
    //        return gid;
    //    }
    //}

    public class EventInfo
    {
        [BsonId]
        public Guid Id { get; set; }

        public List<IEvent> changes { get; set; }
    }
}
