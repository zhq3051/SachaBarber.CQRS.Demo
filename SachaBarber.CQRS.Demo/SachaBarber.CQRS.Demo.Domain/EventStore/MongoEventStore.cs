﻿using CQRSlite.Events;
using CQRSlite.Util;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using SachaBarber.CQRS.Demo.Orders.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SachaBarber.CQRS.Demo.Orders.Domain.EventStore
{
    public class MongoEventStore : IRepository<IEvent, Guid>
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
                cm.MapIdProperty(c => c.eventId);
                //cm.MapProperty(c => c.TimeStamp);
                //cm.MapProperty(c => c.Version);
            });
            BsonClassMap.RegisterClassMap<OrderCreatedEvent>(cm => {
                cm.AutoMap();
                //cm.MapProperty(c => c.TimeStamp);
                //cm.MapProperty(c => c.Version);
            });
        }

        public IEnumerable<IEvent> Get(Guid aggregateId, int formVersion)
        {
            var collection =_database.GetCollection<OrderCreatedEvent>("GameEvents");
            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.Eq("eventId", aggregateId) & builder.Gt("Version", formVersion);
            var result = collection.Find(x => x.eventId == aggregateId && x.Version >= formVersion).ToList<OrderCreatedEvent>();
            
            return result;
        }

        public IEnumerable<IEvent> Get()
        {
            var collection = _database.GetCollection<IEvent>("GameEvents");
            var builder = Builders<IEvent>.Filter;
            var filter = builder.Empty;
            var result = collection.Find<IEvent>(filter).ToList<IEvent>();

            return result;
        }

        public void Save(IEvent @event)
        {
            Events.OrderCreatedEvent evt = new Events.OrderCreatedEvent(new Guid("089373bb-900b-49f2-967b-ee3db8f00c25"), "test description", "address1", null, 1);
            var collection = _database.GetCollection<IEvent>("GameEvents");
            collection.InsertOne(evt);

        }
    }
}
