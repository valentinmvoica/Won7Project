using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Won7Project.Data;
using Won7Project.DTOs;
using Won7Project.DTOs.Extensions;
using Won7Project.DTOs.ValidationAttributes;
using Won7Project.Models;
using Won7Project.Services;

namespace Won7Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly StudentsService studentsService;
        private readonly SingletonService singletonService;

        public StudentsController(StudentsService studentsService, IConfiguration cfg, SingletonService singletonService)
        {
            this.studentsService = studentsService;
            this.singletonService = singletonService;
            var ana = cfg["Test"];
        }

        /// <summary>
        /// Creates a studnet with the parameters data
        /// </summary>
        /// <param name="studentToCreate">Student data</param>
        /// <returns>Created entity with included id</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(StudentToGetDto))]
        public IActionResult AddStudent([FromBody] StudentToCreateDTO studentToCreate)
        {
            return Created(string.Empty, studentsService.AddStudent(studentToCreate.FirstName, studentToCreate.LastName, studentToCreate.Age).ToStudentToGet());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StudentToGetDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public IActionResult GetById([GuidNotEmpty] Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("id invalid");
            }

            var student = studentsService.GetStudentById(id).ToStudentToGet();
            return Ok(student);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK,Type = typeof(List<StudentToGetDto>))]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(List<AddressToGetDto>))]
        public IActionResult GetAll()
        {
            var studentsList = studentsService.GetAll();
            return Ok(studentsList);
        }

        [HttpGet("including-addresses")]
        public IEnumerable<StudentToGetDto> GetAllWAddresses() =>
           studentsService.GetAll(true);
    }
}
