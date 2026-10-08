using Serilog;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
// Configure Serilog
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("logs/mywebapiapp.log", rollingInterval: RollingInterval.Day)
    .CreateLogger();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost", policy =>
    {
        policy.WithOrigins("http://127.0.0.1:5500", "http://localhost:5500/")
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});
 
builder.Host.UseSerilog();
builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddScoped<MyWebApiApp.Models.AppDbContext>();
builder.Services.AddScoped<MyWebApiApp.Services.SubjectMarkService>();
builder.Services.AddScoped<MyWebApiApp.Services.ProductService>();

var app= builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();    
}

app.UseCors("AllowLocalhost");
app.UseHttpsRedirection();
app.MapControllers();

app.MapGet("/welcome", () =>
{
    
    return "welcome to my web api";
});

app.Run();

