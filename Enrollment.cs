using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS1
{
    internal class Enrollment
    {

        public int enrollmentId;
        public int studentId;
        public int courseId;
        public DateTime enrollmentDate;

        public int EnrollmentID { get; set; }
        public int StudentID { get; set; }
        public int CourseID { get; set; }
        public Student EnrolledStudent { get; set; }
        public Course EnrolledCourse { get; set; }
        public Student Student { get; set; }
        public Course Course { get; set; }
        public DateTime EnrollmentDate { get; set; }

        public Enrollment() { }
        public Enrollment(int enrollmentId, int studentId, int courseId, DateTime enrollmentDate)
        {
            EnrollmentID = enrollmentId;
            StudentID = studentId;
            CourseID = courseId;
            EnrollmentDate = enrollmentDate;
        }

        public Enrollment(int enrollmentId, Student student, Course course, DateTime enrollmentDate)
        {
            EnrollmentID = enrollmentId;
            Student = student;
            Course = course;
            EnrollmentDate = enrollmentDate;
        }

        public void DisplayEnrollmentInfo()
        {
            Console.WriteLine($"Enrollment ID: {EnrollmentID}, Student ID: {StudentID}, Course ID: {CourseID}, Enrollment Date: {EnrollmentDate}");
        }

        public Student GetStudent()
        {
            return EnrolledStudent;
        }

        public Course GetCourse()
        {
            return EnrolledCourse;
        }
    }
}
