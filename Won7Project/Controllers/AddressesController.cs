using AutoMapper;
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
        private readonly StudentsRegistryDbContext ctx;
        private readonly IMapper mapper;

        public AddressesController(StudentsService studentsService, AddressesService addressesService, StudentsRegistryDbContext ctx, IMapper mapper)
        {
            this.studentsService = studentsService;
            this.addressesService = addressesService;
            this.ctx = ctx;
            this.mapper = mapper;
        }
        [HttpPost("")]
        public async Task<Address> CreateAddress()
        {
            var address = new Address
            {
                City = "falticeni",
                Street = "libertatii",
                No = 254
            };
            ctx.Addresses.Add(address);
            await ctx.SaveChangesAsync();
            return address;

        }


        [HttpPost("add-student-to-address/{addressId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public async Task<IActionResult> AddStudentToAddressAsync([Range(1, int.MaxValue)] int addressId, [FromBody][GuidNotEmpty] Guid studentId, [FromQuery] bool createIfNotExist = true)
        {
            await addressesService.ChangeStudentAsync(addressId, studentId);
            return Ok();
        }
        [HttpGet("{addressId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type =typeof(AddressToGetDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public IActionResult GetAddress([Range(1, int.MaxValue)] int addressId)
        {
            
            return Ok(addressesService.GetAddressById(addressId));
        }


        [HttpGet("")]
        public IActionResult GetAddresses()
        {
            var result = new List<AddressToGetDto>();
            var addresses = ctx.Addresses.ToList();
            foreach( var address in addresses)
            {
                var mapped = mapper.Map<Address, AddressToGetDto>(address);
                result.Add(mapped);
            }

            return Ok(result);
        }
    }
}
