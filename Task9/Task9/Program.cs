using Microsoft.EntityFrameworkCore;
using Task9.Models;


var builder = WebApplication.CreateBuilder(args);

string connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));

builder.Services.AddScoped<Task9.ICourseService, Task9.CourseService>();
builder.Services.AddScoped<Task9.IGroupService, Task9.GroupService>();
builder.Services.AddScoped<Task9.IStudentService, Task9.StudentService>();

builder.Services.AddMvc();


var app = builder.Build();

app.MapControllerRoute(
    name: "default",
pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
name: "default",
pattern: "{controller=Group}/{action=Groups}/{id?}");

app.MapControllerRoute(
name: "default",
pattern: "{controller=Student}/{action=Students}/{id?}");

app.Run();
