using System;
using SachaBarber.CQRS.Demo.Orders.Domain.EventStore;
namespace TestMongoDB
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                MongoEventStore store = new MongoEventStore("");
                store.Save(null);

                //var p = store.Get();
                var o = store.Get(new Guid("089373bb-900b-49f2-967b-ee3db8f00c25"), 1);
                Console.Write(o);
                Console.Read();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            

            Console.WriteLine("Hello World!");
        }
    }
}
