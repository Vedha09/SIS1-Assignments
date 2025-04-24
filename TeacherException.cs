using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS1.Models
{
    internal class TeacherException : Exception
    {
        public TeacherException(string message) : base(message) { }
    }
}
