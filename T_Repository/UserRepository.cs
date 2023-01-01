using Entities;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Linq;
namespace T_Repository
{
  
   
    public class UserRepository : IUserRepository
    {
         ProductsContext _dbContext;

        public UserRepository(ProductsContext _dbContext)
        {
            this._dbContext = _dbContext;
        }
      


         public async Task<User>Get(string FirstName, string Password)
        {
            var list = (from user in _dbContext.Users
                        where user.Password == Password && user.User1 == FirstName
                        select user).ToArray<User>();
            return list.FirstOrDefault();
            
           

        }

        /// ///////////////////////////////////////////////////////////

        public async Task<User> Post(User user)
        {
          
           await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return user;
           

        }
        //////////////////////////////////////////////////
        ///

        public async Task<User> Put(int Id, User user)
        {
            //var newUser= await _dbContext.Users.FindAsync(Id);

            // if( newUser == null)
            //  {
            //      return null;
            //  }

            //  _dbContext.Entry(newUser).CurrentValues.SetValues(user);
            //  await _dbContext.SaveChangesAsync();
            //  return user;


            _dbContext.Users.Update(user);
            await _dbContext.SaveChangesAsync();
            return user;

        }

       
    }
}






    