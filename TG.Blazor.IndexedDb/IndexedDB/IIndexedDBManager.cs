using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TG.Blazor.IndexedDB
{
    public interface IIndexedDBManager
    {
        event EventHandler<IndexedDBNotificationArgs> ActionCompleted;
        List<StoreSchema> Stores { get; }
        int CurrentVersion { get; }
        string DbName { get; }
        Task OpenDb();
        Task DeleteDb(string dbName);
        Task GetCurrentDbState();
        Task AddNewStore(StoreSchema storeSchema);
        Task AddRecord<T>(StoreRecord<T> recordToAdd);
        Task UpdateRecord<T>(StoreRecord<T> recordToUpdate);
        Task<List<TResult>> GetRecords<TResult>(string storeName);
        Task<TResult> GetRecordById<TInput, TResult>(string storeName, TInput id);
        Task DeleteRecord<TInput>(string storeName, TInput id);
        Task ClearStore(string storeName);
        Task<TResult> GetRecordByIndex<TInput, TResult>(StoreIndexQuery<TInput> searchQuery);
        Task<IList<TResult>> GetAllRecordsByIndex<TInput, TResult>(StoreIndexQuery<TInput> searchQuery);
        void CalledFromJS(string message);
    }
}
