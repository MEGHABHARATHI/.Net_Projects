using Serilog;

var builder = WebApplication.CreateBuilder(args);
// Configure Serilog
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("logs/mywebapiapp.log", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddScoped<MyWebApiApp.Models.AppDbContext>();

var app= builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapControllers();

app.MapGet("/welcome", () =>
{
    
    return "welcome to my web api";
});

app.Run();

