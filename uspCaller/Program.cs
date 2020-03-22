using System;
using System.Data;
using System.Data.SqlClient;

namespace uspCaller
{
    class Program
    {
        static void Main(string[] args)
        {
            // But your connection string here.
            string connetionString = "Data Source=BATPC;Initial Catalog=DBD_Company;Integrated Security=True";

            while (true)
            {
                Console.WriteLine("Type 1 for: usp_CreateDepartment\nType 2 for: usp_UpdateDepartmentName\nType 3 for: usp_UpdateDepartmentManager" +
                    "\nType 4 for: usp_DeleteDepartment" +
                    "\nType 5 for: usp_GetDepartment" +
                    "\nType 6 for: usp_GetAllDepartments" +
                    "\nType q to quit.\n");
                string caseSwitch = Console.ReadLine();

                switch (caseSwitch)
                {
                    case "1":
                        {
                            using (SqlConnection con = new SqlConnection(connetionString))
                            {
                                using (SqlCommand cmd = new SqlCommand("usp_CreateDepartment", con))
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;

                                    Console.WriteLine("The new departments name?");
                                    string dName = Console.ReadLine();

                                    Console.WriteLine("SSN of employee to be manager?");
                                    int mgrSSN = int.Parse(Console.ReadLine());

                                    cmd.Parameters.Add("@DName", SqlDbType.VarChar).Value = dName;
                                    cmd.Parameters.Add("@MgrSSN", SqlDbType.Int).Value = mgrSSN;

                                    con.Open();
                                    cmd.ExecuteNonQuery();
                                }
                            }
                            break;
                        }

                    case "2":
                        {
                            using (SqlConnection con = new SqlConnection(connetionString))
                            {
                                using (SqlCommand cmd = new SqlCommand("usp_UpdateDepartmentName", con))
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;

                                    Console.WriteLine("Department number of the deparment to change manager on?");
                                    int dNumber = int.Parse(Console.ReadLine());

                                    Console.WriteLine("New name of department?");
                                    string dName = Console.ReadLine();

                                    cmd.Parameters.Add("@DNumber", SqlDbType.Int).Value = dNumber;
                                    cmd.Parameters.Add("@DName", SqlDbType.VarChar).Value = dName;

                                    con.Open();
                                    cmd.ExecuteNonQuery();
                                }
                            }
                            break;
                        }

                    case "3":
                        {
                            using (SqlConnection con = new SqlConnection(connetionString))
                            {
                                using (SqlCommand cmd = new SqlCommand("usp_UpdateDepartmentManager", con))
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;

                                    Console.WriteLine("Department number of the deparment to change manager on?");
                                    int dNumber = int.Parse(Console.ReadLine());

                                    Console.WriteLine("SSN of the manager switch to?");
                                    int mgrSSN = int.Parse(Console.ReadLine());

                                    cmd.Parameters.Add("@DNumber", SqlDbType.Int).Value = dNumber;
                                    cmd.Parameters.Add("@mgrSSN", SqlDbType.VarChar).Value = mgrSSN;

                                    con.Open();
                                    cmd.ExecuteNonQuery();
                                }
                            }
                            break;
                        }

                    case "4":
                        {
                            using (SqlConnection con = new SqlConnection(connetionString))
                            {
                                using (SqlCommand cmd = new SqlCommand("usp_DeleteDepartment", con))
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;

                                    Console.WriteLine("Department number of the deparment to delete?");
                                    int dNumber = int.Parse(Console.ReadLine());

                                    cmd.Parameters.Add("@DNumber", SqlDbType.Int).Value = dNumber;

                                    con.Open();
                                    cmd.ExecuteNonQuery();
                                }
                            }
                            break;
                        }

                    case "5":
                        {
                            using (SqlConnection con = new SqlConnection(connetionString))
                            {
                                using (SqlCommand cmd = new SqlCommand("usp_GetDepartment", con))
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;

                                    Console.WriteLine("Department number to select");
                                    int dNumber = int.Parse(Console.ReadLine());

                                    cmd.Parameters.Add("@DNumber", SqlDbType.Int).Value = dNumber;
                                    con.Open();

                                    using (SqlDataReader rdr = cmd.ExecuteReader())
                                    {
                                        while (rdr.Read())
                                        {
                                            string dName = rdr["DName"].ToString();
                                            string number = rdr["DNumber"].ToString();
                                            string mgrSSN = rdr["MgrSSN"].ToString();
                                            string mgrStartDate = rdr["MgrStartDate"].ToString();
                                            string empCount = rdr["EmpCount"].ToString();
                                            Console.WriteLine($"{dName} {number} {mgrSSN} {mgrStartDate} {empCount}");
                                        }
                                        Console.WriteLine("");
                                    }
                                }
                            }
                            break;
                        }

                    case "6":
                        {
                            using (SqlConnection con = new SqlConnection(connetionString))
                            {
                                using (SqlCommand cmd = new SqlCommand("usp_GetAllDepartments", con))
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;

                                    con.Open();
                                    using (SqlDataReader rdr = cmd.ExecuteReader())
                                    {
                                        while (rdr.Read())
                                        {
                                            string dName = rdr["DName"].ToString();
                                            string number = rdr["DNumber"].ToString();
                                            string mgrSSN = rdr["MgrSSN"].ToString();
                                            string mgrStartDate = rdr["MgrStartDate"].ToString();
                                            string empCount = rdr["EmpCount"].ToString();
                                            Console.WriteLine($"{dName} {number} {mgrSSN} {mgrStartDate} {empCount}");
                                        }
                                        Console.WriteLine("");
                                    }
                                }
                            }
                            break;
                        }

                    case "q":
                        {
                            System.Environment.Exit(1);
                            break;
                        }
                }
            }
        }
    }
}
