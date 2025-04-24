using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SISTestProject1;

namespace SISTestProject1
{
    internal class StudentService
    {
        private List<Student> students;

        public StudentService()
        {
            students = new List<Student>();
        }

        public void AddStudent(Student student)
        {
            students.Add(student);
            Console.WriteLine($"Student {student.FirstName} {student.LastName} added successfully.");
        }

        public void UpdateStudentInfo(Student student, string firstName, string lastName, DateTime dateOfBirth, string email, string phoneNumber)
        {
            if (string.IsNullOrEmpty(email) || !IsValidEmail(email))
            {
                throw new StudentException("Invalid email format.");
            }

            student.FirstName = firstName;
            student.LastName = lastName;
            student.DateOfBirth = dateOfBirth;
            student.Email = email;
            student.PhoneNumber = phoneNumber;

            Console.WriteLine($"Student {student.StudentID} updated successfully.");
        }

        public Student GetStudentById(int studentId)
        {
            return students.FirstOrDefault(s => s.StudentID == studentId);
        }

        public Student GetStudentByEmail(string email)
        {
            return students.FirstOrDefault(s => s.Email == email);
        }

        public List<Student> GetAllStudents()
        {
            return students;
        }

        public void DeleteStudent(int studentId)
        {
            Student student = GetStudentById(studentId);
            if (student != null)
            {
                students.Remove(student);
                Console.WriteLine($"Student {student.FirstName} {student.LastName} deleted successfully.");
            }
            else
            {
                Console.WriteLine($"No student found with ID {studentId}.");
            }
        }
        private bool IsValidEmail(string email)
        {
            return email.Contains("@") && email.Contains(".");
        }
    }
}
