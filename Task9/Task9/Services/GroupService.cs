using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task9.Models;

namespace Task9;

public interface IGroupService
{
    List<Course> GetCourses();
    IQueryable<Group> GetGroups(int? id);

    Group SearchGroup(int? id);

    void SaveChanges(Group group);

    bool TryDeleteGroup(Group group);
}

public class GroupService : IGroupService
{
    ApplicationContext db;
    public GroupService(ApplicationContext context)
    {
        db = context;
    }
    public List<Course> GetCourses() => db.Courses.ToList();

    public IQueryable<Group> GetGroups(int? id) => db.Groups.Where(p => p.CourseId == id);

    public Group? SearchGroup(int? id) => db.Groups.FirstOrDefault(p => p.GroupId == id);

    public void SaveChanges(Group group)
    {
        db.Groups.Update(group);
        db.SaveChanges();
    }

    public bool TryDeleteGroup(Group group)
    {
        bool res = db.Students.Any(p => p.GroupId == group.GroupId);
        if (!res)
        {
            db.Groups.Remove(group);
            db.SaveChanges();
            return true;
        }
        else
        {
            return false;
        }
    }
}
