using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Won7Project.Data;
using Won7Project.Models;
using Won7Project.Services;

namespace Won7Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeedController : ControllerBase
    {
        
        private readonly SeedService seedService;

        public SeedController(SeedService seedService)
        {
            this.seedService = seedService;
        }
        

        [HttpPost]
        public void Seed()
        {
            this.seedService.Seed();    
        }
    }
}
