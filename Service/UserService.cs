using Entities;
using Microsoft.EntityFrameworkCore;
using T_Repository;
using Zxcvbn;
namespace Service
 
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _IUserRepository;
        public UserService(IUserRepository IUserRepository)
        {
            _IUserRepository = IUserRepository;
        }

       async public Task<User> Get(string firstname, string password)
        {
            return await _IUserRepository.Get(firstname, password);
        }


      async  public Task<User> Post(User user)
        {
            return await _IUserRepository.Post(user);
        }

        public void Put(int id, User user)
        {
            _IUserRepository.Put(id, user);
        }
        public int Check_password(string password)
        {
            Result result = Zxcvbn.Core.EvaluatePassword(password);
            return result.Score;
         
        }

        //Task<User> IUserService.Get(string firstname, string password)
        //{
        //    throw new NotImplementedException();
        //}

        //Task<User> IUserService.Post(User user)
        //{
        //    throw new NotImplementedException();
        //}
    }
}