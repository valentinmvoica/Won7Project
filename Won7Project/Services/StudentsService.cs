using Microsoft.EntityFrameworkCore;
using Won7Project.Data;
using Won7Project.Models;

namespace Won7Project.Services
{
    public class StudentsService
    {
        private readonly StudentsRegistryDbContext ctx;
        public StudentsService(StudentsRegistryDbContext ctx)
        {
            this.ctx = ctx;
        }

        //public Student GetStudentByName(string name) =>
        //     ctx.Students.FirstOrDefault(s => s.Name == name);
        //public Student AddStudent(string name, int Age)
        //{
        //    var student = ctx.Students.FirstOrDefault(s => s.Name == name);

        //    if (student != null)
        //    {
        //        return student;
        //    }

        //    student = new Student { Name = name, Age = Age };
        //    ctx.Students.Add(student);
        //    return student;
        //}
        public List<Student> GetAll(bool includeAddresses = false)
        {
            if (includeAddresses)
            {
                return ctx.Students.Include(s=>s.Address).ToList();
            }
            return ctx.Students.ToList();
        }
    }
}
