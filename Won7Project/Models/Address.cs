namespace Won7Project.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int No { get; set;}

        public Guid? StudentId { get; set; }
        public Student Student { get; set;}
    }

}
