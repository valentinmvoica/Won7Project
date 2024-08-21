using Microsoft.EntityFrameworkCore;
using Won7Project.Data;
using Won7Project.DTOs;
using Won7Project.DTOs.Extensions;
using Won7Project.Exceptions;
using Won7Project.Models;

namespace Won7Project.Services
{
    public class AddressesService
    {
        private readonly StudentsRegistryDbContext ctx;

        public AddressesService(StudentsRegistryDbContext ctx)
        {
            this.ctx = ctx;
        }
        public AddressToGetDto GetAddressById(int id) =>
            ctx.Addresses.FirstOrDefault(a => a.Id==id).ToAddressToGet();
        public async Task ChangeStudentAsync(int addressId, Guid studentId)
        {
            var address = await ctx.Addresses.FirstOrDefaultAsync(a => a.Id == addressId);
            if (address == null)
            {
                throw new IdNotFoundException($"address with id {addressId} not found");
            }

            if (! (await ctx.Students.AnyAsync(s => s.Id == studentId)) )
            {
                var student = new Student
                {
                    FirstName = "Anonim",
                    LastName = "anonim",
                    Age = 0
                };

                ctx.Students.Add(student);

                await ctx.SaveChangesAsync();

                studentId = student.Id;

            }

            address.StudentId = studentId;

            await ctx.SaveChangesAsync();


        }
         

    }
}

