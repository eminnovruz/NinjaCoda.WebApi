using FileServerRelational.WebApi.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace FileServerRelational.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        ISubjectService subjectService;

        public UserController(ISubjectService subjectService)
        {
            this.subjectService = subjectService;
        }

        [HttpGet("GetAllSubjects")]
        public IActionResult GetAllSubjects()
        {
            return Ok(subjectService.GetAllSubjects());
        }
    }
}
