using System.ComponentModel.DataAnnotations.Schema;

namespace Won7Project.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int No { get; set;}

        [ForeignKey("Student")]
        public Guid? StudentId { get; set; }
        public Student Student { get; set;}
    }

    class MyList<T> where T : Address
    {
        T[] vector = new T[0];
        public MyList()
        {
                var l = new List<int>();
        }


    }

}
