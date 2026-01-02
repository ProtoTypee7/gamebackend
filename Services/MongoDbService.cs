using MongoDB.Driver;
using P10_WebApi.Models;

namespace P10_WebApi.Services
{
    public class MongoDbService
    {
        private readonly IMongoDatabase _database;

        public MongoDbService(IConfiguration configuration)
        {

            var connectionString = configuration["MongoDB:ConnectionString"];
            var databaseName = configuration["MongoDB:DatabaseName"];


            if (string.IsNullOrWhiteSpace(connectionString))
                throw new Exception("MongoDB connection string is missing");

            if (string.IsNullOrWhiteSpace(databaseName))
                throw new Exception("MongoDB database name is missing");

            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);
        }

        public IMongoCollection<User> Users =>
            _database.GetCollection<User>("Users");
    }
}
