using Entities;
using T_Repository;

namespace Service
{
    public interface IUserService
    {
    Task<   User> Get(string firstname, string password);
       Task< User> Post(User user);
        void Put(int id, User user);

        int Check_password(string password);
    }
} 