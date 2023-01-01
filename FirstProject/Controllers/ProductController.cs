using Entities;
using Microsoft.AspNetCore.Mvc;
using Service;
using T_Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FirstProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _iProductService;

        public ProductController(IProductService iProductService)
        {
            _iProductService = iProductService;
        }
        // GET: api/<ProductController>
        [Route("get")]
        [HttpGet]
        public async Task<Product[]> Get([FromQuery] string? name, [FromQuery] int? price_from, [FromQuery] int? price_to, [FromQuery] int?[] categoryIds, [FromQuery] int start, [FromQuery] int limit, [FromQuery] string? direction = "ASC", string? orderBy = "price")
        {

            Product [] product = await _iProductService.GetProduct(name, price_from, price_to, categoryIds, start, limit, direction, orderBy);
            return product;
        }

       



        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProductController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}



//using Entities;
//using Microsoft.AspNetCore.Mvc;
//using Service;

//// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//namespace FirstProject.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ProductController : ControllerBase
//    {
//        private readonly IProductService _IProductService;
//        public ProductController(IProductService IProductService)
//        {

//            _IProductService = IProductService;
//        }
//        // GET api/<ProductController>
//        [HttpGet]
//        public async Task<Product[]> GetProduct([FromQuery] string? name, [FromQuery]  int? price_from, [FromQuery] int? price_to, [FromQuery] int[]? categoryIds, [FromQuery] int start, [FromQuery] int limit, [FromQuery] string? direction = "ASC", [FromQuery] string? orderBy = "price")
//        {
//            var product = await _IProductService.GetProduct(name, price_from, price_to, categoryIds, start, limit, direction, orderBy);
//            return product;

//        }

//        // GET api/<ProductController>/5
//        [HttpGet("{id}")]
//        public string Get(int id)
//        {
//            return "value";
//        }

//        // POST api/<ProductController>
//        [HttpPost]
//        public void Post([FromBody] string value)
//        {

//        }

//        // PUT api/<ProductController>/5
//        [HttpPut("{id}")]
//        public void Put(int id, [FromBody] string value)
//        {
//        }

//        // DELETE api/<ProductController>/5
//        [HttpDelete("{id}")]
//        public void Delete(int id)
//        {
//        }
//    }
//}
