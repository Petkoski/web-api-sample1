using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebAPISample1.Models;
using WebAPISample1.Models.Repository;

namespace WebAPISample1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository<Student> _dataRepository;

        public StudentController(IStudentRepository<Student> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // GET: api/student 
        [HttpGet]
        public IActionResult Get()
        {
            IQueryable students = _dataRepository.GetAll();
            return Ok(students);
        }

        // GET: api/student/{id}
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Student student = _dataRepository.Get(id);
            if (student == null)
            {
                return NotFound("Student could not be found.");
            }
            return Ok(student);
        }

        // POST: api/student 
        [HttpPost]
        public IActionResult Post([FromBody]Student student)
        {
            if (student == null)
            {
                return BadRequest("Student is null.");
            }

            Student newStudent = _dataRepository.Add(student);
            return Ok(newStudent);
        }

        // PUT: api/student/{id} 
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Student student)
        {
            if (student == null)
            {
                return BadRequest("Student is null.");
            }

            Student studentToUpdate = _dataRepository.Get(id);
            if (studentToUpdate == null)
            {
                return NotFound("Student could not be found.");
            }

            _dataRepository.Update(studentToUpdate, student);
            return NoContent();
        }

        // DELETE: api/student/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Student student = _dataRepository.Get(id);
            if (student == null)
            {
                return NotFound("Student could not be found.");
            }

            _dataRepository.Delete(student);
            return NoContent();
        }
    }
}