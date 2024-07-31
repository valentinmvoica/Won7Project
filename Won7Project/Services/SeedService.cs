using Microsoft.AspNetCore.Authorization.Infrastructure;
using Won7Project.Data;

namespace Won7Project.Services
{
    public class SeedService
    {
        private readonly StudentsRegistryDbContext ctx;

        public SeedService(StudentsRegistryDbContext ctx)
        {
            this.ctx = ctx;
        }
        public void Seed() {
            ctx.Students.Add(new Models.Student
            {
                FirstName = "Marin",
                LastName = "Chitac",

                Age = 45,
                Address = new Models.Address
                {
                    City = "pascani",
                    Street = "Libertatii",
                    No = 1

                }
            });
            ctx.Students.Add(new Models.Student
            {
                FirstName = "Florin",
                LastName = "Marin",

                Age = 23,
                Address = new Models.Address
                {
                    City = "pascani",
                    Street = "Libertatii",
                    No = 11

                }
            });
            ctx.Students.Add(new Models.Student
            {
                FirstName = "Maria",
                LastName = "Chitac",

                Age = 45,
                Address = new Models.Address
                {
                    City = "Deva",
                    Street = "Progresului",
                    No = 1

                }
            });
            ctx.SaveChanges();
        }  
    }
}
