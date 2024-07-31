using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Won7Project.Data;
using Won7Project.DTOs;
using Won7Project.DTOs.Extensions;
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
        //[HttpPost]
        //public StudentToGet AddStudent([FromBody] StudentToCreateDTO studentToCreate) =>
        //    studentsService.AddStudent(studentToCreate.Name, studentToCreate.Age).ToStudentToGet();

        [HttpGet("singleton")]
        public Guid GetSingletonValue() =>
            singletonService.Id;

        [HttpGet]
        public IEnumerable<StudentToGetDto> GetAll() =>
           studentsService.GetAll().Select(s => s.ToStudentToGet());
        [HttpGet("including-addresses")]
        public IEnumerable<StudentToGetDto> GetAllWAddresses() =>
           studentsService.GetAll(true).Select(s=>s.ToStudentToGet());
    }
}
