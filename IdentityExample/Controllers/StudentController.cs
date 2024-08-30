using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using IdentityExample.Data;


namespace IdentityExample.Controllers;

[Authorize]
public class StudentController : Controller
{
    private StudentContext _studentContext;

    public StudentController(StudentContext studentContext)
    {
        _studentContext = studentContext;
    }

    public IActionResult Index()
    {
        return View();
    }

    [AllowAnonymous]
    public IActionResult CourseDetails()
    {
        return View(_studentContext.Courses.ToList());
    }
}