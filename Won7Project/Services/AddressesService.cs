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
        public void ChangeStudent(int addressId, Guid studentId)
        {
            var address = ctx.Addresses.FirstOrDefault(a => a.Id == addressId);
            if (address == null)
            {
                throw new IdNotFoundException($"address with id {addressId} not found");
            }

            if (!ctx.Students.Any(s => s.Id == studentId))
            {
                throw new IdNotFoundException($"student with id {studentId} not found");
            }

            address.StudentId = studentId;

            ctx.SaveChanges();
        }

    }
}
