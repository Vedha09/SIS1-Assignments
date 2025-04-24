using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SIS1.Data.IPaymentdao;
using static SIS1.Data.DBUtility;
using SIS1.Models;
using static SIS1.Models.PaymentException;
using SIS1.Data;
using SIS1;

namespace SIS1.Data
{
    internal class SISPaymentdaoImpl : IPaymentdao
    {
        SqlConnection con = null;
        SqlCommand command = null;

        public int AddPayment(Payment payment)
        {
            int rowsAffected = 0;
            string insertPaymentQuery = $"insert into payments (payment_id, student_id, amount, payment_date) values (@pid, @sid, @pamount, @ppaymentdate)";
            try
            {
                using (con = DBUtility.GetConnection())
                {
                    command = new SqlCommand(insertPaymentQuery, con);
                    command.Parameters.Add(new SqlParameter("@pid", payment.PaymentID));
                    command.Parameters.Add(new SqlParameter("@sid", payment.StudentID));
                    command.Parameters.Add(new SqlParameter("@pamount", payment.Amount));
                    command.Parameters.Add(new SqlParameter("@ppayment_date", payment.PaymentDate)); ;
                    rowsAffected = command.ExecuteNonQuery();
                }
                if (rowsAffected <= 0)
                {
                    throw new CourseException("Payment could not be added!!");
                }
            }
            catch (SqlException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw new Exception("Error in adding a new payment.");
            }
            return rowsAffected;
        }

        public int DeletePayment(int id)
        {
            int rowsAffected = 0;
            string insertPaymentQuery = "delete from payments where payment_id = @pid";
            try
            {
                using (con = DBUtility.GetConnection())
                {
                    command = new SqlCommand(insertPaymentQuery, con);
                    command.Parameters.Add(new SqlParameter("@pid", id));
                    rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected <= 0)
                    {
                        throw new PaymentException("Id not found, Couldn't delete payment!!");
                    }
                }
            }
            catch (SqlException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw new Exception("Error in deleting a new payment.");
            }
            return rowsAffected;
        }

        public List<Payment> GetAllPayments()
        {
            List<Payment> payments = new List<Payment>();
            Payment payment = null;
            SqlConnection con = null;
            SqlCommand command = null;
            string insertPaymentQuery = "select * from payments";

            using (con = DBUtility.GetConnection())
            {
                try
                {
                    command = new SqlCommand(insertPaymentQuery, con);

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        payment = new Payment();
                        payment.PaymentID = reader.GetInt32(0);
                        payment.StudentID = reader.GetInt32(1);
                        payment.Amount = reader.GetDecimal(2);
                        payment.PaymentDate = reader.GetDateTime(3);
                        payments.Add(payment);
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            return payments;
        }

        public Payment GetPaymentByStudentID(int sid)
        {
            Payment payment = null;
            SqlConnection con = null;
            SqlCommand command = null;
            string insertPymentQuery = "select * from payments where student_id = @sid";

            using (con = DBUtility.GetConnection())
            {
                try
                {
                    command = new SqlCommand(insertPymentQuery, con);

                    command.Parameters.AddWithValue("@sid", sid);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        payment = new Payment();
                        payment.PaymentID = reader.GetInt32(0);
                        payment.StudentID = reader.GetInt32(1);
                        payment.Amount = reader.GetDecimal(2);
                        payment.PaymentDate = reader.GetDateTime(3);
                    }

                    if (payment == null)
                    {
                        throw new StudentException("Student Id in payment not found!!");
                    }
                }
                catch (SqlException e)
                {
                    throw e;
                }
                catch (Exception e)
                {
                    throw new Exception("Error fetching in payment with the given student id: " + e.Message);
                }
            }
            return payment;
        }

        public Payment GetPaymentById(int id)
        {
            Payment payment = null;
            SqlConnection con = null;
            SqlCommand command = null;
            string insertPaymentQuery = "select * from payments where payment_id = @pid";

            using (con = DBUtility.GetConnection())
            {
                try
                {
                    command = new SqlCommand(insertPaymentQuery, con);

                    command.Parameters.AddWithValue("@pid", id);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        payment = new Payment();
                        payment.PaymentID = reader.GetInt32(0);
                        payment.StudentID = reader.GetInt32(1);
                        payment.Amount = reader.GetDecimal(2);
                        payment.PaymentDate = reader.GetDateTime(3);
                    }

                    if (payment == null)
                    {
                        throw new StudentException("Payment Id not found!!");
                    }
                }
                catch (SqlException e)
                {
                    throw e;
                }
                catch (Exception e)
                {
                    throw new Exception("Error fetching in payment with the given payment id: " + e.Message);
                }
            }
            return payment;
        }

        public int UpdateAmount(int id, decimal new_amtPay)
        {
            int rowsAffected = 0;
            Payment pmt = GetPaymentById(id);
            if (pmt == null)
            {
                throw new StudentException($"Payment not found for the given payment {id}");
            }
            else
            {
                string insertPaymentQuery = "update payments set amount = @pamount where payment_id = @pid";
                try
                {
                    using (con = DBUtility.GetConnection())
                    {
                        command = new SqlCommand(insertPaymentQuery, con);
                        command.Parameters.AddWithValue("@pid", id);
                        command.Parameters.AddWithValue("@pamount", new_amtPay);
                        rowsAffected = command.ExecuteNonQuery();
                    }
                }
                catch (SqlException e)
                {
                    throw e;
                }
                return rowsAffected;
            }
        }
    }
}
