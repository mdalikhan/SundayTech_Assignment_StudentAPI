using System;

namespace SundayTech_Assignment_StudentAPI
{
    public class Student
    {
        public long Id { get; set; }

        public string Name { get; set; }
        public string Class { get; set; }

        public string RegistrationNumber { get; set; }

        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
    }
}
