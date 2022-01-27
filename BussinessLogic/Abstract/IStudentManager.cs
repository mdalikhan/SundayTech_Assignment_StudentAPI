using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SundayTech_Assignment_StudentAPI.BussinessLogic.Abstract
{
    public interface IStudentManager
    {
        Task<List<Student>> GetStudents(int? id);
        Task<List<Student>> SaveStudent(Student model);
        Task DeleteStudent(int id);
        Task UpdateStudent(int id, Student model);
    }
}
