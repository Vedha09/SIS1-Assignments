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
    internal interface ICoursedao
    {
        int AddCourse(Course course);
        int UpdateCourseInstructorName(int id, string new_ciname);
        int DeleteCourse(int id);
        Course GetCourseByCourseName(string name);
        Course GetCourseByCourseCode(int code);
        Course GetCourseById(int id);
        List<Course> GetAllCourses();
    }
}
