using EFCoreExample.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreExample.Contexts.Repositories;

public class SchoolRepository : ISchoolRepository
{
    // The context that the repository operates on
    private readonly ISchoolContext _context;

    public SchoolRepository(ISchoolContext context)
    {
        _context = context;
    }

    public async Task<Classroom> AddClassroomAsync(Classroom classroom)
    {
        _context.Classrooms.Add(classroom);
        await _context.SaveChangesAsync();
        return classroom;
    }

    public async Task<Student> AddStudentAsync(Student student)
    {
        _context.Students.Add(student);
        await _context.SaveChangesAsync();
        return student;
    }

    // Join operations
    public async Task AddStudentToClassroomAsync(int classroomId, Student student)
    {
        var classroom = await _context.Classrooms.Include(c => c.Students).SingleAsync(c => c.ClassroomId == classroomId);
        classroom.Students.Add(student);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteClassroomAsync(int id)
    {
        var classroom = await _context.Classrooms.FindAsync(id);
        if (classroom == null)
        {
            throw new Exception($"Classroom with id {id} not found.");
        }

        _context.Classrooms.Remove(classroom);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteStudentAsync(int id)
    {
        var student = await _context.Students.FindAsync(id);
        if (student == null)
        {
            throw new Exception($"Student with id {id} not found.");
        }

        _context.Students.Remove(student);
        await _context.SaveChangesAsync();
    }

    // CRUD operations for Classroom
    public async Task<List<Classroom>> GetAllClassroomsAsync()
    {
        return await _context.Classrooms.ToListAsync();
    }

    // CRUD operations for Student
    public async Task<List<Student>> GetAllStudentsAsync()
    {
        return await _context.Students.ToListAsync();
    }

    public async Task<Classroom> GetClassroomByIdAsync(int id)
    {
        var classroom = await _context.Classrooms.FindAsync(id);
        if (classroom == null)
        {
            throw new Exception($"Classroom with id {id} not found.");
        }

        return classroom;
    }

    public async Task<Student> GetStudentByIdAsync(int id)
    {
        var student = await _context.Students.FindAsync(id);
        if (student == null)
        {
            throw new Exception($"Student with id {id} not found.");
        }

        return student;
    }

    public async Task<List<Student>> GetStudentsInClassroomAsync(int classroomId)
    {
        var classroom = await _context.Classrooms.Include(c => c.Students).SingleAsync(c => c.ClassroomId == classroomId);
        return classroom.Students.ToList();
    }

    public async Task<Classroom> UpdateClassroomAsync(Classroom classroom)
    {
        if (_context is DbContext dbContext)
        {
            dbContext.Entry(classroom).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        return classroom;
    }

    public async Task<Student> UpdateStudentAsync(Student student)
    {
        if (_context is DbContext dbContext)
        {
            dbContext.Entry(student).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        return student;
    }
}
