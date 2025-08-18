using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MiddlewaresDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoController : ControllerBase
    {


        [HttpGet("GETDATA")]
        public IActionResult Get() {

            var requestID = HttpContext.Items["RequestId"].ToString();

            //throw new Exception("This is a test  exception");
            return Ok(new { Message="This request id= " + requestID + " working for you"});
        
        }
        [HttpGet("GetBYID")]
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


        [HttpGet("GETBYNAME")]
        public IActionResult Get(string id)
        {
            return Ok("HEllo");
        }

    }
}
