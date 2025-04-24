using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIS1.Models;
using SIS1;

namespace SIS1.Data
{
    internal interface IPaymentdao
    {
        int AddPayment(Payment payment);
        int UpdateAmount(int id, decimal new_amtPay);
        int DeletePayment(int id);
        Payment GetPaymentByStudentID(int id);
        Payment GetPaymentById(int id);
        List<Payment> GetAllPayments();
    }
}
