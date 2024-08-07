using Microsoft.EntityFrameworkCore;
using Won7Project.Data;
using Won7Project.DTOs;
using Won7Project.DTOs.Extensions;
using Won7Project.Exceptions;
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

        public Student GetStudentById(Guid id)
        {
            var st = ctx.Students.FirstOrDefault(s => s.Id == id);

            if (st == null)
            {
                throw new IdNotFoundException($"student with id {id} not found");
            }
            return st;
        }

        public Student GetStudentByName(string name) =>
             ctx.Students.FirstOrDefault(s => s.FirstName+ " " +s.LastName == name);

        public Student AddStudent(string firstName, string lastName, int Age)
        {
            var student = ctx.Students.FirstOrDefault(s => s.FirstName ==firstName && s.LastName == lastName);

            if (student != null)
            {
                return student;
            }

            student = new Student { FirstName = firstName, LastName = lastName, Age = Age };
            ctx.Students.Add(student);
            ctx.SaveChanges();
            return student;
        }
        public List<StudentToGetDto> GetAll(bool includeAddresses = false)
        {
            if (includeAddresses)
            {
                return ctx.Students.Include(s=>s.Address).Select(s=>s.ToStudentToGet()).ToList();
            }
            return ctx.Students.Select(s => s.ToStudentToGet()).ToList();
        }
    }
}
