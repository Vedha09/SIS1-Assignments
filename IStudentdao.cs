using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIS1.Models;
using SIS1;
using System.Data.SqlClient;

namespace SIS1.Data
{
    internal interface IStudentdao
    {
        int AddStudent(Student student);
        int UpdateStudentName(int id, string new_fname);
        int DeleteStudent(int id);
        Student GetStudentByEmail(string email);
        Student GetStudentByFirstName(string name);
        Student GetStudentByLastName(string name);
        Student GetStudentById(int id);
        List<Student> GetAllStudents();
    }
}
