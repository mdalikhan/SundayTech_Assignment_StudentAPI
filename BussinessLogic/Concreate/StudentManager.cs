using SundayTech_Assignment_StudentAPI.BussinessLogic.Abstract;
using SundayTech_Assignment_StudentAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SundayTech_Assignment_StudentAPI.BussinessLogic.Concreate
{
    public class StudentManager : IStudentManager
    {
        private readonly IDapper _dapper;
        public StudentManager(IDapper dapper)
        {
            _dapper = dapper;
        }
        public Task<List<Student>> GetStudents(int? id)
        {
            throw new NotImplementedException();
        }
        public Task<List<Student>> SaveStudent(Student model)
        {
            throw new NotImplementedException();
        }
        public Task UpdateStudent(int id, Student model)
        {
            throw new NotImplementedException();
        }
        public Task DeleteStudent(int id)
        {
            throw new NotImplementedException();
        }
    }
}
