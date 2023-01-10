
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Entities;
using Service;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FirstProject.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class userController : ControllerBase
    {
        ILogger<User> _Logger;
        private readonly IUserService _IUserService;
        public userController(IUserService IUserService,ILogger <User>logger)
        {

            _IUserService = IUserService;
            _Logger = logger;
        }
        // GET: api/<ValuesController>
        [HttpGet]
   async  public Task< ActionResult<User>> Get([FromQuery]string firstname, [FromQuery] string password)
        {
            User user =await _IUserService.Get(firstname, password);
            if (user!=null){
                return user;
            }

                return StatusCode(204);
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
       async public Task<ActionResult<User> >Post([FromBody] User user)
        {
            try {
            if (await _IUserService.Post(user) != null)
            {
                return user;
            }
                _Logger.LogInformation("user" + user.User1 + "triead login");
             }
            catch(Exception e)
            {
                _Logger.LogError("error happend!!!!",e.Message);
            }
            return StatusCode(204);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] User user)
        {
            _IUserService.Put(id, user);


        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
