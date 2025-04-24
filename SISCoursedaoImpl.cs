using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SIS1.Data.ICoursedao;
using static SIS1.Data.DBUtility;
using SIS1.Models;
using static SIS1.Models.CourseException;
using SIS1.Data;
using SIS1;

namespace SIS1.Data
{
    internal class SISCoursedaoImpl : ICoursedao
    {
        SqlConnection con = null;
        SqlCommand command = null;

        public int AddCourse(Course course)
        {
            int rowsAffected = 0;
            string query = $"insert into courses1 (course_id, course_name, course_code, instructor_name) values (@cid, @ccoursename, @ccoursecode, @cinstructorname)";
            try
            {
                using (con = DBUtility.GetConnection())
                {
                    command = new SqlCommand(query, con);
                    command.Parameters.Add(new SqlParameter("@cid", course.CourseID));
                    command.Parameters.Add(new SqlParameter("@ccoursename", course.CourseName));
                    command.Parameters.Add(new SqlParameter("@ccoursecode", course.CourseCode));
                    command.Parameters.Add(new SqlParameter("@cinstructorname", course.InstructorName)); ;
                    rowsAffected = command.ExecuteNonQuery();
                }
                if (rowsAffected <= 0)
                {
                    throw new CourseException("Course could not be added!!");
                }
            }
            catch (SqlException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw new Exception("Error in adding a new course.");
            }
            return rowsAffected;
        }

        public int DeleteCourse(int id)
        {
            int rowsAffected = 0;
            string query = "delete from courses1 where course_id = @cid";
            try
            {
                using (con = DBUtility.GetConnection())
                {
                    command = new SqlCommand(query, con);
                    command.Parameters.Add(new SqlParameter("@cid", id));
                    rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected <= 0)
                    {
                        throw new CourseException("Id not found, Couldn't delete course!!");
                    }
                }
            }
            catch (SqlException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw new Exception("Error in deleting a new course.");
            }
            return rowsAffected;
        }

        public List<Course> GetAllCourses()
        {
            List<Course> courses = new List<Course>();
            Course course = null;
            SqlConnection con = null;
            SqlCommand command = null;
            string query = "select * from courses1";

            using (con = DBUtility.GetConnection())
            {
                try
                {
                    command = new SqlCommand(query, con);

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        course = new Course();
                        course.CourseID = reader.GetInt32(0);
                        course.CourseName = reader.GetString(1);
                        course.CourseCode = reader.GetString(2);
                        course.InstructorName = reader.GetString(3);
                        courses.Add(course);
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            return courses;
        }
        public Course GetCourseByCourseName(string name)
        {
            Course course = null;
            SqlConnection con = null;
            SqlCommand command = null;
            string query = "select * from courses1 where course_name = @ccoursename";

            using (con = DBUtility.GetConnection())
            {
                try
                {
                    command = new SqlCommand(query, con);

                    command.Parameters.AddWithValue("@ccoursename", name);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        course = new Course();
                        course.CourseID = reader.GetInt32(0);
                        course.CourseName = reader.GetString(1);
                        course.CourseCode = reader.GetString(2);
                        course.InstructorName = reader.GetString(3);
                    }

                    if (course == null)
                    {
                        throw new StudentException("Course Name not found!!");
                    }
                }
                catch (SqlException e)
                {
                    throw e;
                }
                catch (Exception e)
                {
                    throw new Exception("Error fetching with the given course name: " + e.Message);
                }
            }
            return course;
        }

        public Course GetCourseByCourseCode(int code)
        {
            Course course = null;
            SqlConnection con = null;
            SqlCommand command = null;
            string insertCourseQuery = "select * from courses1 where course_code = @ccoursecode";

            using (con = DBUtility.GetConnection())
            {
                try
                {
                    command = new SqlCommand(insertCourseQuery, con);

                    command.Parameters.AddWithValue("@ccoursecode", code);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        course = new Course();
                        course.CourseID = reader.GetInt32(0);
                        course.CourseName = reader.GetString(1);
                        course.CourseCode = reader.GetString(2);
                        course.InstructorName = reader.GetString(3);
                    }

                    if (course == null)
                    {
                        throw new StudentException("Course Code not found!!");
                    }
                }
                catch (SqlException e)
                {
                    throw e;
                }
                catch (Exception e)
                {
                    throw new Exception("Error fetching with the given course code: " + e.Message);
                }
            }
            return course;
        }

        public Course GetCourseById(int id)
        {
            Course course = null;
            SqlConnection con = null;
            SqlCommand command = null;
            string insertCourseQuery = "select * from courses1 where course_id = @cid";

            using (con = DBUtility.GetConnection())
            {
                try
                {
                    command = new SqlCommand(insertCourseQuery, con);

                    command.Parameters.AddWithValue("@cid", id);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        course = new Course();
                        course.CourseID = reader.GetInt32(0);
                        course.CourseName = reader.GetString(1);
                        course.CourseCode = reader.GetString(2);
                        course.InstructorName = reader.GetString(3);
                    }

                    if (course == null)
                    {
                        throw new StudentException("Course Id not found!!");
                    }
                }
                catch (SqlException e)
                {
                    throw e;
                }
                catch (Exception e)
                {
                    throw new Exception("Error fetching in course with the given course id: " + e.Message);
                }
            }
            return course;
        }

        public int UpdateCourseInstructorName(int id, string new_ciname)
        {
            int rowsAffected = 0;
            Course co = GetCourseById(id);
            if (co == null)
            {
                throw new CourseException($"Course not found for the given course {id}");
            }
            else
            {
                string query = "update courses1 set instructor_name = @cinstructorname where course_id = @cid";
                try
                {
                    using (con = DBUtility.GetConnection())
                    {
                        command = new SqlCommand(query, con);
                        command.Parameters.AddWithValue("@cid", id);
                        command.Parameters.AddWithValue("@cinstructorname", new_ciname);
                        rowsAffected = command.ExecuteNonQuery();
                    }
                }
                catch (SqlException e)
                {
                    throw e;
                }
                return rowsAffected;
            }
        }
    }
}
