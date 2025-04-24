using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using SIS1.Data;
using SIS1.Models;
using SIS1;

namespace SIS1
{
    internal class UserInteface
    {
        public int GetStudentId()
        {
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                return id;
            }
            Console.WriteLine("Invalid Student ID.");
            return GetStudentId();
        }

        public string GetStudentFirstName()
        {
            Console.WriteLine("Enter First Name:");
            return Console.ReadLine();
        }

        public string GetStudentLastName()
        {
            Console.WriteLine("Enter Last Name:");
            return Console.ReadLine();
        }

        public DateTime GetStudentDateOfBirth()
        {
            Console.WriteLine("Enter Date of Birth:");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime dob))
            {
                return dob;
            }
            Console.WriteLine("Invalid date format.");
            return GetStudentDateOfBirth();
        }

        public string GetStudentByEmail()
        {
            Console.WriteLine("Enter Email:");
            return Console.ReadLine();
        }

        public string GetStudentPhoneNumber()
        {
            Console.WriteLine("Enter Phone Number:");
            return Console.ReadLine();
        }
    }
}
