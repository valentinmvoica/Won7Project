using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Won7Project.Data;
using Won7Project.DTOs;
using Won7Project.DTOs.ValidationAttributes;
using Won7Project.Exceptions;
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
        [HttpPost("add-student-to-address/{addressId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public IActionResult AddStudentToAddress([Range(1, int.MaxValue)] int addressId, [FromBody][GuidNotEmpty] Guid studentId, [FromQuery] bool createIfNotExist = true)
        {
            addressesService.ChangeStudent(addressId, studentId);
            return Ok();
        }
        [HttpGet("{addressId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type =typeof(AddressToGetDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public IActionResult GetAddress([Range(1, int.MaxValue)] int addressId)
        {
            
            return Ok(addressesService.GetAddressById(addressId));
        }
    }
}
