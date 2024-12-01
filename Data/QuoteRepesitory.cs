using MongoDB.Driver;
using PhilosophersApi.Models;
using Microsoft.Extensions.Options;

namespace PhilosophersApi.Data
{
    public class QuoteRepository
    {
        private readonly IMongoCollection<Quote> _quotesCollection;

        public QuoteRepository(IOptions<DatabaseSettings> databaseSettings, MongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(databaseSettings.Value.DatabaseName);
            _quotesCollection = database.GetCollection<Quote>(databaseSettings.Value.CollectionName);
        }

        public async Task<List<Quote>> GetAllAsync() =>
            await _quotesCollection.Find(_ => true).ToListAsync();

        public async Task<Quote> GetByIdAsync(string id) =>
            await _quotesCollection.Find(q => q.Id == id).FirstOrDefaultAsync();

        public async Task<List<Quote>> GetByPhilosopherAsync(string philosopher) =>
            await _quotesCollection.Find(q => q.Philosopher.ToLower() == philosopher.ToLower()).ToListAsync();

        public async Task CreateAsync(Quote quote) =>
            await _quotesCollection.InsertOneAsync(quote);

        public async Task UpdateAsync(string id, Quote updatedQuote) =>
            await _quotesCollection.ReplaceOneAsync(q => q.Id == id, updatedQuote);

        public async Task DeleteAsync(string id) =>
            await _quotesCollection.DeleteOneAsync(q => q.Id == id);
    }
}
