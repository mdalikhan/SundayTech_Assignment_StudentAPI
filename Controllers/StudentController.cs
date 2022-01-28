using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SundayTech_Assignment_StudentAPI.BussinessLogic.Abstract;
using System;
using System.Threading.Tasks;

namespace SundayTech_Assignment_StudentAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly ILogger<StudentController> _logger;
        private readonly IStudentManager _studentManager;
        public StudentController(ILogger<StudentController> logger, IStudentManager studentManager)
        {
            _logger = logger;
            _studentManager = studentManager;
        }

        [HttpGet("GetStudents/{id?}")]
        public async Task<IActionResult> GetStudents(int? id)
        {
            try
            {
                _logger.LogInformation("Student API Start for GetStudents for Id = " + id);

                var result = await _studentManager.GetStudents(id);

                _logger.LogInformation("Student API End for GetStudents for Id = " + id + " with response = " + result);

                return Ok(result);
            }
            catch (Exception ex)
            {
                var errorMessage = "Error occured in StudentController method GetStudent() at " + DateTime.Now;
                _logger.LogError(errorMessage);
                throw new ApplicationException(errorMessage, ex);
            }
        }
        [HttpPost("SaveStudent")]
        public async Task<IActionResult> SaveStudent([FromBody] Student model)
        {
            try
            {
                _logger.LogInformation("Student API Start for SaveStudent for model = " + model);

                var result = await _studentManager.SaveStudent(model);

                _logger.LogInformation("Student API End for SaveStudent for model = " + model + " with response = " + result);

                return Ok(result);
            }
            catch (Exception ex)
            {
                var errorMessage = "Error occured in StudentController method SaveStudents() at " + DateTime.Now;
                _logger.LogError(errorMessage);
                throw new ApplicationException(errorMessage, ex);
            }
        }
        [HttpPut("UpdateStudent/{id}")]
        public async Task<IActionResult> UpdateStudent(int id, [FromBody] Student model)
        {
            try
            {
                _logger.LogInformation("Student API Start for UpdateStudent for Id = " + id + " model = " + model);

                var result = await _studentManager.UpdateStudent(id, model);

                _logger.LogInformation("Student API End for UpdateStudent for Id = " + id + " model = " + model + " with response = " + result);

                return Ok(result);
            }
            catch (Exception ex)
            {
                var errorMessage = "Error occured in StudentController method UpdateStudent() at " + DateTime.Now;
                _logger.LogError(errorMessage);
                throw new ApplicationException(errorMessage, ex);
            }
        }
        [HttpDelete("DeleteStudent/{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            try
            {
                _logger.LogInformation("Student API Start for DeleteStudent for Id = " + id);

                var result = await _studentManager.DeleteStudent(id);

                _logger.LogInformation("Student API End for DeleteStudent for Id = " + id + " with response = " + result);

                return Ok(result);
            }
            catch (Exception ex)
            {
                var errorMessage = "Error occured in StudentController method DeleteStudent() at " + DateTime.Now;
                _logger.LogError(errorMessage);
                throw new ApplicationException(errorMessage, ex);
            }
        }
    }
}
