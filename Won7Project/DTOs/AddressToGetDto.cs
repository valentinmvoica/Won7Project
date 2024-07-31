namespace Won7Project.DTOs
{
    public class AddressToGetDto
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
//        public int No { get; set; }

        public Guid? StudentId { get; set; }
    }
}
