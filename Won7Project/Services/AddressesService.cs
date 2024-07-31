using Won7Project.Data;
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
        public Address GetAddressById(int id) =>
            ctx.Addresses.FirstOrDefault(a => a.Id==id);
        public void ChangeStudent(int addressId, Guid studentId)
        {
            var address = ctx.Addresses.FirstOrDefault(a => a.Id == addressId);
            if (address != null)
            {
                address.StudentId = studentId;
            }
            ctx.SaveChanges();
        }

    }
}
