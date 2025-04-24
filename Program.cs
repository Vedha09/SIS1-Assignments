using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Xml.Linq;
using SIS1;
using SIS1.Data;
using SIS1.Models;
using System.Data.SqlClient;
using static System.Console;

class InvalidStudentDataException : ApplicationException
{
    public InvalidStudentDataException(string message) : base(message) { }
}

class InvalidCourseDataException : ApplicationException
{
    public InvalidCourseDataException(string message) : base(message) { }
}

class InvalidEnrollmentDataException : ApplicationException
{
    public InvalidEnrollmentDataException(string message) : base(message) { }
}

class InvalidTeacherDataException : ApplicationException
{
    public InvalidTeacherDataException(string message) : base(message) { }
}

class InsufficientFundsException : ApplicationException
{
    public InsufficientFundsException(string message) : base(message) { }
}
class NullReferenceException : ApplicationException
{
    public NullReferenceException(string message) : base(message) { }
}

/*namespace SIS1
{
    class Program
    {
        static void Main()
        {
            string connectionString = @"Server = VEDHA\SQLEXPRESS; Database = SISDB1; Integrated Security = true; MultipleActiveResultSets = true";

            string firstName = "John";
            string lastName = "Doe";
            DateTime dateOfBirth = DateTime.Parse("1995-08-15");
            string email = "john.doe@example.com";
            string phoneNumber = "123-456-7890";

            string[] courses = { "Introduction to Programming", "Mathematics 101" };

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string insertStudentQuery = @"
                        INSERT INTO students1 (first_name, last_name, date_of_birth, email, phone_number) 
                        OUTPUT INSERTED.student_id 
                        VALUES (@sfirstname, @slastname, @sdateofbirth, @semail, @sphonenumber)";

                    int studentId;
                    using (SqlCommand command = new SqlCommand(insertStudentQuery, connection))
                    {
                        command.Parameters.AddWithValue("@sfirstname", firstName);
                        command.Parameters.AddWithValue("@slastname", lastName);
                        command.Parameters.AddWithValue("@sdateofbirth", dateOfBirth);
                        command.Parameters.AddWithValue("@semail", email);
                        command.Parameters.AddWithValue("@sphonenumber", phoneNumber);

                        studentId = (int)command.ExecuteScalar();
                    }

                    string insertEnrollmentQuery = @"
                        INSERT INTO enrollments1 (student_id, course_name, enrollment_date) 
                        VALUES (@sid, @coursename, @enrollmentdate)";

                    foreach (string course in courses)
                    {
                        using (SqlCommand command = new SqlCommand(insertEnrollmentQuery, connection))
                        {
                            command.Parameters.AddWithValue("@sid", studentId);
                            command.Parameters.AddWithValue("@coursename", course);
                            command.Parameters.AddWithValue("@enrollmentdate", DateTime.Now);
                            command.ExecuteNonQuery();
                        }
                    }
                    Console.WriteLine("Student enrolled successfully!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}*/

/*string connectionString = @"Server = VEDHA\SQLEXPRESS; Database = SISDB1; Integrated Security = true; MultipleActiveResultSets = true";

string teacherName = "Sarah Smith";
string teacherEmail = "sarah.smith@example.com";
string teacherExpertise = "Computer Science";

string courseName = "Advanced Database Management";
string courseCode = "CS302";

try
{
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        connection.Open();

        string insertCourseQuery = "SELECT * FROM courses2 WHERE course_code = @coursecode";
        int courseId;
        using (SqlCommand command = new SqlCommand(insertCourseQuery, connection))
        {
            command.Parameters.AddWithValue("@coursecode", courseCode);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    courseId = reader.GetInt32(0);
                    Console.WriteLine($"Course found: {courseName} with ID {courseId}");
                }
                else
                {
                    throw new Exception("Course not found with the given course code.");
                }
            }
        }

        string checkCourseQuery = @"
            UPDATE courses2 
            SET instructor_name = @teachername, instructor_email = @teacheremail, instructor_expertise = @teacherexpertise 
            WHERE course_code = @coursecode";

        using (SqlCommand command = new SqlCommand(checkCourseQuery, connection))
        {
            command.Parameters.AddWithValue("@teachername", teacherName);
            command.Parameters.AddWithValue("@teacheremail", teacherEmail);
            command.Parameters.AddWithValue("@teacherexpertise", teacherExpertise);
            command.Parameters.AddWithValue("@coursecode", courseCode);

            int rowsAffected = command.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                Console.WriteLine("Teacher assigned successfully!");
            }
            else
            {
                throw new Exception("Failed to assign teacher to the course.");
            }
        }
    }
}
catch (Exception ex)
{
    Console.WriteLine("An error occurred: " + ex.Message);
}
}
}
}*/

/*string connectionString = @"Server = VEDHA\SQLEXPRESS; Database = SISDB1; Integrated Security = true; MultipleActiveResultSets = true";

int studentId = 101;
decimal paymentAmount = 500.00m;
DateTime paymentDate = DateTime.Parse("2023-04-10");

try
{
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        connection.Open();

        string insertStudentQuery = "SELECT balance FROM students2 WHERE student_id = @sid";
        decimal currentBalance;

        using (SqlCommand command = new SqlCommand(insertStudentQuery, connection))
        {
            command.Parameters.AddWithValue("@sid", studentId);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    currentBalance = reader.GetDecimal(0);
                    Console.WriteLine($"Current Balance: {currentBalance}");
                }
                else
                {
                    throw new Exception("Student record not found for the given Student ID.");
                }
            }
        }

        string insertPaymentQuery = @"
            INSERT INTO payments1 (student_id, payment_amount, payment_date) 
            VALUES (@sid, @paymentamount, @paymentdate)";

        using (SqlCommand command = new SqlCommand(insertPaymentQuery, connection))
        {
            command.Parameters.AddWithValue("@sid", studentId);
            command.Parameters.AddWithValue("@paymentamount", paymentAmount);
            command.Parameters.AddWithValue("@paymentdate", paymentDate);

            int rowsAffected = command.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                Console.WriteLine("Payment recorded successfully!");
            }
            else
            {
                throw new Exception("Failed to record payment.");
            }
        }

        decimal updatedBalance = currentBalance - paymentAmount;
        string updateBalanceQuery = @"
            UPDATE students2 
            SET balance = @updatedbalance 
            WHERE student_id = @sid";

        using (SqlCommand command = new SqlCommand(updateBalanceQuery, connection))
        {
            command.Parameters.AddWithValue("@updatedbalance", updatedBalance);
            command.Parameters.AddWithValue("@sid", studentId);

            int rowsAffected = command.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                Console.WriteLine($"Balance updated successfully! New Balance: {updatedBalance}");
            }
            else
            {
                throw new Exception("Failed to update student balance.");
            }
        }
    }
}
catch (Exception ex)
{
    Console.WriteLine("An error occurred: " + ex.Message);
}
}
}
}
/*string connectionString = @"Server = VEDHA\SQLEXPRESS; Database = SISDB1; Integrated Security = true; MultipleActiveResultSets = true";

string courseName = "Computer Science 101";

try
{
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        connection.Open();

        string insertEnrollmentsQuery = @"
            SELECT s.student_id, s.first_name, s.last_name, e.course_name
            FROM students3 s
            INNER JOIN enrollments2 e ON s.student_id = e.student_id
            WHERE e.course_name = @coursename";

        List<string> report = new List<string>();

        using (SqlCommand command = new SqlCommand(insertEnrollmentsQuery, connection))
        {
            command.Parameters.AddWithValue("@coursename", courseName);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                Console.WriteLine($"Enrollment Report for Course: {courseName}\n");

                while (reader.Read())
                {
                    int studentId = reader.GetInt32(0);
                    string firstName = reader.GetString(1);
                    string lastName = reader.GetString(2);

                    string reportEntry = $"{studentId} | {firstName} | {lastName}";
                    report.Add(reportEntry);

                    Console.WriteLine(reportEntry);
                }
            }
        }
        string filePath = @"Enrollment_Report.txt";
        System.IO.File.WriteAllLines(filePath, report);
        Console.WriteLine($"\nReport saved to: {filePath}");
    }
}
catch (Exception ex)
{
    Console.WriteLine("An error occurred: " + ex.Message);
}
}
}
}*/

/*namespace SIS1
{
    class Program
    {
        static void Main()
        {
            SISStudentdaoImpl dao = new SISStudentdaoImpl();
            bool input = true;

            while (input)
            {
                Console.WriteLine("\n--- Student Management System ---");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Get Student by ID");
                Console.WriteLine("3. Get All Students");
                Console.WriteLine("4. Update Student Name");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");

                int choice;
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            {
                                Student student = new Student
                                {
                                    StudentID = GetInputInt("Enter Student ID: "),
                                    FirstName = GetInputString("Enter First Name: "),
                                    LastName = GetInputString("Enter Last Name: "),
                                    DateOfBirth = GetInputDate("Enter Date of Birth (yyyy-mm-dd): "),
                                    Email = GetInputString("Enter Email: "),
                                    PhoneNumber = GetInputString("Enter Phone Number: ")
                                };

                                dao.AddStudent(student);
                                Console.WriteLine("Student added successfully.");
                                break;
                            }
                        case 2:
                            {
                                int id = GetInputInt("Enter Student ID to retrieve: ");
                                var student = dao.GetStudentById(id);
                                Console.WriteLine(student != null ? student.ToString() : "Student not found.");
                                break;
                            }
                        case 3:
                            {
                                var students = dao.GetAllStudents();
                                Console.WriteLine("--- All Students ---");
                                if (students.Count > 0)
                                {
                                    foreach (var student in students)
                                    {
                                        Console.WriteLine(student);
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("No students found.");
                                }
                                break;
                            }
                        case 4:
                            {
                                int id = GetInputInt("Enter Student ID to update: ");
                                string newName = GetInputString("Enter new First Name: ");
                                int result = dao.UpdateStudentName(id, newName);
                                Console.WriteLine(result > 0 ? "Student name updated successfully." : "Student not found.");
                                break;
                            }
                        case 5:
                            {
                                input = false;
                                Console.WriteLine("Exiting!!");
                                break;
                            }
                        default:
                            Console.WriteLine("Invalid choice.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input.");
                }
            }
        }

        static int GetInputInt(string p)
        {
            Console.Write(p);
            return int.Parse(Console.ReadLine());
        }

        static string GetInputString(string p)
        {
            Console.Write(p);
            return Console.ReadLine();
        }

        static DateTime GetInputDate(string p)
        {
            Console.Write(p);
            return DateTime.Parse(Console.ReadLine());
        }
    }
}*/

namespace SIS1
{
    public class Student1
    {
        public int StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public override string ToString()
        {
            return $"ID: {StudentID}, Name: {FirstName} {LastName}, DOB: {DateOfBirth.ToShortDateString()}, Email: {Email}, Phone: {PhoneNumber}";
        }
    }

    public interface ISISDao1
    {
        Student1 GetStudentById(int studentId);
        Student1 GetStudentByFirstName(string firstName);
        Student1 GetStudentByLastName(string lastName);
        int UpdateStudentName(int studentId, string firstName);
        void AddStudent(Student1 student);
        List<Student1> GetAllStudents();
    }

    public class SISDaoImpl : ISISDao1
    {
        private readonly List<Student1> students = new List<Student1>();

        public void AddStudent(Student1 student)
        {
            students.Add(student);
        }

        public List<Student1> GetAllStudents()
        {
            return students;
        }

        public Student1 GetStudentById(int studentId)
        {
            return students.FirstOrDefault(s => s.StudentID == studentId);
        }

        public Student1 GetStudentByFirstName(string firstName)
        {
            return students.FirstOrDefault(s => s.FirstName.Equals(firstName, StringComparison.OrdinalIgnoreCase));
        }

        public Student1 GetStudentByLastName(string lastName)
        {
            return students.FirstOrDefault(s => s.LastName.Equals(lastName, StringComparison.OrdinalIgnoreCase));
        }

        public int UpdateStudentName(int studentId, string firstName)
        {
            Student1 student = students.FirstOrDefault(s => s.StudentID == studentId);
            if (student != null)
            {
                student.FirstName = firstName;
                return 1;
            }
            return 0;
        }
    }

    class Program
    {
        static void Main()
        {
            SISDaoImpl SISdaoUtil = new SISDaoImpl();
            UserInteface ui = new UserInteface();

            try
            {
                WriteLine("Enter the Student Id: ");
                int id = ui.GetStudentId();

                Student1 s = new Student1();
                s.StudentID = id;
                s.FirstName = ui.GetStudentFirstName();
                s.LastName = ui.GetStudentLastName();
                s.DateOfBirth = ui.GetStudentDateOfBirth();
                s.Email = ui.GetStudentByEmail();
                s.PhoneNumber = ui.GetStudentPhoneNumber();

                WriteLine("Enter the Student FirstName to search: ");
                string firstname = ReadLine();
                Student1 s1 = SISdaoUtil.GetStudentByFirstName(firstname);
                WriteLine(s1);

                WriteLine("Enter the Student LastName to search: ");
                string lastname = ReadLine();
                Student1 s2 = SISdaoUtil.GetStudentByLastName(lastname);
                WriteLine(s2);
                WriteLine();

                WriteLine("Enter the Student Id to update name: ");
                int id1 = ui.GetStudentId();
                string firstName = ui.GetStudentFirstName();
                int result = SISdaoUtil.UpdateStudentName(id1, firstName);
                WriteLine($"Update Result: {result}");
                WriteLine("The Updated Student Name: " + SISdaoUtil.GetStudentById(id1));

                Student1 s3 = new Student1();
                s3.StudentID = ui.GetStudentId();
                s3.FirstName = ui.GetStudentFirstName();
                s3.LastName = ui.GetStudentLastName();
                s3.DateOfBirth = ui.GetStudentDateOfBirth();
                s3.Email = ui.GetStudentByEmail();
                s3.PhoneNumber = ui.GetStudentPhoneNumber();
                SISdaoUtil.AddStudent(s3);

                //GetStudentByID
                WriteLine("Enter the Student Id to retrieve: ");
                int id2 = ui.GetStudentId();
                Student1 s4 = SISdaoUtil.GetStudentById(id2);
                WriteLine(s4);

                //GetAllStudents
                WriteLine("-------------------------Student List-------------------------");
                List<Student1> studentList = SISdaoUtil.GetAllStudents();
                Display(studentList);
            }

            catch (Exception e)
            {
                WriteLine($"An error occurred: {e.Message}");
            }
        }

        static void Display(List<Student1> studentList)
        {
            if (studentList != null && studentList.Count > 0)
            {
                foreach (Student1 student in studentList)
                {
                    WriteLine(student);
                }
            }
            else
            {
                WriteLine("No students found in the list.");
            }
        }
    }
}

/*namespace SIS1
{
    public class Course1
    {
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public int CourseCode { get; set; }
        public string InstructorName { get; set; }

        public override string ToString()
        {
            return $"ID: {CourseID}, Name: {CourseName}, Code: {CourseCode}, Instructor: {InstructorName}";
        }
    }

    public interface ICourseDao1
    {
        Course1 GetCourseById(int courseId);
        Course1 GetCourseByName(string courseName);
        Course1 GetCourseByCode(int courseCode);
        int UpdateCourseInstructor(int courseId, string instructorName);
        void AddCourse(Course1 course);
        List<Course1> GetAllCourses();
    }

    public class CourseDaoImpl : ICourseDao1
    {
        private readonly List<Course1> courses = new List<Course1>();

        public void AddCourse(Course1 course)
        {
            courses.Add(course);
        }

        public List<Course1> GetAllCourses()
        {
            return courses;
        }

        public Course1 GetCourseById(int courseId)
        {
            return courses.FirstOrDefault(c => c.CourseID == courseId);
        }

        public Course1 GetCourseByName(string courseName)
        {
            return courses.FirstOrDefault(c => c.CourseName.Equals(courseName, StringComparison.OrdinalIgnoreCase));
        }

        public Course1 GetCourseByCode(int courseCode)
        {
            return courses.FirstOrDefault(c => c.CourseCode == courseCode);
        }

        public int UpdateCourseInstructor(int courseId, string instructorName)
        {
            Course1 course = courses.FirstOrDefault(c => c.CourseID == courseId);
            if (course != null)
            {
                course.InstructorName = instructorName;
                return 1;
            }
            return 0;
        }
    }

    public class CourseUserInterface
    {
        public int GetCourseId()
        {
            WriteLine("Enter the Course Id: ");
            if (int.TryParse(ReadLine(), out int id))
            {
                return id;
            }
            WriteLine("Invalid Course ID. Please enter a number.");
            return GetCourseId();
        }

        public string GetCourseName()
        {
            WriteLine("Enter the Course Name: ");
            return ReadLine();
        }

        public int GetCourseCode()
        {
            WriteLine("Enter the Course Code: ");
            if (int.TryParse(ReadLine(), out int code))
            {
                return code;
            }
            WriteLine("Invalid Course Code. Please enter a number.");
            return GetCourseCode();
        }

        public string GetCourseInstructorName()
        {
            WriteLine("Enter the Instructor Name: ");
            return ReadLine();
        }
    }

    class Program
    {
        static void Main()
        {
            CourseDaoImpl courseDaoUtil = new CourseDaoImpl();
            CourseUserInterface cui = new CourseUserInterface();

            try
            {
                WriteLine("Enter the Course Id: ");
                int id = cui.GetCourseId();

                Course1 c = new Course1();
                c.CourseID = id;
                c.CourseName = cui.GetCourseName();
                c.CourseCode = cui.GetCourseCode();
                c.InstructorName = cui.GetCourseInstructorName();

                WriteLine("Enter the Course Name to search: ");
                string courseName = ReadLine();
                Course1 c1 = courseDaoUtil.GetCourseByName(courseName);
                WriteLine(c1);

                WriteLine("Enter the Course Code to search: ");
                int courseCode = int.Parse(ReadLine());
                Course1 c2 = courseDaoUtil.GetCourseByCode(courseCode);
                WriteLine(c2);
                WriteLine();

                WriteLine("Enter the Course Id to update instructor: ");
                int id1 = cui.GetCourseId();
                string instructorName = cui.GetCourseInstructorName();
                int result = courseDaoUtil.UpdateCourseInstructor(id1, instructorName);
                WriteLine($"Update Result: {result}");
                WriteLine("The Updated Course Instructor: " + courseDaoUtil.GetCourseById(id1));

                Course1 c3 = new Course1();
                c3.CourseID = cui.GetCourseId();
                c3.CourseName = cui.GetCourseName();
                c3.CourseCode = cui.GetCourseCode();
                c3.InstructorName = cui.GetCourseInstructorName();
                courseDaoUtil.AddCourse(c3);

                //GetCourseByID
                WriteLine("Enter the Course Id to retrieve: ");
                int id2 = cui.GetCourseId();
                Course1 c4 = courseDaoUtil.GetCourseById(id2);
                WriteLine(c4);

                //GetAllCourses
                WriteLine("-------------------------Course List-------------------------");
                List<Course1> courseList = courseDaoUtil.GetAllCourses();
                DisplayCourses(courseList);
            }

            catch (Exception e)
            {
                WriteLine($"An error occurred: {e.Message}");
            }
        }

        static void DisplayCourses(List<Course1> courseList)
        {
            if (courseList != null && courseList.Count > 0)
            {
                foreach (Course1 course in courseList)
                {
                    WriteLine(course);
                }
            }
            else
            {
                WriteLine("No courses found in the list.");
            }
        }
    }
}*/

/*namespace SIS1
{
    public class Enrollment1
    {
        public int EnrollmentID { get; set; }
        public int StudentID { get; set; }
        public int CourseID { get; set; }
        public DateTime EnrollmentDate { get; set; }

        public override string ToString()
        {
            return $"Enrollment ID: {EnrollmentID}, Student ID: {StudentID}, Course ID: {CourseID}, Date: {EnrollmentDate.ToShortDateString()}";
        }
    }

    public interface IEnrollmentDao1
    {
        Enrollment1 GetEnrollmentById(int enrollmentId);
        List<Enrollment1> GetEnrollmentsByStudentId(int studentId);
        List<Enrollment1> GetEnrollmentsByCourseId(int courseId);
        void AddEnrollment(Enrollment1 enrollment);
        List<Enrollment1> GetAllEnrollments();
    }

    public class EnrollmentDaoImpl : IEnrollmentDao1
    {
        private readonly List<Enrollment1> enrollments = new List<Enrollment1>();

        public void AddEnrollment(Enrollment1 enrollment)
        {
            enrollments.Add(enrollment);
        }

        public List<Enrollment1> GetAllEnrollments()
        {
            return enrollments;
        }

        public Enrollment1 GetEnrollmentById(int enrollmentId)
        {
            return enrollments.FirstOrDefault(e => e.EnrollmentID == enrollmentId);
        }

        public List<Enrollment1> GetEnrollmentsByStudentId(int studentId)
        {
            return enrollments.Where(e => e.StudentID == studentId).ToList();
        }

        public List<Enrollment1> GetEnrollmentsByCourseId(int courseId)
        {
            return enrollments.Where(e => e.CourseID == courseId).ToList();
        }
    }

    public class EnrollmentUserInterface
    {
        public int GetEnrollmentId()
        {
            WriteLine("Enter the Enrollment Id: ");
            if (int.TryParse(ReadLine(), out int id))
            {
                return id;
            }
            WriteLine("Invalid Enrollment ID. Please enter a number.");
            return GetEnrollmentId();
        }

        public int GetStudentIdForEnrollment()
        {
            WriteLine("Enter the Student Id for Enrollment: ");
            if (int.TryParse(ReadLine(), out int id))
            {
                return id;
            }
            WriteLine("Invalid Student ID. Please enter a number.");
            return GetStudentIdForEnrollment();
        }

        public int GetCourseIdForEnrollment()
        {
            WriteLine("Enter the Course Id for Enrollment: ");
            if (int.TryParse(ReadLine(), out int id))
            {
                return id;
            }
            WriteLine("Invalid Course ID. Please enter a number.");
            return GetCourseIdForEnrollment();
        }

        public DateTime GetEnrollmentDate()
        {
            WriteLine("Enter the Enrollment Date (yyyy-mm-dd):");
            if (DateTime.TryParse(ReadLine(), out DateTime date))
            {
                return date;
            }
            WriteLine("Invalid date format. Please use yyyy-mm-dd.");
            return GetEnrollmentDate();
        }
    }

    class Program
    {
        static void Main()
        {
            EnrollmentDaoImpl enrollmentDaoUtil = new EnrollmentDaoImpl();
            EnrollmentUserInterface eui = new EnrollmentUserInterface();

            try
            {
                WriteLine("Enter the Enrollment Id: ");
                int id = eui.GetEnrollmentId();

                Enrollment1 e = new Enrollment1();
                e.EnrollmentID = id;
                e.StudentID = eui.GetStudentIdForEnrollment();
                e.CourseID = eui.GetCourseIdForEnrollment();
                e.EnrollmentDate = eui.GetEnrollmentDate();

                WriteLine("Enter the Student Id to search enrollments: ");
                int studentId = eui.GetStudentIdForEnrollment();
                List<Enrollment1> enrollmentsByStudent = enrollmentDaoUtil.GetEnrollmentsByStudentId(studentId);
                DisplayEnrollments(enrollmentsByStudent);

                WriteLine("Enter the Course Id to search enrollments: ");
                int courseId = eui.GetCourseIdForEnrollment();
                List<Enrollment1> enrollmentsByCourse = enrollmentDaoUtil.GetEnrollmentsByCourseId(courseId);
                DisplayEnrollments(enrollmentsByCourse);
                WriteLine();

                Enrollment1 e3 = new Enrollment1();
                e3.EnrollmentID = eui.GetEnrollmentId();
                e3.StudentID = eui.GetStudentIdForEnrollment();
                e3.CourseID = eui.GetCourseIdForEnrollment();
                e3.EnrollmentDate = eui.GetEnrollmentDate();
                enrollmentDaoUtil.AddEnrollment(e3);

                //GetEnrollmentByID
                WriteLine("Enter the Enrollment Id to retrieve: ");
                int id2 = eui.GetEnrollmentId();
                Enrollment1 e4 = enrollmentDaoUtil.GetEnrollmentById(id2);
                WriteLine(e4);

                //GetAllEnrollments
                WriteLine("-------------------------Enrollment List-------------------------");
                List<Enrollment1> enrollmentList = enrollmentDaoUtil.GetAllEnrollments();
                DisplayEnrollments(enrollmentList);
            }

            catch (Exception ex)
            {
                WriteLine($"An error occurred: {ex.Message}");
            }
        }

        static void DisplayEnrollments(List<Enrollment1> enrollmentList)
        {
            if (enrollmentList != null && enrollmentList.Count > 0)
            {
                foreach (Enrollment1 enrollment in enrollmentList)
                {
                    WriteLine(enrollment);
                }
            }
            else
            {
                WriteLine("No enrollments found in the list.");
            }
        }
    }
}*/

/*namespace SIS1
{
    public class Teacher1
    {
        public int TeacherID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Expertise { get; set; }

        public override string ToString()
        {
            return $"ID: {TeacherID}, Name: {FirstName} {LastName}, Email: {Email}, Expertise: {Expertise}";
        }
    }

    public interface ITeacherDao1
    {
        Teacher1 GetTeacherById(int teacherId);
        Teacher1 GetTeacherByFirstName(string firstName);
        Teacher1 GetTeacherByLastName(string lastName);
        Teacher1 GetTeacherByEmail(string email);
        int UpdateTeacherExpertise(int teacherId, string expertise);
        void AddTeacher(Teacher1 teacher);
        List<Teacher1> GetAllTeachers();
    }

    public class TeacherDaoImpl : ITeacherDao1
    {
        private readonly List<Teacher1> teachers = new List<Teacher1>();

        public void AddTeacher(Teacher1 teacher)
        {
            teachers.Add(teacher);
        }

        public List<Teacher1> GetAllTeachers()
        {
            return teachers;
        }

        public Teacher1 GetTeacherById(int teacherId)
        {
            return teachers.FirstOrDefault(t => t.TeacherID == teacherId);
        }

        public Teacher1 GetTeacherByFirstName(string firstName)
        {
            return teachers.FirstOrDefault(t => t.FirstName.Equals(firstName, StringComparison.OrdinalIgnoreCase));
        }

        public Teacher1 GetTeacherByLastName(string lastName)
        {
            return teachers.FirstOrDefault(t => t.LastName.Equals(lastName, StringComparison.OrdinalIgnoreCase));
        }

        public Teacher1 GetTeacherByEmail(string email)
        {
            return teachers.FirstOrDefault(t => t.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
        }

        public int UpdateTeacherExpertise(int teacherId, string expertise)
        {
            Teacher1 teacher = teachers.FirstOrDefault(t => t.TeacherID == teacherId);
            if (teacher != null)
            {
                teacher.Expertise = expertise;
                return 1;
            }
            return 0;
        }
    }

    public class TeacherUserInterface
    {
        public int GetTeacherId()
        {
            WriteLine("Enter the Teacher Id: ");
            if (int.TryParse(ReadLine(), out int id))
            {
                return id;
            }
            WriteLine("Invalid Teacher ID.");
            return GetTeacherId();
        }

        public string GetTeacherFirstName()
        {
            WriteLine("Enter Teacher First Name:");
            return ReadLine();
        }

        public string GetTeacherLastName()
        {
            WriteLine("Enter Teacher Last Name:");
            return ReadLine();
        }

        public string GetTeacherEmail()
        {
            WriteLine("Enter Teacher Email:");
            return ReadLine();
        }

        public string GetExpertise()
        {
            WriteLine("Enter Teacher Expertise:");
            return ReadLine();
        }
    }

    class Program
    {
        static void Main()
        {
            TeacherDaoImpl teacherDaoUtil = new TeacherDaoImpl();
            TeacherUserInterface tui = new TeacherUserInterface();

            try
            {
                WriteLine("Enter the Teacher Id: ");
                int id = tui.GetTeacherId();

                Teacher1 t = new Teacher1();
                t.TeacherID = id;
                t.FirstName = tui.GetTeacherFirstName();
                t.LastName = tui.GetTeacherLastName();
                t.Email = tui.GetTeacherEmail();
                t.Expertise = tui.GetExpertise();

                WriteLine("Enter the Teacher FirstName to search: ");
                string firstname = ReadLine();
                Teacher1 t1 = teacherDaoUtil.GetTeacherByFirstName(firstname);
                WriteLine(t1);

                WriteLine("Enter the Teacher LastName to search: ");
                string lastname = ReadLine();
                Teacher1 t2 = teacherDaoUtil.GetTeacherByLastName(lastname);
                WriteLine(t2);

                WriteLine("Enter the Teacher Email to search: ");
                string email = ReadLine();
                Teacher1 t3 = teacherDaoUtil.GetTeacherByEmail(email);
                WriteLine(t3);
                WriteLine();

                WriteLine("Enter the Teacher Id to update expertise: ");
                int id1 = tui.GetTeacherId();
                string expertise = tui.GetExpertise();
                int result = teacherDaoUtil.UpdateTeacherExpertise(id1, expertise);
                WriteLine($"Update Result: {result}");
                WriteLine("The Updated Teacher Expertise: " + teacherDaoUtil.GetTeacherById(id1));

                Teacher1 t4 = new Teacher1();
                t4.TeacherID = tui.GetTeacherId();
                t4.FirstName = tui.GetTeacherFirstName();
                t4.LastName = tui.GetTeacherLastName();
                t4.Email = tui.GetTeacherEmail();
                t4.Expertise = tui.GetExpertise();
                teacherDaoUtil.AddTeacher(t4);

                //GetTeacherByID
                WriteLine("Enter the Teacher Id to retrieve: ");
                int id2 = tui.GetTeacherId();
                Teacher1 t5 = teacherDaoUtil.GetTeacherById(id2);
                WriteLine(t5);

                //GetAllTeachers
                WriteLine("-------------------------Teacher List-------------------------");
                List<Teacher1> teacherList = teacherDaoUtil.GetAllTeachers();
                DisplayTeachers(teacherList);
            }

            catch (Exception e)
            {
                WriteLine($"An error occurred: {e.Message}");
            }
        }

        static void DisplayTeachers(List<Teacher1> teacherList)
        {
            if (teacherList != null && teacherList.Count > 0)
            {
                foreach (Teacher1 teacher in teacherList)
                {
                    WriteLine(teacher);
                }
            }
            else
            {
                WriteLine("No teachers found in the list.");
            }
        }
    }
}*/

/*namespace SIS1
{
    public class Payment1
    {
        public int PaymentID { get; set; }
        public int StudentID { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }

        public override string ToString()
        {
            return $"Payment ID: {PaymentID}, Student ID: {StudentID}, Amount: {Amount}, Date: {PaymentDate.ToShortDateString()}";
        }
    }

    public interface IPaymentDao1
    {
        Payment1 GetPaymentById(int paymentId);
        List<Payment1> GetPaymentsByStudentId(int studentId);
        void AddPayment(Payment1 payment);
        List<Payment1> GetAllPayments();
    }

    public class PaymentDaoImpl : IPaymentDao1
    {
        private readonly List<Payment1> payments = new List<Payment1>();

        public void AddPayment(Payment1 payment)
        {
            payments.Add(payment);
        }

        public List<Payment1> GetAllPayments()
        {
            return payments;
        }

        public Payment1 GetPaymentById(int paymentId)
        {
            return payments.FirstOrDefault(p => p.PaymentID == paymentId);
        }

        public List<Payment1> GetPaymentsByStudentId(int studentId)
        {
            return payments.Where(p => p.StudentID == studentId).ToList();
        }
    }

    public class PaymentUserInterface
    {
        public int GetPaymentId()
        {
            WriteLine("Enter the Payment Id: ");
            if (int.TryParse(ReadLine(), out int id))
            {
                return id;
            }
            WriteLine("Invalid Payment ID.");
            return GetPaymentId();
        }

        public int GetStudentIdForPayment()
        {
            WriteLine("Enter the Student Id for Payment: ");
            if (int.TryParse(ReadLine(), out int id))
            {
                return id;
            }
            WriteLine("Invalid Student ID.");
            return GetStudentIdForPayment();
        }

        public decimal GetAmount()
        {
            WriteLine("Enter the Payment Amount: ");
            if (decimal.TryParse(ReadLine(), out decimal amount))
            {
                return amount;
            }
            WriteLine("Invalid amount format.");
            return GetAmount();
        }

        public DateTime GetPaymentDate()
        {
            WriteLine("Enter the Payment Date:");
            if (DateTime.TryParse(ReadLine(), out DateTime date))
            {
                return date;
            }
            WriteLine("Invalid date format.");
            return GetPaymentDate();
        }
    }

    class Program
    {
        static void Main()
        {
            PaymentDaoImpl paymentDaoUtil = new PaymentDaoImpl();
            PaymentUserInterface pui = new PaymentUserInterface();

            try
            {
                WriteLine("Enter the Payment Id: ");
                int id = pui.GetPaymentId();

                Payment p = new Payment();
                p.PaymentID = id;
                p.StudentID = pui.GetStudentIdForPayment();
                p.Amount = pui.GetAmount();
                p.PaymentDate = pui.GetPaymentDate();

                WriteLine("Enter the Student Id to search payments: ");
                int studentId = pui.GetStudentIdForPayment();
                List<Payment1> paymentsByStudent = paymentDaoUtil.GetPaymentsByStudentId(studentId);
                DisplayPayments(paymentsByStudent);
                WriteLine();

                Payment1 p3 = new Payment1();
                p3.PaymentID = pui.GetPaymentId();
                p3.StudentID = pui.GetStudentIdForPayment();
                p3.Amount = pui.GetAmount();
                p3.PaymentDate = pui.GetPaymentDate();
                paymentDaoUtil.AddPayment(p3);

                //GetPaymentByID
                WriteLine("Enter the Payment Id to retrieve: ");
                int id2 = pui.GetPaymentId();
                Payment1 p4 = paymentDaoUtil.GetPaymentById(id2);
                WriteLine(p4);

                //GetAllPayments
                WriteLine("-------------------------Payment List-------------------------");
                List<Payment1> paymentList = paymentDaoUtil.GetAllPayments();
                DisplayPayments(paymentList);
            }

            catch (Exception ex)
            {
                WriteLine($"An error occurred: {ex.Message}");
            }
        }

        static void DisplayPayments(List<Payment1> paymentList)
        {
            if (paymentList != null && paymentList.Count > 0)
            {
                foreach (Payment1 payment in paymentList)
                {
                    WriteLine(payment);
                }
            }
            else
            {
                WriteLine("No payments found in the list.");
            }
        }
    }
}
*/