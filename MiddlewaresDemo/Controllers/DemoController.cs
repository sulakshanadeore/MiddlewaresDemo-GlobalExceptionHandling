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

            var requestID = HttpContext.Items["RequestId"].ToString();

            //throw new Exception("This is a test  exception");
            return Ok(new { Message="This request id= " + requestID + " working for you"});
        
        }
        [HttpGet("throw1")]
        public IActionResult Get(int id) {
           
            if (id == 0)
            {
                throw new InvalidDataException("ID cannot be zero");
            }
            else 
            {
                var requestID = HttpContext.Items["RequestId"].ToString();
                return Ok(new { Message = "This request id= " + requestID + " working for you" }); ; 
            }
        
        
        }

    }
}
