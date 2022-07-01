using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task9.Models;

namespace Task9;

public interface IStudentService
{
    List<Course> GetCourses();
    IQueryable<Student> GetStudents(int? id);

    Student? SearchStudent(int? id);

    void SaveChanges(Student student);

    bool TryDeleteStudent(Student student);
}

public class StudentService : IStudentService
{
    ApplicationContext db;
    public StudentService(ApplicationContext context)
    {
        db = context;
    }
    public List<Course> GetCourses() => db.Courses.ToList();

    public IQueryable<Student> GetStudents(int? id) => db.Students.Where(p => p.GroupId == id);

    public Student? SearchStudent(int? id) => db.Students.FirstOrDefault(p => p.StudentId == id);

    public void SaveChanges(Student student)
    {
        db.Students.Update(student);
        db.SaveChanges();
    }

    public bool TryDeleteStudent(Student student)
    {
        try
        {
            db.Students.Remove(student);
            db.SaveChanges();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}

