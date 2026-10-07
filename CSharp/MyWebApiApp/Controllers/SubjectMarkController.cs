using MyWebApiApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace MyWebApiApp.Controllers
{
    [ApiController]
    [Route("api/subject")]
    public class SubjectMarkController : ControllerBase
    {
        private readonly AppDbContext dbcontext;

        public SubjectMarkController(AppDbContext _dbcontext)
        {
            dbcontext = _dbcontext;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            Log.Information("GetAll API called");
            try
            {
                Log.Information("Database context created");
                var all_marks = await dbcontext.MarkDetails
                    .Select(a => new
                    {
                        sub_name = a.Subject,
                        mark_value = a.mark
                    })
                    .ToListAsync();
                Log.Information(
                    "Successfully fetched {Count} subject marks",
                    all_marks.Count);
                return Ok(all_marks);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Failed to fetch subject marks");

                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            Log.Information("GetById API called with ID: {Id}", id);

            try
            {
                using var db = new AppDbContext();

                Log.Information("Searching for subject with ID: {Id}", id);

                var this_subject = await db.MarkDetails.FindAsync(id);

                if (this_subject != null)
                {
                    Log.Information(
                        "Subject found successfully. ID: {Id}",
                        id);

                    return Ok(this_subject);
                }

                Log.Warning(
                    "Subject not found. ID: {Id}",
                    id);

                return NotFound("Subject not found");
            }
            catch (Exception ex)
            {
                Log.Error(
                    ex,
                    "Error occurred while finding subject with ID: {Id}",
                    id);

                return StatusCode(500, "Internal server error");
            }
        }
    }
}