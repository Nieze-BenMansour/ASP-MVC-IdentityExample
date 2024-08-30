using System.ComponentModel.DataAnnotations;

namespace IdentityExample.Models;

public class Course
{
    public int Id { get; set; }

    [Display(Name = "Course Name")]
    public string Name { get; set; }
}
