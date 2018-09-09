using InitialWebApi.Model.Contracts;
using InitialWebApi.Model.Models;
using MongoDB.Driver;

namespace InitialWebApi.MongoDb
{
    public class LogRepository : PipelineLogDataContext, ILogRepository
    {
        //public LogRepository(string conn, string db)
        //    : base(conn, db)
        //{
        //}

        public void Save(PipelineLogData logItem)
        {
            var logCollection = _db.GetCollection<PipelineLogData>("LogCollection");
            logCollection.InsertOne(logItem);
        }

        public PipelineLogData Get(string code)
        {
            var client = new MongoClient(ConnectionString);

            var db = client.GetDatabase(Database);

            var filter = Builders<PipelineLogData>.Filter.Eq("Code", code);

            return db.GetCollection<PipelineLogData>("LogCollection").Find(filter).FirstOrDefault();
        }
    }
}
