namespace SISTestProject1
{
    internal class CourseService
    {
        private List<Course> courses;

        public CourseService()
        {
            courses = new List<Course>();
        }

        public void AddCourse(Course course)
        {
            courses.Add(course);
            Console.WriteLine($"Course {course.CourseName} added successfully.");
        }

        public void UpdateCourseInfo(Course course, string courseName, string courseCode, string instructorName)
        {
            course.CourseName = courseName;
            course.CourseCode = courseCode;
            course.InstructorName = instructorName;

            Console.WriteLine($"Course {course.CourseID} updated successfully.");
        }

        public Course GetCourseById(int courseId)
        {
            return courses.FirstOrDefault(c => c.CourseID == courseId); // Find course by ID
        }

        public Course GetCourseByCode(string courseCode)
        {
            return courses.FirstOrDefault(c => c.CourseCode == courseCode); // Find course by code
        }

        public List<Course> GetAllCourses()
        {
            return courses;
        }

        public void DeleteCourse(int courseId)
        {
            Course course = GetCourseById(courseId);
            if (course != null)
            {
                courses.Remove(course);
                Console.WriteLine($"Course {course.CourseName} deleted successfully.");
            }
            else
            {
                Console.WriteLine($"No course found with ID {courseId}.");
            }
        }
    }
}
