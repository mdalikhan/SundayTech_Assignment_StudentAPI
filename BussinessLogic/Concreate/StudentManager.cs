using Dapper;
using Microsoft.Extensions.Logging;
using SundayTech_Assignment_StudentAPI.BussinessLogic.Abstract;
using SundayTech_Assignment_StudentAPI.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SundayTech_Assignment_StudentAPI.BussinessLogic.Concreate
{
    public class StudentManager : IStudentManager
    {
        private readonly IDapper _dapper;
        private readonly ILogger<StudentManager> _logger;
        public StudentManager(IDapper dapper, ILogger<StudentManager> logger)
        {
            _dapper = dapper;
            _logger = logger;
        }
        public async Task<Student> GetStudents(int id)
        {
            try
            {
                var result = (Student) await _dapper.Execute<Student>($"Select * from [Student] where Id = {id}", null, commandType: CommandType.Text, true);
                
                return result;
            }
            catch (Exception ex)
            {
                var errorMessage = "Error occured in StudentManager method GetStudents() at " + DateTime.Now;
                _logger.LogError(errorMessage);
                throw new ApplicationException(errorMessage, ex);
            }

        }
        public async Task<int> SaveStudent(Student model)
        {
            try
            {
                var dbparams = new DynamicParameters();
                dbparams.Add("Name", model.Name);
                dbparams.Add("Class", model.Class);
                dbparams.Add("RegistrationNumber", model.RegistrationNumber);
                dbparams.Add("DateOfBirth", model.DateOfBirth);
                dbparams.Add("Gender", model.Gender);
                dbparams.Add("MobileNumber", model.MobileNumber);
                dbparams.Add("Email", model.Email);

                var result = (int)await _dapper.Execute<int>("dbo.SP_SAVESTUDENT", dbparams, isSingleRecord : true);
                return result;
            }
            catch (Exception ex)
            {
                var errorMessage = "Error occured in StudentManager method SaveStudent() at " + DateTime.Now;
                _logger.LogError(errorMessage);
                throw new ApplicationException(errorMessage, ex);
            }
        }
        public async Task<int> UpdateStudent(int id, Student model)
        {
            try
            {
                var dbparams = new DynamicParameters();
                dbparams.Add("Id", id, DbType.Int32);
                dbparams.Add("Name", model.Name);
                dbparams.Add("Class", model.Class);
                dbparams.Add("RegistrationNumber", model.RegistrationNumber);
                dbparams.Add("DateOfBirth", model.DateOfBirth);
                dbparams.Add("Gender", model.Gender);
                dbparams.Add("MobileNumber", model.MobileNumber);
                dbparams.Add("Email", model.Email);

                var result = (int)await _dapper.Execute<int>("dbo.SP_UPDATESTUDENT", dbparams, isSingleRecord : true);
                return result;
            }
            catch (Exception ex)
            {
                var errorMessage = "Error occured in StudentManager method UpdateStudent() at " + DateTime.Now;
                _logger.LogError(errorMessage);
                throw new ApplicationException(errorMessage, ex);
            }
        }
        public async Task<int> DeleteStudent(int id)
        {
            try
            {
                var result = (int)await _dapper.Execute<int>($"DELETE FROM [Student] WHERE Id = {id}", null, commandType: CommandType.Text, isSingleRecord: true);
                return result;
            }
            catch (Exception ex)
            {
                var errorMessage = "Error occured in StudentManager method DeleteStudent() at " + DateTime.Now;
                _logger.LogError(errorMessage);
                throw new ApplicationException(errorMessage, ex);
            }
        }
    }
}
