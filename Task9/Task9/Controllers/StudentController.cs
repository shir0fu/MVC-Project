using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task9.Models;

namespace Task9.Controllers;

public class StudentController : Controller
{

    private readonly IStudentService _service;

    public StudentController(IStudentService service)
    {
        _service = service;
    }

    public IActionResult Error()
    {
        return View();
    }

    public IActionResult Index()
    {
        return View(_service.GetCourses());
    }

    public IActionResult Students(int? id)
    {
        var student = _service.GetStudents(id);
        return View(student);
    }

    public async Task<IActionResult> EditStudent(int? id)
    {
        if (id != null)
        {
            Student? student = _service.SearchStudent(id);
            if (student != null)
            {
                return View(student);
            }
        }
        return NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> EditStudent(Student student, int? id)
    {
        Student? oldStudent = _service.SearchStudent(id);
        oldStudent.FirstName = student.FirstName;
        _service.SaveChanges(oldStudent);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Delete(int? id)
    {
        if (id != null)
        {
            Student? student = _service.SearchStudent(id);
            if (student != null)
            {
                bool res = _service.TryDeleteStudent(student);
                if (res)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Error");
                }
            }
        }
        return NotFound();
    }
}
