namespace EFCoreExample.Models;

public class Student
{
    public string Name { get; set; }
    public int StudentId { get; set; }

    // EF Navigation Properties
    // Collection of classrooms that the student is associated with
    public virtual ICollection<Classroom> Classrooms { get; set; }

}
