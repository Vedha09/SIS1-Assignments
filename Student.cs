using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS1
{
    internal class Student
    {
        public int studentId;
        public string firstName;
        public string lastName;
        public DateTime dateOfBirth;
        public string email;
        public string phoneNumber;
        public decimal balance;

        public int StudentID { get; set; }
        public Student Student1 { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public decimal Balance { get; set; }

        private List<Course> EnrolledCourses = new List<Course>();
        private List<Payment> PaymentHistory = new List<Payment>();
        private Student student;

        public List<Enrollment> Enrollments { get; set; }
        public List<Payment> Payments { get; set; }
        public Student()
        {
            Enrollments = new List<Enrollment>();
            Payments = new List<Payment>();
        }
        public Student(int studentID, string firstName, string lastName, DateTime dateOfBirth, string email, string phoneNumber)
        {
            StudentID = studentID;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Email = email;
            PhoneNumber = phoneNumber;
            Enrollments = new List<Enrollment>();
            Payments = new List<Payment>();
        }

        public override string ToString()
        {
            return $"ID: {StudentID}, Name: {FirstName} {LastName}, DOB: {DateOfBirth.ToShortDateString()}, Email: {Email}, Phone: {PhoneNumber}";
        }

        public void DisplayStudentInfo()
        {
            Console.WriteLine($"Student ID: {StudentID}, Student Name: {FirstName} {LastName}, Date of Birth: {DateOfBirth}, Email: {Email}, Phone: {PhoneNumber}");
        }

        public void EnrollInCourse(Course course)
        {
            EnrolledCourses.Add(course);
            Console.WriteLine($"Enrolled in: {course.CourseName}");
        }

        public void MakePayment(decimal amount, DateTime paymentDate)
        {
            Payment payment = new Payment(PaymentHistory.Count + 1, student, amount, paymentDate);
            PaymentHistory.Add(payment);
            Console.WriteLine($"Payment recorded: {amount} on {paymentDate.ToShortDateString()}");
        }

        public List<Course> GetEnrolledCourses()
        {
            return EnrolledCourses;
        }

        public List<Payment> GetPaymentHistory()
        {
            return PaymentHistory;
        }
    }
}
