using Microsoft.Extensions.Primitives;

namespace Won7Project.Models
{
    public class Student
    {
        public Guid Id{ get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Address Address { get; set; }
    }
}
