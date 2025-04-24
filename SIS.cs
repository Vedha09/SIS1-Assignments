using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SIS1
{
    internal class SIS
    {
        public List<Student> students = new List<Student>();
        public List<Course> courses = new List<Course>();
        public List<Teacher> teachers = new List<Teacher>();
        public List<Enrollment> enrollments = new List<Enrollment>();
        public List<Payment> payments = new List<Payment>();
        
        public void AddStudent(Student student)
        {
            students.Add(student);
        }
        public void AddCourse(Course course)
        {
            courses.Add(course);
        }
        public void AddTeacher(Teacher teacher)
        {
            teachers.Add(teacher);
        }

        public void AddEnrollment(Student student, Course course, DateTime enrollmentDate)
        {
            Enrollment enrollment = new Enrollment(student.Enrollments.Count + 1, student, course, enrollmentDate);
            student.Enrollments.Add(enrollment);
            course.Enrollments.Add(enrollment);
            Console.WriteLine($"Enrollment added: {student.FirstName} {student.LastName} enrolled in {course.CourseName}");
        }
        public void AssignCourseToTeacher(Course course, Teacher teacher)
        {
            teacher.AssignedCourses.Add(course);
        }

        public void AddPayment(Student student, decimal amount, DateTime paymentDate)
        {
            Payment payment = new Payment(student.Payments.Count + 1, student, amount, paymentDate);
            student.Payments.Add(payment);
            Console.WriteLine($"Payment added: {amount} paid by {student.FirstName} {student.LastName}");
        }
        public List<Enrollment> GetEnrollmentsForStudent(Student student)
        {
            return student.Enrollments;
        }
        public List<Course> GetCoursesForTeacher(Teacher teacher)
        {
            return teacher.AssignedCourses;
        }
    }
}
