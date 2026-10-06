using MyWebApiApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MyWebApiApp.Controllers
{
    [ApiController]
    [Route("api/subject")]
    public class SubjectMarkController : ControllerBase
    {
        public async Task<IActionResult> GetAll(){
            return Ok("welcome to new controller");
            
        }
        
    }
}