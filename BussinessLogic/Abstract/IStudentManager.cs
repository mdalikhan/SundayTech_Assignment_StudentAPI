using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SundayTech_Assignment_StudentAPI.BussinessLogic.Abstract
{
    public interface IStudentManager
    {
        Task<Student> GetStudents(int id);
        Task<int> SaveStudent(Student model);
        Task<int> UpdateStudent(int id, Student model);
        Task<int> DeleteStudent(int id);
    }
}
