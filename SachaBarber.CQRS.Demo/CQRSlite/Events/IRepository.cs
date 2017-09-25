using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CQRSlite.Events
{
    public interface IRepository<T, TKey> where T : IEvent
    {
        void Save(T @event);

        IEnumerable<T> Get(Guid aggregateId, int fromVersion);
    }



    //public class MongoCollection<T> : MongoCollectionBase<T>
    //{
    //    public override CollectionNamespace CollectionNamespace => throw new NotImplementedException();

    //    public override IMongoDatabase Database => throw new NotImplementedException();

    //    public override IBsonSerializer<T> DocumentSerializer => throw new NotImplementedException();

    //    public override IMongoIndexManager<T> Indexes => throw new NotImplementedException();

    //    public override MongoCollectionSettings Settings => throw new NotImplementedException();

    //    public override IAsyncCursor<TResult> Aggregate<TResult>(PipelineDefinition<T, TResult> pipeline, AggregateOptions options = null, CancellationToken cancellationToken = default(CancellationToken))
    //    {
    //        return base.Aggregate(pipeline, options, cancellationToken);
    //    }

    //    public override Task<IAsyncCursor<TResult>> AggregateAsync<TResult>(PipelineDefinition<T, TResult> pipeline, AggregateOptions options = null, CancellationToken cancellationToken = default(CancellationToken))
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public override BulkWriteResult<T> BulkWrite(IEnumerable<WriteModel<T>> requests, BulkWriteOptions options = null, CancellationToken cancellationToken = default(CancellationToken))
    //    {
    //        return base.BulkWrite(requests, options, cancellationToken);
    //    }

    //    public override Task<BulkWriteResult<T>> BulkWriteAsync(IEnumerable<WriteModel<T>> requests, BulkWriteOptions options = null, CancellationToken cancellationToken = default(CancellationToken))
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public override long Count(FilterDefinition<T> filter, CountOptions options = null, CancellationToken cancellationToken = default(CancellationToken))
    //    {
    //        return base.Count(filter, options, cancellationToken);
    //    }

    //    public override Task<long> CountAsync(FilterDefinition<T> filter, CountOptions options = null, CancellationToken cancellationToken = default(CancellationToken))
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public override DeleteResult DeleteMany(FilterDefinition<T> filter, CancellationToken cancellationToken = default(CancellationToken))
    //    {
    //        return base.DeleteMany(filter, cancellationToken);
    //    }

    //    public override DeleteResult DeleteMany(FilterDefinition<T> filter, DeleteOptions options, CancellationToken cancellationToken = default(CancellationToken))
    //    {
    //        return base.DeleteMany(filter, options, cancellationToken);
    //    }

    //    public override Task<DeleteResult> DeleteManyAsync(FilterDefinition<T> filter, CancellationToken cancellationToken = default(CancellationToken))
    //    {
    //        return base.DeleteManyAsync(filter, cancellationToken);
    //    }

    //    public override Task<DeleteResult> DeleteManyAsync(FilterDefinition<T> filter, DeleteOptions options, CancellationToken cancellationToken = default(CancellationToken))
    //    {
    //        return base.DeleteManyAsync(filter, options, cancellationToken);
    //    }

    //    public override DeleteResult DeleteOne(FilterDefinition<T> filter, CancellationToken cancellationToken = default(CancellationToken))
    //    {
    //        return base.DeleteOne(filter, cancellationToken);
    //    }

    //    public override DeleteResult DeleteOne(FilterDefinition<T> filter, DeleteOptions options, CancellationToken cancellationToken = default(CancellationToken))
    //    {
    //        return base.DeleteOne(filter, options, cancellationToken);
    //    }

    //    public override Task<DeleteResult> DeleteOneAsync(FilterDefinition<T> filter, CancellationToken cancellationToken = default(CancellationToken))
    //    {
    //        return base.DeleteOneAsync(filter, cancellationToken);
    //    }

    //    public override Task<DeleteResult> DeleteOneAsync(FilterDefinition<T> filter, DeleteOptions options, CancellationToken cancellationToken = default(CancellationToken))
    //    {
    //        return base.DeleteOneAsync(filter, options, cancellationToken);
    //    }

    //    public override IAsyncCursor<TField> Distinct<TField>(FieldDefinition<T, TField> field, FilterDefinition<T> filter, DistinctOptions options = null, CancellationToken cancellationToken = default(CancellationToken))
    //    {
    //        return base.Distinct(field, filter, options, cancellationToken);
    //    }

    //    public override Task<IAsyncCursor<TField>> DistinctAsync<TField>(FieldDefinition<T, TField> field, FilterDefinition<T> filter, DistinctOptions options = null, CancellationToken cancellationToken = default(CancellationToken))
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public override bool Equals(object obj)
    //    {
    //        return base.Equals(obj);
    //    }

    //    public override Task<IAsyncCursor<TProjection>> FindAsync<TProjection>(FilterDefinition<T> filter, FindOptions<T, TProjection> options = null, CancellationToken cancellationToken = default(CancellationToken))
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public override TProjection FindOneAndDelete<TProjection>(FilterDefinition<T> filter, FindOneAndDeleteOptions<T, TProjection> options = null, CancellationToken cancellationToken = default(CancellationToken))
    //    {
    //        return base.FindOneAndDelete(filter, options, cancellationToken);
    //    }

    //    public override Task<TProjection> FindOneAndDeleteAsync<TProjection>(FilterDefinition<T> filter, FindOneAndDeleteOptions<T, TProjection> options = null, CancellationToken cancellationToken = default(CancellationToken))
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public override TProjection FindOneAndReplace<TProjection>(FilterDefinition<T> filter, T replacement, FindOneAndReplaceOptions<T, TProjection> options = null, CancellationToken cancellationToken = default(CancellationToken))
    //    {
    //        return base.FindOneAndReplace(filter, replacement, options, cancellationToken);
    //    }

    //    public override Task<TProjection> FindOneAndReplaceAsync<TProjection>(FilterDefinition<T> filter, T replacement, FindOneAndReplaceOptions<T, TProjection> options = null, CancellationToken cancellationToken = default(CancellationToken))
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public override TProjection FindOneAndUpdate<TProjection>(FilterDefinition<T> filter, UpdateDefinition<T> update, FindOneAndUpdateOptions<T, TProjection> options = null, CancellationToken cancellationToken = default(CancellationToken))
    //    {
    //        return base.FindOneAndUpdate(filter, update, options, cancellationToken);
    //    }

    //    public override Task<TProjection> FindOneAndUpdateAsync<TProjection>(FilterDefinition<T> filter, UpdateDefinition<T> update, FindOneAndUpdateOptions<T, TProjection> options = null, CancellationToken cancellationToken = default(CancellationToken))
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public override IAsyncCursor<TProjection> FindSync<TProjection>(FilterDefinition<T> filter, FindOptions<T, TProjection> options = null, CancellationToken cancellationToken = default(CancellationToken))
    //    {
    //        return base.FindSync(filter, options, cancellationToken);
    //    }

    //    public override int GetHashCode()
    //    {
    //        return base.GetHashCode();
    //    }

    //    public override void InsertMany(IEnumerable<T> documents, InsertManyOptions options = null, CancellationToken cancellationToken = default(CancellationToken))
    //    {
    //        base.InsertMany(documents, options, cancellationToken);
    //    }

    //    public override Task InsertManyAsync(IEnumerable<T> documents, InsertManyOptions options = null, CancellationToken cancellationToken = default(CancellationToken))
    //    {
    //        return base.InsertManyAsync(documents, options, cancellationToken);
    //    }

    //    public override void InsertOne(T document, InsertOneOptions options = null, CancellationToken cancellationToken = default(CancellationToken))
    //    {
    //        base.InsertOne(document, options, cancellationToken);
    //    }

    //    public override Task InsertOneAsync(T document, CancellationToken _cancellationToken)
    //    {
    //        return base.InsertOneAsync(document, _cancellationToken);
    //    }

    //    public async void Insertxxx(T document, CancellationToken _cancellationToken, InsertOneOptions options = null)
    //    {
    //        await this.InsertOneAsync(document, options, _cancellationToken);
    //    }

    //    public override Task InsertOneAsync(T document, InsertOneOptions options = null, CancellationToken cancellationToken = default(CancellationToken))
    //    {
    //        return base.InsertOneAsync(document, options, cancellationToken);
    //    }

    //    public override IAsyncCursor<TResult> MapReduce<TResult>(BsonJavaScript map, BsonJavaScript reduce, MapReduceOptions<T, TResult> options = null, CancellationToken cancellationToken = default(CancellationToken))
    //    {
    //        return base.MapReduce(map, reduce, options, cancellationToken);
    //    }

    //    public override Task<IAsyncCursor<TResult>> MapReduceAsync<TResult>(BsonJavaScript map, BsonJavaScript reduce, MapReduceOptions<T, TResult> options = null, CancellationToken cancellationToken = default(CancellationToken))
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public override IFilteredMongoCollection<TDerivedDocument> OfType<TDerivedDocument>()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public override ReplaceOneResult ReplaceOne(FilterDefinition<T> filter, T replacement, UpdateOptions options = null, CancellationToken cancellationToken = default(CancellationToken))
    //    {
    //        return base.ReplaceOne(filter, replacement, options, cancellationToken);
    //    }

    //    public override Task<ReplaceOneResult> ReplaceOneAsync(FilterDefinition<T> filter, T replacement, UpdateOptions options = null, CancellationToken cancellationToken = default(CancellationToken))
    //    {
    //        return base.ReplaceOneAsync(filter, replacement, options, cancellationToken);
    //    }

    //    public override string ToString()
    //    {
    //        return base.ToString();
    //    }

    //    public override UpdateResult UpdateMany(FilterDefinition<T> filter, UpdateDefinition<T> update, UpdateOptions options = null, CancellationToken cancellationToken = default(CancellationToken))
    //    {
    //        return base.UpdateMany(filter, update, options, cancellationToken);
    //    }

    //    public override Task<UpdateResult> UpdateManyAsync(FilterDefinition<T> filter, UpdateDefinition<T> update, UpdateOptions options = null, CancellationToken cancellationToken = default(CancellationToken))
    //    {
    //        return base.UpdateManyAsync(filter, update, options, cancellationToken);
    //    }

    //    public override UpdateResult UpdateOne(FilterDefinition<T> filter, UpdateDefinition<T> update, UpdateOptions options = null, CancellationToken cancellationToken = default(CancellationToken))
    //    {
    //        return base.UpdateOne(filter, update, options, cancellationToken);
    //    }

    //    public override Task<UpdateResult> UpdateOneAsync(FilterDefinition<T> filter, UpdateDefinition<T> update, UpdateOptions options = null, CancellationToken cancellationToken = default(CancellationToken))
    //    {
    //        return base.UpdateOneAsync(filter, update, options, cancellationToken);
    //    }

    //    public override IMongoCollection<T> WithReadConcern(ReadConcern readConcern)
    //    {
    //        return base.WithReadConcern(readConcern);
    //    }

    //    public override IMongoCollection<T> WithReadPreference(ReadPreference readPreference)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public override IMongoCollection<T> WithWriteConcern(WriteConcern writeConcern)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
