﻿using Postgrest.Models;
using Postgrest.Responses;
using Supabase.Core.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Postgrest.Interfaces
{
    public interface IPostgrestTable<T> : IGettableHeaders
        where T : BaseModel, new()
    {
        string BaseUrl { get; }
        string TableName { get; }

        Table<T> And(List<QueryFilter> filters);
        void Clear();
        Table<T> Columns(string[] columns);
        Task<int> Count(Constants.CountType type, CancellationToken cancellationToken = default);
        Task Delete(QueryOptions? options = null, CancellationToken cancellationToken = default);
        Task<ModeledResponse<T>> Delete(T model, QueryOptions? options = null, CancellationToken cancellationToken = default);
        Table<T> Filter(string columnName, Constants.Operator op, object criterion);
        Task<ModeledResponse<T>> Get(CancellationToken cancellationToken = default);
        Task<ModeledResponse<T>> Insert(ICollection<T> models, QueryOptions? options = null, CancellationToken cancellationToken = default);
        Task<ModeledResponse<T>> Insert(T model, QueryOptions? options = null, CancellationToken cancellationToken = default);
        Table<T> Limit(int limit, string? foreignTableName = null);
        Table<T> Match(Dictionary<string, string> query);
        Table<T> Match(T model);
        Table<T> Not(QueryFilter filter);
        Table<T> Not(string columnName, Constants.Operator op, Dictionary<string, object> criteria);
        Table<T> Not(string columnName, Constants.Operator op, List<object> criteria);
        Table<T> Not(string columnName, Constants.Operator op, string criterion);
        Table<T> Offset(int offset, string? foreignTableName = null);
        Table<T> OnConflict(string columnName);
        Table<T> Or(List<QueryFilter> filters);
        Table<T> Order(string column, Constants.Ordering ordering, Constants.NullPosition nullPosition = Constants.NullPosition.First);
        Table<T> Order(string foreignTable, string column, Constants.Ordering ordering, Constants.NullPosition nullPosition = Constants.NullPosition.First);
        Table<T> Range(int from);
        Table<T> Range(int from, int to);
        Table<T> Select(string columnQuery);
        Task<T?> Single(CancellationToken cancellationToken = default);
        Task<ModeledResponse<T>> Update(T model, QueryOptions? options = null, CancellationToken cancellationToken = default);
        Task<ModeledResponse<T>> Upsert(ICollection<T> model, QueryOptions? options = null, CancellationToken cancellationToken = default);
        Task<ModeledResponse<T>> Upsert(T model, QueryOptions? options = null, CancellationToken cancellationToken = default);
    }
}