using Won7Project.Models;

namespace Won7Project.DTOs
{
    public class StudentToGetDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public AddressToGetDto Address { get; set; }
    }
}
