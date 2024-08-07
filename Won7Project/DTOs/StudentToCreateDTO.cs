using System.ComponentModel.DataAnnotations;
using Won7Project.DTOs.ValidationAttributes;

namespace Won7Project.DTOs
{
    /// <summary>
    /// Student to create
    /// </summary>
    [StudentToCreateIsValid]
    public class StudentToCreateDTO
    {
        /// <summary>
        /// Firstname of the student
        /// </summary>
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        [Range(2,int.MaxValue,ErrorMessage ="cannot be newborn")]
        public int Age { get; set; }
    }
}