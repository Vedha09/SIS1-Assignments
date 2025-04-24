using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS1.Models
{
    public class StudentException : Exception
    {
        public StudentException(string message) : base(message) { }
    }
}
