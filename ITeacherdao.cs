using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIS1.Models;
using SIS1;

namespace SIS1.Data
{
    internal interface ITeacherdao
    {
        int AddTeacher(Teacher teacher);
        int UpdateExpertise(int id, string new_expert);
        int DeleteTeacher(int id);
        Teacher GetTeacherByFirstName(string name);
        Teacher GetTeacherByLastName(string name);
        Teacher GetTeacherById(int id);
        List<Teacher> GetAllTeachers();
    }
}
