using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SIS1.Data.IEnrollmentdao;
using static SIS1.Data.DBUtility;
using SIS1.Models;
using static SIS1.Models.EnrollmentException;
using SIS1.Data;
using SIS1;

namespace SIS1.Data
{
    internal class SISEnrollmentdaoImpl : IEnrollmentdao
    {
        SqlConnection con = null;
        SqlCommand command = null;

        public int AddEnrollment(Enrollment enrollment)
        {
            int rowsAffected = 0;
            string insertEnrollmentQuery = $"insert into enrollments (enrollment_id, student_id, course_id, enrollment_date) values (@eid, @sid, @cid, @eenrollmentdate)";
            try
            {
                using (con = DBUtility.GetConnection())
                {
                    command = new SqlCommand(insertEnrollmentQuery, con);
                    command.Parameters.Add(new SqlParameter("@eid", enrollment.EnrollmentID));
                    command.Parameters.Add(new SqlParameter("@sid", enrollment.StudentID));
                    command.Parameters.Add(new SqlParameter("@cid", enrollment.CourseID));
                    command.Parameters.Add(new SqlParameter("@eenrollmentdate", enrollment.EnrollmentDate));
                    rowsAffected = command.ExecuteNonQuery();
                }
                if (rowsAffected <= 0)
                {
                    throw new EnrollmentException("Enrollment could not be added!!");
                }
            }
            catch (SqlException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw new Exception("Error in adding a new enrollment.");
            }
            return rowsAffected;
        }

        public int DeleteEnrollment(int id)
        {
            int rowsAffected = 0;
            string insertEnrollmentQuery = "delete from enrollments where enrollment_id = @eid";
            try
            {
                using (con = DBUtility.GetConnection())
                {
                    command = new SqlCommand(insertEnrollmentQuery, con);
                    command.Parameters.Add(new SqlParameter("@eid", id));
                    rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected <= 0)
                    {
                        throw new EnrollmentException("Id not found, Couldn't delete enrollment!!");
                    }
                }
            }
            catch (SqlException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw new Exception("Error in deleting a new enrollment.");
            }
            return rowsAffected;
        }

        public List<Enrollment> GetAllEnrollments()
        {
            List<Enrollment> enrollments = new List<Enrollment>();
            Enrollment enrollment = null;
            SqlConnection con = null;
            SqlCommand command = null;
            string insertEnrollmentQuery = "select * from enrollments";

            using (con = DBUtility.GetConnection())
            {
                try
                {
                    command = new SqlCommand(insertEnrollmentQuery, con);

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        enrollment = new Enrollment();
                        enrollment.EnrollmentID = reader.GetInt32(0);
                        enrollment.StudentID = reader.GetInt32(1);
                        enrollment.CourseID = reader.GetInt32(2);
                        enrollment.EnrollmentDate = reader.GetDateTime(3);
                        enrollments.Add(enrollment);
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            return enrollments;
        }
        public Enrollment GetEnrollmentById(int id)
        {
            Enrollment enrollment = null;
            SqlConnection con = null;
            SqlCommand command = null;
            string insertEnrollmentQuery = "select * from enrollments where enrollment_id = @eid";

            using (con = DBUtility.GetConnection())
            {
                try
                {
                    command = new SqlCommand(insertEnrollmentQuery, con);

                    command.Parameters.AddWithValue("@eid", id);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        enrollment = new Enrollment();
                        enrollment.EnrollmentID = reader.GetInt32(0);
                        enrollment.StudentID = reader.GetInt32(1);
                        enrollment.CourseID = reader.GetInt32(2);
                        enrollment.EnrollmentDate = reader.GetDateTime(3);
                    }

                    if (enrollment == null)
                    {
                        throw new StudentException("Enrollment Id not found!!");
                    }
                }
                catch (SqlException e)
                {
                    throw e;
                }
                catch (Exception e)
                {
                    throw new Exception("Error fetching in enrollment with the given enrollment id: " + e.Message);
                }
            }
            return enrollment;
        }

        public Enrollment GetEnrollmentByStudentId(int enroll_sid)
        {
            Enrollment enrollment = null;
            SqlConnection con = null;
            SqlCommand command = null;
            string insertEnrollmentQuery = "select * from enrollments where student_id = @sid";

            using (con = DBUtility.GetConnection())
            {
                try
                {
                    command = new SqlCommand(insertEnrollmentQuery, con);

                    command.Parameters.AddWithValue("@sid", enroll_sid);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        enrollment = new Enrollment();
                        enrollment.EnrollmentID = reader.GetInt32(0);
                        enrollment.StudentID = reader.GetInt32(1);
                        enrollment.CourseID = reader.GetInt32(2);
                        enrollment.EnrollmentDate = reader.GetDateTime(3);
                    }

                    if (enrollment == null)
                    {
                        throw new EnrollmentException("Student Id in Enrollment not found!!");
                    }
                }
                catch (SqlException e)
                {
                    throw e;
                }
                catch (Exception e)
                {
                    throw new Exception("Error fetching in enrollment with the given student id: " + e.Message);
                }
            }
            return enrollment;
        }

        public Enrollment GetEnrollmentByCourseId(int enroll_cid)
        {
            Enrollment enrollment = null;
            SqlConnection con = null;
            SqlCommand command = null;
            string insertEnrollmentQuery = "select * from enrollments where ecourse_id = @cid";

            using (con = DBUtility.GetConnection())
            {
                try
                {
                    command = new SqlCommand(insertEnrollmentQuery, con);

                    command.Parameters.AddWithValue("@cid", enroll_cid);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        enrollment = new Enrollment();
                        enrollment.EnrollmentID = reader.GetInt32(0);
                        enrollment.StudentID = reader.GetInt32(1);
                        enrollment.CourseID = reader.GetInt32(2);
                        enrollment.EnrollmentDate = reader.GetDateTime(3);
                    }

                    if (enrollment == null)
                    {
                        throw new EnrollmentException("Course Id in Enrollment not found!!");
                    }
                }
                catch (SqlException e)
                {
                    throw e;
                }
                catch (Exception e)
                {
                    throw new Exception("Error fetching in enrollment with the given course id: " + e.Message);
                }
            }
            return enrollment;
        }

        public int UpdateEnrollmentDate(int id, DateTime new_enrollDate)
        {
            int rowsAffected = 0;
            Enrollment enroll = GetEnrollmentById(id);
            if (enroll == null)
            {
                throw new EnrollmentException($"Enrollment not found for the given enrollment {new_enrollDate}");
            }
            else
            {
                string insertEnrollmentQuery = "update enrollments set enrollment_date = @eenrollmentdate where enrollment_id = @eid";
                try
                {
                    using (con = DBUtility.GetConnection())
                    {
                        command = new SqlCommand(insertEnrollmentQuery, con);
                        command.Parameters.AddWithValue("@eid", id);
                        command.Parameters.AddWithValue("@eenrollmentdate", new_enrollDate);
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
