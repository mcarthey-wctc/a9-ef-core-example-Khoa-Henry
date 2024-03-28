using EFCoreExample.Models;

namespace EFCoreExample.Contexts.Repositories;

public interface ISchoolRepository
{
    Task<Classroom> AddClassroomAsync(Classroom classroom);
    Task<Student> AddStudentAsync(Student student);

    // Join operations
    Task AddStudentToClassroomAsync(int classroomId, Student student);
    Task DeleteClassroomAsync(int id);
    Task DeleteStudentAsync(int id);
    Task<List<Classroom>> GetAllClassroomsAsync();

    // CRUD operations for Student
    Task<List<Student>> GetAllStudentsAsync();
    Task<Classroom> GetClassroomByIdAsync(int id);
    Task<Student> GetStudentByIdAsync(int id);
    Task<List<Student>> GetStudentsInClassroomAsync(int classroomId);
    Task<Classroom> UpdateClassroomAsync(Classroom classroom);
    Task<Student> UpdateStudentAsync(Student student);
}
