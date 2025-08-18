using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MiddlewaresDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoController : ControllerBase
    {


        [HttpGet("throw")]
        public IActionResult ThrowException() {
            throw new Exception("This is a test  exception");
        
        }
        [HttpGet("throw1")]
        public IActionResult Get(int id) {
            if (id == 0)
            {
                throw new InvalidDataException("ID cannot be zero");
            }
            else 
            { 
                return Ok(); 
            }
        
        
        }

    }
}
