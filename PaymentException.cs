using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS1.Models
{
    public class PaymentException : Exception
    {
        public PaymentException(string mesaage) : base(mesaage) { }
    }
}
