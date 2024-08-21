using Microsoft.EntityFrameworkCore;
using Won7Project.Data;
using Won7Project.DTOs;
using Won7Project.DTOs.Extensions;
using Won7Project.Exceptions;
using Won7Project.Models;

namespace Won7Project.Services
{
    public class StudentsService : IStudentsService
    {
        private readonly StudentsRegistryDbContext ctx;
        public StudentsService(StudentsRegistryDbContext ctx)
        {
            this.ctx = ctx;
        }

        ~StudentsService()
        {
            int[] x = { 1, 2, 3, 4, 5, 6, };
            x[3] = 2;

        }

        public async Task<Student> GetStudentByIdAsync(Guid id)
        {
            Student st = await ctx.Students.FirstOrDefaultAsync(s => s.Id == id);

            if (st == null)
            {
                throw new IdNotFoundException($"student with id {id} not found");
            }
            return st;
        }
        public async Task<Student> AddStudentAsync(string firstName, string lastName, int Age)
        {

            var student = await ctx.Students.FirstOrDefaultAsync(s => s.FirstName == firstName && s.LastName == lastName);

            if (student != null)
            {
                return student;
            }

            student = new Student { FirstName = firstName, LastName = lastName, Age = Age };
            ctx.Students.Add(student);
           await  ctx.SaveChangesAsync();

            var x = student.Id;
            Console.WriteLine(x);
            return student;

        }

        public Student GetStudentByName(string name) =>
             ctx.Students.FirstOrDefault(s => s.FirstName + " " + s.LastName == name);
        public List<Student> GetStudentsWithCriteria()
        {


            var result = new List<Student>();
            var st = ctx.Students.ToList();

            //boxing
            int x = 3;
            object test = (object)x;

            List<object> mylist = new List<object>();
            mylist.Add(x);

            foreach (var student in st)
            {
                //Ion Ion
                if (student.FirstName.Length > 10 & student.LastName.Length > 5)
                {
                    result.Add(student);
                }
            }
            return result;

        }

        public List<StudentToGetDto> GetAll(bool includeAddresses = false)
        {
            if (includeAddresses)
            {
                return ctx.Students.Include(s => s.Address).Select(s => s.ToStudentToGet()).ToList();
            }
            return ctx.Students.Select(s => s.ToStudentToGet()).ToList();
        }

    }
    delegate List<StudentToGetDto> GetallStudentsDeegate(bool includeAddr = false);

    enum Days
    {
        Lun =0,
        Marti = 1,
        Miercuri =2 

    }
}
