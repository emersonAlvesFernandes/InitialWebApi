using InitialWebApi.Model.Models;
using System.Collections.Generic;

namespace InitialWebApi.Model.Contracts
{
    public interface IUserRepository
    {
        User Add(User user);
        User Update(int id, User user);
        IEnumerable<User> Get();
        User GetById(int id);
    }
}
