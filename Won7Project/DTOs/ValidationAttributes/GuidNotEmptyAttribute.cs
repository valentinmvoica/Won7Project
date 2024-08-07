using System.ComponentModel.DataAnnotations;

namespace Won7Project.DTOs.ValidationAttributes
{
    public class GuidNotEmptyAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null) {
                return ValidationResult.Success;
            }
            if (value is Guid guid)
            {
                if (guid == Guid.Empty)
                {
                    return new ValidationResult("The GUID cannot be empty.");
                }
            }
            else
            {
                return new ValidationResult("The value is not a valid GUID.");
            }

            return ValidationResult.Success;
        }
    }
    public class StudentToCreateIsValidAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is not StudentToCreateDTO studentToCreate)
            {
                return new ValidationResult("The value is not a valid GUID.");
            }

            if (string.IsNullOrWhiteSpace(studentToCreate.FirstName) && string.IsNullOrWhiteSpace(studentToCreate.LastName)) {
                return new ValidationResult("student should at least have one of the names.");
            }

            return ValidationResult.Success;
        }
    }

}
