    using System.Linq;
    using Microsoft.EntityFrameworkCore;

    namespace learn_new
    {
        public class SubjectMark{
            public int id{get; set;  }
            public string Subject{get; set;  } = String.Empty;
            public int? mark{get; set;  }
        }
        public class emp_details{
            public int id{get; set;  }
            public string name{get; set;  } = String.Empty;
            public int? salary{get; set;  } 
        }

        public class AppDbContext : DbContext
        {
            public DbSet<SubjectMark> MarkDetails{get; set;  }
            public DbSet<emp_details> employee{get; set;  }
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlite("Data Source=app.db");
            }
            
        }

        class Program
        {
            static void Main(string[] args)
            {
                using  var db = new AppDbContext();
                {
                    var sub_marks = db.MarkDetails.Where(x => x.mark >= 80).Select(a => new
                    {
                        sub_name = a.Subject,
                        mark_value = a.mark
                    });
                    Console.WriteLine("Subject Marks greater than or equal to 80:");
                     foreach(var mark in sub_marks)
                    {
                        Console.WriteLine($"Score: {mark.sub_name} - {mark.mark_value}");
                    }

                    var emp_salary = db.employee.Where(x => x.salary >= 30000).Select(a => new
                    {
                        emp_name = a.name,
                        emp_salary_value = a.salary
                    }); 
                    Console.WriteLine("Employee Salary greater than or equal to 30000:");

                    foreach(var emp in emp_salary)
                    {
                        Console.WriteLine($"Employee: {emp.emp_name} - Salary: {emp.emp_salary_value}");
                    }    
                }                
            }
        }
    }


