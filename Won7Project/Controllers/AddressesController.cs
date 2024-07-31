using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Won7Project.Data;
using Won7Project.DTOs;
using Won7Project.Models;
using Won7Project.Services;

namespace Won7Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly StudentsService studentsService;
        private readonly AddressesService addressesService;

        public AddressesController(StudentsService studentsService, AddressesService addressesService)
        {
            this.studentsService = studentsService;
            this.addressesService = addressesService;
        }
        //[HttpPost("add-student-to-address/{addressId}")]
        //public void AddStudentToAddress(int addressId, [FromBody] StudentToCreateDTO studentToCreate, [FromQuery]bool createIfNotExist = true)
        //{
        //    var address = addressesService.GetAddressById(addressId);

        //    if (address == null) {
        //        return;
        //    }

        //    var studentEntity = studentsService.GetStudentByName(studentToCreate.Name);

        //    if (studentEntity == null)
        //    {
        //        if (!createIfNotExist)
        //        {
        //            return;
        //        }

        //        studentEntity = studentsService.AddStudent(studentToCreate.Name, studentToCreate.Age);
        //    }

        //    addressesService.ChangeStudent(addressId, studentEntity.Id);
        //}
    }
}
