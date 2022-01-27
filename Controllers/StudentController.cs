using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SundayTech_Assignment_StudentAPI.BussinessLogic.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
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
                return Ok(await _studentManager.GetStudents(id));
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
                return Ok(await _studentManager.SaveStudent(model));
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
                await _studentManager.UpdateStudent(id, model);
                return Ok();
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
                await _studentManager.DeleteStudent(id);
                return Ok();
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
