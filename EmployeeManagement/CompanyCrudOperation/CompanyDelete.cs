using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.CompanyCrudOperation
{
    public class CompanyDelete
    {
       

            private readonly string connectionstring = "server=(LocalDB)\\MSSQLLocalDB; Initial catalog=db_Employee; integrated security=SSPI";
            public void CompanyDeleteOperationByID(int companyId)
            {
                try
                {
                    using (var connection = new SqlConnection(connectionstring))
                    {

                        var command = new SqlCommand
                        {
                            CommandText = $"DELETE " +
                                          $"FROM Company " +
                                          $"WHERE CompanyId=@id",
                            Connection = connection,
                            CommandType = CommandType.Text
                        };
                        command.Parameters.AddWithValue("@id", companyId);
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

