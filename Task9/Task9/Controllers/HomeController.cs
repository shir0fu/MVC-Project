using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task9.Models;

namespace Task9.Controllers;

public class HomeController : Controller
{
    private readonly ICourseService _service;

    public HomeController(ICourseService service)
    {
        _service = service;
    }

    public IActionResult Index()
    {
        return View(_service.GetCourses());
    }

}