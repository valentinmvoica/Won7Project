using Won7Project.Models;

namespace Won7Project.DTOs.Extensions
{
    public static class StudentExtensions
    {
        public static StudentToGetDto ToStudentToGet(this Student student)
        {
            if (student == null)
            {
                return null;
            }
            return new StudentToGetDto
            {
                Age = student.Age,
                Id = student.Id,
                Name = $"{student.FirstName} {student.LastName}",
                Address = student.Address.ToAddressToGet()
            };
        }
    }
}
