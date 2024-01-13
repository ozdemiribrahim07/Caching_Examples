using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace InMemory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemoryValuesController : ControllerBase
    {
        readonly IMemoryCache _memoryCache;

        public MemoryValuesController(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        [HttpGet("SetValue/{name}")]
        public void Set(string name)
        {
            _memoryCache.Set("name", name);
        }


        [HttpGet("GetValue")]
        public string Get()
        {
            if (_memoryCache.TryGetValue<String>("name", out string _))
            {
                return _memoryCache.Get<String>("name");
            }
            return "";
        }


        [HttpGet("SetDate")]
        public void SetDate()
        {
            _memoryCache.Set<DateTime>("date", DateTime.Now, options: new()
            {
                AbsoluteExpiration = DateTime.Now.AddSeconds(20),
                SlidingExpiration = TimeSpan.FromSeconds(5)
            });
        }



        [HttpGet("GetDate")]
        public DateTime GetDate()
        {
            return _memoryCache.Get<DateTime>("date");
        }



    }
}
