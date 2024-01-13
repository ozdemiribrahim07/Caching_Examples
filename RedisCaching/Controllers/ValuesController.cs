using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System.Text;

namespace RedisCaching.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        readonly IDistributedCache _distributedCache;


        public ValuesController(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        [HttpGet("Set")]
        public async Task<IActionResult> Set(string name)
        {
           await _distributedCache.SetStringAsync("name", name, options : new()
           {
               AbsoluteExpiration = DateTime.Now.AddSeconds(20),
               SlidingExpiration = TimeSpan.FromSeconds(5),
           });
           return Ok(); 
        }


        [HttpGet("Get")]
        public async Task<IActionResult> Get()
        {
           var name = await _distributedCache.GetStringAsync("name");
           return Ok( new
           {
               name
           });
        }



    }
}
