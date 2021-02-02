using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace AdoDotNetAssignment
{
    class WithoutParametrs
    {
        public static void Showdetails()
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            
            try
            {
                cn = new SqlConnection("Data Source=LAPTOP-3BBTJ3JD;Initial Catalog=WFA3DotNet;Integrated Security=True");
                cmd = new SqlCommand("Select * from EmployeeTab", cn);
                cn.Open();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Console.WriteLine($"Employee id:{dr["empid"]} Employee name:{dr["empname"]}  Employee Salary:{dr["salary"]}  Employee Dept no:{dr["deptno"]}");
                    }
                }
                else
                {
                    Console.WriteLine("No employee found");
                }
               
            }
            catch(Exception e)
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
                string empname = Console.ReadLine();
                Console.WriteLine("Employee Salary:");
                decimal salary =Convert.ToDecimal(Console.ReadLine());
                Console.WriteLine("Employee department no:");
                int DeptNo = Convert.ToInt32(Console.ReadLine()); 
                cn = new SqlConnection("Data Source=LAPTOP-3BBTJ3JD;Initial Catalog=WFA3DotNet;Integrated Security=True");
                cmd = new SqlCommand("Insert  EmployeeTab values('"+empname+"',"+salary+","+DeptNo+")", cn);
                cn.Open();
                int i= cmd.ExecuteNonQuery();
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
                int id =Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Employee department no:");
                int DeptNo = Convert.ToInt32(Console.ReadLine());
                cn = new SqlConnection("Data Source=LAPTOP-3BBTJ3JD;Initial Catalog=WFA3DotNet;Integrated Security=True");
                cmd = new SqlCommand("Update  EmployeeTab set DeptNo="+DeptNo+" where empid="+id+"",cn);
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
                    Console.WriteLine("No employee found");
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
                cmd = new SqlCommand("delete EmployeeTab where empid=" + id + "", cn);
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
                    Console.WriteLine("No such employee found");
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
                cn = new SqlConnection("Data Source=LAPTOP-3BBTJ3JD;Initial Catalog=WFA3DotNet;Integrated Security=True");
                Console.WriteLine("Employee id:");
                int id = Convert.ToInt32(Console.ReadLine());
                cmd = new SqlCommand("Select * from EmployeeTab where empid="+id+"", cn);
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

    class Program
    {
        static void Main(string[] args)
        {
            Boolean b = true;
            while (b)
            {
                Console.WriteLine("We are in WithOut parameters ");
                Console.WriteLine("1.Employee Details");
                Console.WriteLine("2.Insert Employee");
                Console.WriteLine("3.Update Employee details");
                Console.WriteLine("4.Delete Employee details");
                Console.WriteLine("5.Search Employee in table");
                Console.WriteLine("Please choose one Option");
                int n = Convert.ToInt32(Console.ReadLine());
                switch (n)
                {
                    case 1:
                        WithoutParametrs.Showdetails();
                        break;
                    case 2:
                        WithoutParametrs.InsertEmployee();
                        break;
                    case 3:
                        WithoutParametrs.UpdateEmployeeDetails();
                        break;
                    case 4:
                        WithoutParametrs.DeleteEmployeeDetails();
                        break;
                    case 5:
                        WithoutParametrs.SearchEmployeedetails();
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
