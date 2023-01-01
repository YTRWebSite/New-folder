using Entities;

namespace T_Repository
{
    public interface IUserRepository
    {
       Task<User> Get(string Frstname, string Password);
      Task<User> Post(User user);
       Task<User> Put(int id, User user);
    }
}