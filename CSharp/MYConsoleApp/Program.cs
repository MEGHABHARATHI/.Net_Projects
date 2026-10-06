    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using Serilog;
    using System.Threading.Tasks;

    namespace learn_new
    {
              

        class Program
        {
            static async Task Main(string[] args)
            {
                Log.Logger = new LoggerConfiguration().WriteTo.Console().WriteTo.File("logs/learn.log", rollingInterval: RollingInterval.Day).CreateLogger();
            try
            {
                using  var db = new AppDbContext();
                {
                    Log.Information("Application started");
                    var low_marks = db.MarkDetails.Where(x => x.mark <= 90).Select(a => new
                    {
                        sub_name = a.Subject,
                        mark_value = a.mark
                    }).ToListAsync();

                    var high_marks = db.MarkDetails.Where(x => x.mark > 90).Select(a => new
                    {
                        sub_name = a.Subject,
                        mark_value = a.mark
                    }).ToListAsync();

                    await Task.WhenAll(low_marks, high_marks);

                    var low_marks_result =  low_marks.Result;
                    var high_marks_result =  high_marks.Result;

                    Console.WriteLine("Subject Marks less than or equal to 90:");
                     foreach(var mark in high_marks_result)
                    {
                        Console.WriteLine($"Score: {mark.sub_name} - {mark.mark_value}");
                    }                  
                }
            }
            catch(Exception ex)
            {
                Log.Fatal($"Exception occured:{ex}");

            }
            finally
            {
                Log.CloseAndFlush();                
            }
            }
        }
    }


