using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace AdoDotNetAssignment
{
    class StoredProcedure
    {
        public static void Showdetails()
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            try
            {
                cn = new SqlConnection("Data Source=LAPTOP-3BBTJ3JD;Initial Catalog=WFA3DotNet;Integrated Security=True");
                cmd = new SqlCommand("sp_ShowEmployee", cn);
                cn.Open();
                dr = cmd.ExecuteReader();


                while (dr.Read())
                {
                    Console.WriteLine($"Employee id:{dr["empid"]} Employee name:{dr["empname"]}  Employee Salary:{dr["salary"]}  Employee Dept no:{dr["deptno"]}");
                }


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                cn.Close();
            }
        }
        public static void InsertEmployee()
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            try
            {
                Console.WriteLine("Employee Name:");
                var empname = Console.ReadLine();
                Console.WriteLine("Employee Salary:");
                var salary = Convert.ToDecimal(Console.ReadLine());
                Console.WriteLine("Employee department no:");
                var DeptNo = Convert.ToInt32(Console.ReadLine());
                cn = new SqlConnection("Data Source=LAPTOP-3BBTJ3JD;Initial Catalog=WFA3DotNet;Integrated Security=True");
                cmd = new SqlCommand("sp_InsertEmployee", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@empname", empname);
                cmd.Parameters.AddWithValue("@salary", salary);
                cmd.Parameters.AddWithValue("@deptno", DeptNo);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                Showdetails();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                cn.Close();
            }
        }
        public static void UpdateEmployeeDetails()
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            try
            {
                Showdetails();
                Console.WriteLine("Employee id:");
                int id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Employee Name:");
                var empname = Console.ReadLine();
                Console.WriteLine("Employee Salary:");
                var salary = Convert.ToDecimal(Console.ReadLine());
                Console.WriteLine("Employee department no:");
                var DeptNo = Convert.ToInt32(Console.ReadLine());
                cn = new SqlConnection("Data Source=LAPTOP-3BBTJ3JD;Initial Catalog=WFA3DotNet;Integrated Security=True");
                cmd = new SqlCommand("sp_UpdateEmployee", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                
                cmd.Parameters.AddWithValue("@Empid", id);
                cmd.Parameters.AddWithValue("@empname", empname);
                cmd.Parameters.AddWithValue("@salary", salary);
                cmd.Parameters.AddWithValue("@DeptNo", DeptNo);

                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    Console.WriteLine("One row updated to the table");
                    Console.WriteLine("After updation");
                    Showdetails();
                }
                else
                {
                    Console.WriteLine("NO such Employee Found");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                cn.Close();
            }
        }
        public static void DeleteEmployeeDetails()
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            try
            {
                Showdetails();
                Console.WriteLine("Employee id:");
                int id = Convert.ToInt32(Console.ReadLine());

                cn = new SqlConnection("Data Source=LAPTOP-3BBTJ3JD;Initial Catalog=WFA3DotNet;Integrated Security=True");
                cmd = new SqlCommand("sp_DeleteEmployee", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@empid", id);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    Console.WriteLine("One row Deleted to the table");
                    Console.WriteLine("After Deletion");
                    Showdetails();
                }
                else
                {
                    Console.WriteLine("No Such Employee Found");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                cn.Close();
            }
        }
        public static void SearchEmployeedetails()
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            try
            {
                Console.WriteLine("Employee id:");
                int id = Convert.ToInt32(Console.ReadLine());
                cn = new SqlConnection("Data Source=LAPTOP-3BBTJ3JD;Initial Catalog=WFA3DotNet;Integrated Security=True");
               
                
                cmd = new SqlCommand("sp_SearchEmployee", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@empid", id);
                cn.Open();
                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Console.WriteLine($"Employee id:{dr["empid"]}");
                        Console.WriteLine($"Employee Name:{dr["empname"]}");
                        Console.WriteLine($"Employee Salary:{dr["salary"]}");
                        Console.WriteLine($"Employee Deptno:{dr["Deptno"]}");
                    }
                }
                else
                    Console.WriteLine("Empolyee not found");


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                cn.Close();
            }
        }

    }
    class WithStoredProcedures
    {
        static void Main(string[] args)
        {
            Boolean b = true;
            while (b)
            {
                Console.WriteLine("We are in With Stored Procedures ");
                Console.WriteLine("1.Employee Details");
                Console.WriteLine("2.Insert Employee");
                Console.WriteLine("3.Update Employee details");
                Console.WriteLine("4.Search Employee in table");
                Console.WriteLine("5.Delete Employee in table");
                Console.WriteLine("Please choose one Option");
                int n = Convert.ToInt32(Console.ReadLine());
                switch (n)
                {
                    case 1:
                        StoredProcedure.Showdetails();
                        break;
                    case 2:
                        StoredProcedure.InsertEmployee();
                        break;
                    case 3:
                        StoredProcedure.UpdateEmployeeDetails();
                        break;
                    case 4:
                        StoredProcedure.SearchEmployeedetails();
                        break;
                    case 5:
                        StoredProcedure.DeleteEmployeeDetails();
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }
                Console.WriteLine("Do you want to perform one more Operation");
                string s = Console.ReadLine();
                if (s.Equals("No"))
                    b = false;
            }
        }
    }

}
