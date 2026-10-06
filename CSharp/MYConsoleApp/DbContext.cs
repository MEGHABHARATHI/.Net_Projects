using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Serilog;

namespace learn_new
{
    public class AppDbContext : DbContext
        {
            public DbSet<SubjectMark> MarkDetails{get; set;  }
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlite("Data Source=app.db").LogTo(msg => Log.Information($"EF SQL:--{msg}"),
                        new[] { DbLoggerCategory.Database.Command.Name}, LogLevel.Information);                


                
            }
            
        }
}

