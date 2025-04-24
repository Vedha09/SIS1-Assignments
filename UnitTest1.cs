using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SISTestProject1;

namespace SISTestProject1
{

    /*[TestFixture]
    public class TestStudentService1
    {
        private StudentService studentService;
        private Student testStudent;
        private SISStudentdaoImpl studentDao;

        [SetUp]
        public void Setup()
        {
            studentService = new StudentService();
            studentDao = new SISStudentdaoImpl();
            testStudent = new Student(1, "Test", "Student", DateTime.Now.AddYears(-20), "test@student.com", "1234567890");
        }

        [Test]
        public void AddStudent_AddsStudentSuccessfully()
        {
            // Arrange
            var newStudent = new Student
            {
                FirstName = "New",
                LastName = "Student",
                DateOfBirth = DateTime.Now,
                Email = "new@student.com",
                PhoneNumber = "9876543210"
            };

            // Act
            studentDao.AddStudent(newStudent);

            // Assert
            Student addedStudent = studentDao.GetStudentByEmail("new@student.com");
            Assert.IsNotNull(addedStudent);
            Assert.AreEqual("New", addedStudent.FirstName);
            Assert.AreEqual("Student", addedStudent.LastName);
        }

        [Test]
        public void UpdateStudentInfoUpdatesCorrectProperties()
        {
            // Arrange
            string newFirstName = "Updated";
            string newLastName = "Name";

            // Act
            studentService.UpdateStudentInfo(testStudent, newFirstName, newLastName, testStudent.DateOfBirth, testStudent.Email, testStudent.PhoneNumber);

            // Assert
            Assert.AreEqual(newFirstName, testStudent.FirstName);
            Assert.AreEqual(newLastName, testStudent.LastName);
        }

        [Test]
        public void UpdateStudentInfo_WithInvalidEmail_ThrowsException()
        {
            // Arrange
            string invalidEmail = "invalid-email";

            // Act & Assert
            Assert.Throws<StudentException>(() =>
                studentService.UpdateStudentInfo(testStudent, testStudent.FirstName, testStudent.LastName, testStudent.DateOfBirth, invalidEmail, testStudent.PhoneNumber)
            );
        }
    }
}*/


    [TestFixture]
    public class TestCourseService1
    {
        private CourseService courseService;
        private Course testCourse;
        private SISCoursedaoImpl courseDao;

        [SetUp]
        public void Setup()
        {
            courseService = new CourseService();
            courseDao = new SISCoursedaoImpl();
            testCourse = new Course(101, "Introduction to Programming", "CS101", "Dr. Smith");
            courseService.AddCourse(testCourse);
        }

        [Test]
        public void UpdateCourseInfoUpdatesCorrectProperties()
        {
            // Arrange
            string newCourseName = "Advanced Programming";
            string newCourseCode = "CS102";
            string newInstructorName = "Dr. Sarah Smith";

            // Act
            courseService.UpdateCourseInfo(testCourse, newCourseName, newCourseCode, newInstructorName);

            // Assert
            Assert.AreEqual(newCourseName, testCourse.CourseName);
            Assert.AreEqual(newCourseCode, testCourse.CourseCode);
            Assert.AreEqual(newInstructorName, testCourse.InstructorName);
        }
    }
}
