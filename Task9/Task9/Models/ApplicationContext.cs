using Microsoft.EntityFrameworkCore;

namespace Task9.Models;

public class ApplicationContext : DbContext
{
    public DbSet<Student> Students { get; set; } = null!;
    public DbSet<Group> Groups { get; set; } = null!;
    public DbSet<Course> Courses { get; set; } = null!;

    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
        Database.EnsureCreated();

        if (Students.Count() == 0)
        {
            //fill students

            for (int i = 0; i < 10; i++)
            {
                Student student = new Student() { GroupId = 1, FirstName = $"Name{i}", LastName = $"LastName{i}" };
                Students.Add(student);
            }
            SaveChanges();

            for (int i = 10; i < 20; i++)
            {
                Student student = new Student() { GroupId = 4, FirstName = $"Name{i}", LastName = $"LastName{i}" };
                Students.Add(student);
            }
            SaveChanges();

            for (int i = 20; i < 30; i++)
            {
                Student student = new Student() { GroupId = 6, FirstName = $"Name{i}", LastName = $"LastName{i}" };
                Students.Add(student);
            }
            SaveChanges();

            for (int i = 30; i < 40; i++)
            {
                Student student = new Student() { GroupId = 7, FirstName = $"Name{i}", LastName = $"LastName{i}" };
                Students.Add(student);
            }
            SaveChanges();
        }


        if (Groups.Count() == 0)
        {
            //fill groups
            for (int i = 0; i < 3; i++)
            {
                Group g = new Group() { CourseId = 1, Name = $"SR-{i}" };
                Groups.Add(g);
            }
            SaveChanges();

            for (int i = 0; i < 2; i++)
            {
                Group g = new Group() { CourseId = 2, Name = $"GG-{i}" };
                Groups.Add(g);
            }
            SaveChanges();


            Group g1 = new Group() { CourseId = 3, Name = "OR-0" };
            Group g2 = new Group() { CourseId = 4, Name = "SB-0" };
            Groups.Add(g1);
            Groups.Add(g2);
            SaveChanges();
        }

        if (Courses.Count() == 0)
        {
            //fill courses
            Course c1 = new Course() { Name = "Java", Description = "Learn Java" };
            Course c2 = new Course() { Name = "PHP", Description = "Learn PHP" };
            Course c3 = new Course() { Name = "JS", Description = "Learn JS" };
            Course c4 = new Course() { Name = "Rust", Description = "Learn Rust" };
            Courses.AddRange(c1, c2, c3, c4);
            SaveChanges();
        }
    }
}

