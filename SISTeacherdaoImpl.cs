using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SIS1.Data.ITeacherdao;
using static SIS1.Data.DBUtility;
using SIS1.Models;
using static SIS1.Models.TeacherException;
using SIS1.Data;

namespace SIS1.Data
{
    internal class SISTeacherdaoImpl : ITeacherdao
    {
        SqlConnection con = null;
        SqlCommand command = null;

        public int AddTeacher(Teacher teacher)
        {
            int rowsAffected = 0;
            string insertTeacherQuery = $"insert into teachers (teacher_id, first_name, lastname, email, expertise) values (@tid, @tfirstname, @tlastname, @temail, @texpertise)";
            try
            {
                using (con = DBUtility.GetConnection())
                {
                    command = new SqlCommand(insertTeacherQuery, con);
                    command.Parameters.Add(new SqlParameter("@tid", teacher.TeacherID));
                    command.Parameters.Add(new SqlParameter("@tfirstname", teacher.FirstName));
                    command.Parameters.Add(new SqlParameter("@tlastname", teacher.LastName));
                    command.Parameters.Add(new SqlParameter("@temail", teacher.Email));
                    command.Parameters.Add(new SqlParameter("@texpertise", teacher.Expertise));
                    rowsAffected = command.ExecuteNonQuery();
                }
                if (rowsAffected <= 0)
                {
                    throw new TeacherException("Teacher could not be added!!");
                }
            }
            catch (SqlException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw new Exception("Error in adding a new teacher.");
            }
            return rowsAffected;
        }

        public int DeleteTeacher(int id)
        {
            int rowsAffected = 0;
            string insertTeacherQuery = "delete from teachers where teacher_id = @tid";
            try
            {
                using (con = DBUtility.GetConnection())
                {
                    command = new SqlCommand(insertTeacherQuery, con);
                    command.Parameters.Add(new SqlParameter("@tid", id));
                    rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected <= 0)
                    {
                        throw new TeacherException("Id not found, Couldn't delete teacher!!");
                    }
                }
            }
            catch (SqlException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw new Exception("Error in deleting a new teacher.");
            }
            return rowsAffected;
        }

        public List<Teacher> GetAllTeachers()
        {
            List<Teacher> teachers = new List<Teacher>();
            Teacher teacher = null;
            SqlConnection con = null;
            SqlCommand command = null;
            string insertTeacherQuery = "select * from teachers";

            using (con = DBUtility.GetConnection())
            {
                try
                {
                    command = new SqlCommand(insertTeacherQuery, con);

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        teacher = new Teacher();
                        teacher.TeacherID = reader.GetInt32(0);
                        teacher.FirstName = reader.GetString(1);
                        teacher.LastName = reader.GetString(2);
                        teacher.Email = reader.GetString(3);
                        teacher.Expertise = reader.GetString(4);
                        teachers.Add(teacher);
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            return teachers;
        }

        public Teacher GetTeacherByFirstName(string name)
        {
            Teacher teacher = null;
            SqlConnection con = null;
            SqlCommand command = null;
            string insertTeacherQuery = "select * from teachers where first_name = @tfirstname";

            using (con = DBUtility.GetConnection())
            {
                try
                {
                    command = new SqlCommand(insertTeacherQuery, con);

                    command.Parameters.AddWithValue("@tfirstname", name);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        teacher = new Teacher();
                        teacher.TeacherID = reader.GetInt32(0);
                        teacher.FirstName = reader.GetString(1);
                        teacher.LastName = reader.GetString(2);
                        teacher.Email = reader.GetString(3);
                        teacher.Expertise = reader.GetString(4);
                    }

                    if (teacher == null)
                    {
                        throw new TeacherException("Teacher FirstName not found!!");
                    }
                }
                catch (SqlException e)
                {
                    throw e;
                }
                catch (Exception e)
                {
                    throw new Exception("Error fetching with the given teacher firstname: " + e.Message);
                }
            }
            return teacher;
        }

        public Teacher GetTeacherByLastName(string name)
        {
            Teacher teacher = null;
            SqlConnection con = null;
            SqlCommand command = null;
            string insertTeacherQuery = "select * from students where last_name = @tlastname";

            using (con = DBUtility.GetConnection())
            {
                try
                {
                    command = new SqlCommand(insertTeacherQuery, con);

                    command.Parameters.AddWithValue("@tlastname", name);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        teacher = new Teacher();
                        teacher.TeacherID = reader.GetInt32(0);
                        teacher.FirstName = reader.GetString(1);
                        teacher.LastName = reader.GetString(2);
                        teacher.Email = reader.GetString(3);
                        teacher.Expertise = reader.GetString(4);
                    }

                    if (teacher == null)
                    {
                        throw new TeacherException("Teacher LastName not found!!");
                    }
                }
                catch (SqlException e)
                {
                    throw e;
                }
                catch (Exception e)
                {
                    throw new Exception("Error fetching with the given teacher lastname: " + e.Message);
                }
            }
            return teacher;
        }

        public Teacher GetTeacherById(int id)
        {
            Teacher teacher = null;
            SqlConnection con = null;
            SqlCommand command = null;
            string insertTeacherQuery = "select * from teachers where teacher_id = @tid";

            using (con = DBUtility.GetConnection())
            {
                try
                {
                    command = new SqlCommand(insertTeacherQuery, con);

                    command.Parameters.AddWithValue("@tid", id);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        teacher = new Teacher();
                        teacher.TeacherID = reader.GetInt32(0);
                        teacher.FirstName = reader.GetString(1);
                        teacher.LastName = reader.GetString(2);
                        teacher.Email = reader.GetString(3);
                        teacher.Expertise = reader.GetString(4);
                    }

                    if (teacher == null)
                    {
                        throw new TeacherException("Teacher Id not found!!");
                    }
                }
                catch (SqlException e)
                {
                    throw e;
                }
                catch (Exception e)
                {
                    throw new Exception("Error fetching in teacher with the given teacher id: " + e.Message);
                }
            }
            return teacher;
        }

        public int UpdateExpertise(int id, string new_expert)
        {
            int rowsAffected = 0;
            Teacher tr = GetTeacherById(id);
            if (tr == null)
            {
                throw new TeacherException($"Teacher not found for the given teacher {id}");
            }
            else
            {
                string insertTeacherQuery = "update teachers set expertise = @texpertise where teacher_id = @tid";
                try
                {
                    using (con = DBUtility.GetConnection())
                    {
                        command = new SqlCommand(insertTeacherQuery, con);
                        command.Parameters.AddWithValue("@tid", id);
                        command.Parameters.AddWithValue("@texpertise", new_expert);
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
