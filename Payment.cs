using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS1
{
    internal class Payment
    {
        public int paymentId;
        public int studentId;
        public decimal amount;
        public DateTime paymentDate;

        public int PaymentID { get; set; }
        public int StudentID { get; set; }
        public Student Student { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }

        public Payment() { }
        public Payment(int paymentId, Student student, decimal amount, DateTime paymentDate)
        {
            PaymentID = paymentId;
            Student = student;
            Amount = amount;
            PaymentDate = paymentDate;
        }

        public Payment(int id, decimal amount, DateTime paymentDate)
        {
            this.StudentID = id;
            this.amount = amount;
            this.paymentDate = paymentDate;
        }

        public void DisplayPaymentInfo()
        {
            Console.WriteLine($"Payment ID: {PaymentID}, Student ID: {StudentID}, Amount to be paid: {Amount}, Payment Date: {PaymentDate}");
        }

        public decimal GetPaymentAmount()
        {
            return Amount;
        }

        public DateTime GetPaymentDate()
        {
            return PaymentDate;
        }
    }
}
