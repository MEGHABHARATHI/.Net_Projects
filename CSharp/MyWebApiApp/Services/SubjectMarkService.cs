using MyWebApiApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;



namespace MyWebApiApp.Services
{
    public class SubjectMarkService
    {
        private readonly AppDbContext dbcontext;
        public SubjectMarkService(AppDbContext _dbcontext)
        {
            dbcontext = _dbcontext;
        }

        public async Task<List<SubjectMark>> GetAllSubjectMark()
        {
            return await dbcontext.MarkDetails.ToListAsync();
        }

        public async Task<SubjectMark> GetSubjectMarkById(int id)
        {
            return await dbcontext.MarkDetails.FindAsync(id);
        }
        public async Task<SubjectMark> AddSubjectMarkAsync(SubjectMark SubjectMark)
        {
            dbcontext.MarkDetails.Add(SubjectMark);
            await dbcontext.SaveChangesAsync();
            return SubjectMark;
        }
    }
}
