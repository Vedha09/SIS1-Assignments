using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using SIS1;

namespace SIS1
{
    internal class Teacher
    {
        public int teacherId;
        public string firstName;
        public string lastName;
        public string email;

        public int TeacherID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
 
        public string Email { get; set; }
        public List<Course> AssignedCourses { get; set; }

        public Teacher()
        {
            AssignedCourses = new List<Course>();
        }
        public Teacher(int teacherID, string firstName, string lastName, string email)
        {
            TeacherID = teacherID;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        public void DisplayTeacherInfo()
        {
            Console.WriteLine($"Teacher ID: {TeacherID}, Teacher Name: {FirstName} {LastName}, Email: {Email}");
        }

        public string Name { get; set; }
        public string Expertise { get; set; }

        public Teacher(string name, string expertise)
        {
            Name = name;
            Expertise = expertise;
        }

        public void UpdateTeacherInfo(string name, string email, string expertise)
        {
            Name = name;
            Expertise = expertise;
            Console.WriteLine("Teacher information updated!!");
        }
    }
}
