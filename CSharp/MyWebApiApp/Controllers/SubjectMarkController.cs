using MyWebApiApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;
using MyWebApiApp.Services;

namespace MyWebApiApp.Controllers
{
    [ApiController]
    [Route("api/subject")]
    public class SubjectMarkController : ControllerBase
    {
        private readonly SubjectMarkService subMarkService;

        public SubjectMarkController(SubjectMarkService _subMarkService)
        {
            subMarkService = _subMarkService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubjectMark>>> GetAll()
        {
            var all_marks = await subMarkService.GetAllSubjectMark();
            return Ok(all_marks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SubjectMark>> GetById(int id)
        {
            var this_subject = await subMarkService.GetSubjectMarkById(id);
            if (this_subject == null)
            {
                return NotFound("Subject not found");
            }
            return Ok(this_subject);
        }

        [HttpPost]

        public async Task<IActionResult> Create([FromBody] SubjectMark subMark)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createdMark = await subMarkService.AddSubjectMarkAsync(subMark);
            return Ok(createdMark);
        }


    }
}   