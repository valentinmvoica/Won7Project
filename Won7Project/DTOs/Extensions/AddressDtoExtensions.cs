using Won7Project.Models;

namespace Won7Project.DTOs.Extensions
{
    public static class AddressDtoExtensions
    {
        public static AddressToGetDto ToAddressToGet(this Address address)
        {
            if (address == null)
                return null;
            return new AddressToGetDto
            {
                Oras = address.City,
                Id = address.Id,    
             //   No = address.No,
                Strada = address.Street,    
                StudentId = address.StudentId   
            };
        }
    }
}
