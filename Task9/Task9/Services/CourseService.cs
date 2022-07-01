using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task9.Models;

namespace Task9;

public interface ICourseService
{
    List<Course> GetCourses();
}

public class CourseService : ICourseService
{
    ApplicationContext db;
    public CourseService(ApplicationContext context)
    {
        db = context;
    }

    public List<Course> GetCourses() => db.Courses.ToList();
}
