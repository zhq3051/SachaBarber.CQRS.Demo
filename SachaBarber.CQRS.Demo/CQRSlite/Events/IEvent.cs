using System;
using CQRSlite.Messages;

namespace CQRSlite.Events
{
    public interface IEvent : IMessage
    {
        Guid eventId { get; set; }
        int Version { get; set; }
        DateTimeOffset TimeStamp { get; set; }
    }
}

