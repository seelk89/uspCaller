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
            string connetionString = "Data Source=DESKTOP-N7MQ963;Initial Catalog=Company;Integrated Security=True";

            while (true)
            {
                Console.WriteLine("Type 1 for: usp_CreateDepartment\nType 2 for: usp_UpdateDepartmentName\nType 3 for: usp_UpdateDepartmentManager\nType q to quit.");
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
