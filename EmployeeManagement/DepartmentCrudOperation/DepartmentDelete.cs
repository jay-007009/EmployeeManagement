using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.DepartmentCrudOperation
{
    public class DepartmentDelete
    {
       

            private readonly string connectionstring = "server=(LocalDB)\\MSSQLLocalDB; Initial catalog=db_Employee; integrated security=SSPI";
            public void DepartmentDeleteOperationByID(int departmentid)
            {
                try
                {
                    using (var connection = new SqlConnection(connectionstring))
                    {

                        var command = new SqlCommand
                        {
                            CommandText = $"DELETE " +
                                          $"FROM Department " +
                                          $"WHERE DepartmentId=@id",
                            Connection = connection,
                            CommandType = CommandType.Text
                        };
                        command.Parameters.AddWithValue("@id", departmentid);
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

