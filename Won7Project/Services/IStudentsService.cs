using Won7Project.DTOs;
using Won7Project.Models;

namespace Won7Project.Services
{
    public interface IStudentsService
    {
        Task<Student> AddStudentAsync(string firstName, string lastName, int Age);
        List<StudentToGetDto> GetAll(bool includeAddresses = false);
        Task<Student> GetStudentByIdAsync(Guid id);
        Student GetStudentByName(string name);
        List<Student> GetStudentsWithCriteria();
    }
}