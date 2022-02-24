using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.EmployeeCrudOperation
{
    public class EmployeeDelete
    {
       

            private readonly string connectionstring = "server=(LocalDB)\\MSSQLLocalDB; Initial catalog=db_Employee; integrated security=SSPI";
            public void EmployeeDeleteOperationByID(int employeeid)
            {
                try
                {
                    using (var connection = new SqlConnection(connectionstring))
                    {

                        var command = new SqlCommand
                        {
                            CommandText = $"DELETE " +
                                          $"FROM Employee " +
                                          $"WHERE EmployeeId=@id",
                            Connection = connection,
                            CommandType = CommandType.Text
                        };
                        command.Parameters.AddWithValue("@id", employeeid);
                        connection.Open();
                        command.ExecuteNonQuery();
                            
                        connection.Close();

                    }
                }
                catch (Exception DeleteException)
                {
                    Console.WriteLine("Enter Valid ID to Delete:" + DeleteException.Message);
                }
            }
        }
    }

