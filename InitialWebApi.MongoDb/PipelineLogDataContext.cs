using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.IO;

namespace InitialWebApi.MongoDb
{
    public class PipelineLogDataContext
    {
        protected IConfigurationRoot _configuration;

        public PipelineLogDataContext()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings.json");
            _configuration = builder.Build();

            _client = new MongoClient(_configuration.GetConnectionString("MongoConnection"));
            _db = _client.GetDatabase("InitialApiDb");
        }

        //public PipelineLogDataContext(string connectionString, string database)
        //{
        //    ConnectionString = connectionString;
        //    Database = database;

        //    _client = new MongoClient(ConnectionString);
        //    _db = _client.GetDatabase(Database);
        //}

        public string ConnectionString { get; set; }
        public string Database { get; set; }
        protected MongoClient _client { get; private set; }
        protected readonly IMongoDatabase _db;



    }
}
