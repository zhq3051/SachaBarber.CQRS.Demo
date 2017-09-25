using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQRSlite.Events;
using MongoDB.Bson.Serialization.Attributes;

namespace SachaBarber.CQRS.Demo.Orders.Domain.Events
{
    public  class EventBase : IEvent
    {
        [BsonId]
        public Guid eventId { get; set; }
        public Guid Id { get; set; }
        public int Version { get; set; }
        public DateTimeOffset TimeStamp { get; set; }
    }
}
