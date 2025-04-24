using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SIS1.Data.IStudentdao;
using static SIS1.Data.DBUtility;
using SIS1.Models;
using static SIS1.Models.StudentException;
using SIS1;
using System.Net;

namespace SIS1.Data
{
    internal class SISStudentdaoImpl : IStudentdao
    {
        SqlConnection con = null;
        SqlCommand command = null;

        public int AddStudent(Student student)
        {
            int rowsAffected = 0;
            string insertStudentQuery = $"insert into students (student_id, first_name, last_name, date_of_birth, email, phone_number) values (@sid, @sfirstname, @slastname, @sdateofbirth, @semail, @sphonenumber)";
            try
            {
                using (con = DBUtility.GetConnection())
                {
                    command = new SqlCommand(insertStudentQuery, con);
                    command.Parameters.Add(new SqlParameter("@sid", student.StudentID));
                    command.Parameters.Add(new SqlParameter("@sfirstname", student.FirstName));
                    command.Parameters.Add(new SqlParameter("@slastname", student.LastName));
                    command.Parameters.Add(new SqlParameter("@sdateofbirth", student.DateOfBirth));
                    command.Parameters.Add(new SqlParameter("@semail", student.Email));
                    command.Parameters.Add(new SqlParameter("@sphonenumber", student.PhoneNumber));
                    rowsAffected = command.ExecuteNonQuery();
                }
                if (rowsAffected <= 0)
                {
                    throw new StudentException("Student could not be added!!");
                }
            }
            catch (SqlException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw new Exception("Error in adding a new student.");
            }
            return rowsAffected;
        }

        public int DeleteStudent(int id)
        {
            int rowsAffected = 0;
            string insertStudentQuery = "delete from students where student_id = @sid";
            try
            {
                using (con = DBUtility.GetConnection())
                {
                    command = new SqlCommand(insertStudentQuery, con);
                    command.Parameters.Add(new SqlParameter("@sid", id));
                    rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected <= 0)
                    {
                        throw new StudentException("Id not found, Couldn't delete student!!");
                    }
                }
            }
            catch (SqlException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw new Exception("Error in deleting a new student.");
            }
            return rowsAffected;
        }

        public List<Student> GetAllStudents()
        {
            List<Student> students = new List<Student>();
            Student student = null;
            SqlConnection con = null;
            SqlCommand command = null;
            string insertStudentQuery = "select * from students";

            using (con = DBUtility.GetConnection())
            {
                try
                {
                    command = new SqlCommand(insertStudentQuery, con);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        student = new Student();
                        student.StudentID = reader.GetInt32(0);
                        student.FirstName = reader.GetString(1);
                        student.LastName = reader.GetString(2);
                        student.DateOfBirth = reader.GetDateTime(3);
                        student.Email = reader.GetString(4);
                        student.PhoneNumber = reader.GetString(5);
                        students.Add(student);
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            return students;
        }

        public Student GetStudentByEmail(string email)
        {
            Student student = null;
            SqlConnection con = null;
            SqlCommand command = null;
            string insertStudentQuery = "select * from students where email = @semail";

            using (con = DBUtility.GetConnection())
            {
                try
                {
                    command = new SqlCommand(insertStudentQuery, con);
                    command.Parameters.AddWithValue("@semail", email);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        student = new Student();
                        student.StudentID = reader.GetInt32(0);
                        student.FirstName = reader.GetString(1);
                        student.LastName = reader.GetString(2);
                        student.DateOfBirth = reader.GetDateTime(3);
                        student.Email = reader.GetString(4);
                        student.PhoneNumber = reader.GetString(5);
                    }

                    if (student == null)
                    {
                        throw new StudentException("Student Email not found!!");
                    }
                }
                catch (SqlException e)
                {
                    throw e;
                }
                catch (Exception e)
                {
                    throw new Exception("Error fetching with the given student email: " + e.Message);
                }
            }
            return student;
        }

        public Student GetStudentByFirstName(string name)
        {
            Student student = null;
            SqlConnection con = null;
            SqlCommand command = null;
            string insertStudentQuery = "select * from students where first_name = @sfirstname";

            using (con = DBUtility.GetConnection())
            {
                try
                {
                    command = new SqlCommand(insertStudentQuery, con);
                    command.Parameters.AddWithValue("@sfirstname", name);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        student = new Student();
                        student.StudentID = reader.GetInt32(0);
                        student.FirstName = reader.GetString(1);
                        student.LastName = reader.GetString(2);
                        student.DateOfBirth = reader.GetDateTime(3);
                        student.Email = reader.GetString(4);
                        student.PhoneNumber = reader.GetString(5);
                    }

                    if (student == null)
                    {
                        throw new StudentException("Student FirstName not found!!");
                    }
                }
                catch (SqlException e)
                {
                    throw e;
                }
                catch (Exception e)
                {
                    throw new Exception("Error fetching with the given student firstname: " + e.Message);
                }
            }
            return student;
        }

        public Student GetStudentByLastName(string name)
        {
            Student student = null;
            SqlConnection con = null;
            SqlCommand command = null;
            string insertStudentQuery = "select * from students where last_name = @slastname";
            using (con = DBUtility.GetConnection())
            {
                try
                {
                    command = new SqlCommand(insertStudentQuery, con);
                    command.Parameters.AddWithValue("@slastname", name);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        student = new Student();
                        student.StudentID = reader.GetInt32(0);
                        student.FirstName = reader.GetString(1);
                        student.LastName = reader.GetString(2);
                        student.DateOfBirth = reader.GetDateTime(3);
                        student.Email = reader.GetString(4);
                        student.PhoneNumber = reader.GetString(5);
                    }

                    if (student == null)
                    {
                        throw new StudentException("Student LastName not found!!");
                    }
                }
                catch (SqlException e)
                {
                    throw e;
                }
                catch (Exception e)
                {
                    throw new Exception("Error fetching with the given student lastname: " + e.Message);
                }
            }
            return student;
        }

        public Student GetStudentById(int id)
        {
            Student student = null;
            SqlConnection con = null;
            SqlCommand command = null;
            string insertStudentQuery = "select * from students where student_id = @sid";

            using (con = DBUtility.GetConnection())
            {
                try
                {
                    command = new SqlCommand(insertStudentQuery, con);

                    command.Parameters.AddWithValue("@sid", id);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        student = new Student();
                        student.StudentID = reader.GetInt32(0);
                        student.FirstName = reader.GetString(1);
                        student.LastName = reader.GetString(2);
                        student.DateOfBirth = reader.GetDateTime(3);
                        student.Email = reader.GetString(4);
                        student.PhoneNumber = reader.GetString(5);
                    }

                    if (student == null)
                    {
                        throw new StudentException("Student Id not found!!");
                    }
                }
                catch (SqlException e)
                {
                    throw e;
                }
                catch (Exception e)
                {
                    throw new Exception("Error fetching in student with the given student id: " + e.Message);
                }
            }
            return student;
        }

        public int UpdateStudentName(int id, string new_fname)
        {
            int rowsAffected = 0;
            Student sdt = GetStudentById(id);
            if (sdt == null)
            {
                throw new StudentException($"Student not found for the given student {id}");
            }
            else
            {
                string insertStudentQuery = "update students set first_name = @sfirstname where student_id = @sid";
                try
                {
                    using (con = DBUtility.GetConnection())
                    {
                        command = new SqlCommand(insertStudentQuery, con);
                        command.Parameters.AddWithValue("@sid", id);
                        command.Parameters.AddWithValue("@sfirstname", new_fname);
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
