using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS1
{
    internal class Course
    {
        public int courseId;
        public string courseName;
        public string courseCode;
        public string instructorName;

        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public string CourseCode { get; set; }
        public string InstructorName { get; set; }

        private Teacher AssignedTeacher;
        public List<Enrollment> Enrollments { get; set; }

        public Course()
        {
            Enrollments = new List<Enrollment>();
        }
        public Course(int courseId, string courseName, string courseCode, string instructorName)
        {
            CourseID = courseId;
            CourseName = courseName;
            CourseCode = courseCode;
            InstructorName = instructorName;
        }

        public void DisplayCourseInfo()
        {
            Console.WriteLine($"Course ID: {CourseID}, Course Name: {CourseName}, Course Code: {CourseCode}, Instructor Name: {InstructorName} ");
        }

        public void AssignTeacher(Teacher teacher)
        {
            AssignedTeacher = teacher;
            Console.WriteLine($"Teacher assigned: {teacher.FirstName}{teacher.LastName}");
        }

        public void UpdateCourseInfo(string courseCode, string courseName, string instructorName)
        {
            CourseCode = courseCode;
            CourseName = courseName;
            Console.WriteLine($"Course updated by {instructorName}");
        }

        public Teacher GetTeacher()
        {
            return AssignedTeacher;
        }
    }
}
