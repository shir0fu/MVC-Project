using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task9.Models;

namespace Task9.Controllers;

public class GroupController : Controller
{


    private readonly IGroupService _service;

    public GroupController(IGroupService service)
    {
        _service = service;
    }

    public IActionResult Index()
    {
        return View(_service.GetCourses());
    }

    public IActionResult Error()
    {
        return View();
    }

    public IActionResult Groups(int? id)
    {
        var group = _service.GetGroups(id);
        return View(group);
    }

    public IActionResult EditGroup(int? id)
    {
        if (id != null)
        {
            Group? group = _service.SearchGroup(id);
            if (group != null) return View(group);
        }
        return NotFound();
    }

    [HttpPost]
    public IActionResult EditGroup(Group group, int? id)
    {
        Group? oldGroup = _service.SearchGroup(id);
        oldGroup.Name = group.Name;
        _service.SaveChanges(group);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Delete(int? id)
    {
        if (id != null)
        {
            Group? group = _service.SearchGroup(id);
            if (group != null)
            {
                bool res = _service.TryDeleteGroup(group);
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
