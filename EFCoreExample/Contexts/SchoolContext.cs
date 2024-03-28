using EFCoreExample.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreExample.Contexts;

public class SchoolContext : DbContext, ISchoolContext
{
    public SchoolContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Classroom> Classrooms { get; set; }
    public DbSet<Student> Students { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}
