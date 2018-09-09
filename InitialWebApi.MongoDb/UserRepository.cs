using System.Collections.Generic;
using InitialWebApi.Model.Contracts;
using InitialWebApi.Model.Models;
using MongoDB.Driver;

namespace InitialWebApi.MongoDb
{
    public class UserRepository : PipelineLogDataContext, IUserRepository
    {

        public UserRepository(){}

        //public UserRepository(string conn, string db)
        //    : base(conn, db)
        //{}

        public User Add(User user)
        {
            var userCollection = 
                _db.GetCollection<User>("UserCollection");

            userCollection.InsertOne(user);

            return user;
        }

        public IEnumerable<User> Get()
        {            
            var documents =
                _db
                .GetCollection<User>("UserCollection")
                .FindAsync(Builders<User>.Filter.Empty)
                .Result
                .ToList();

            return documents;
        }

        public User GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public User Update(int id, User user)
        {
            throw new System.NotImplementedException();
        }
    }
}
