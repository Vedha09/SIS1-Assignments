using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIS1.Models;
using SIS1;

namespace SIS1.Data
{
    internal interface IEnrollmentdao
    {
        int AddEnrollment(Enrollment enrollment);
        int UpdateEnrollmentDate(int id, DateTime new_enrollDate);
        int DeleteEnrollment(int id);
        Enrollment GetEnrollmentById(int id);
        Enrollment GetEnrollmentByStudentId(int enroll_sid);
        Enrollment GetEnrollmentByCourseId(int enroll_cid);
        List<Enrollment> GetAllEnrollments();
    }
}
