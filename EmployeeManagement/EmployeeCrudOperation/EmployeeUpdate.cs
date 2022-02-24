using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using EmployeeManagement.DTO;
using System.Data.SqlClient;
using System.Data;
using EmployeeManagement.Validation;

namespace EmployeeManagement.EmployeeCrudOperation
{
    public class EmployeeUpdate
    {

        private readonly string connectionstring = "server=(LocalDB)\\MSSQLLocalDB; Initial catalog=db_Employee; integrated security=SSPI";
        public void EmployeeUpdateOperation(int employeeId, EmployeeDTO EmployeeDetailsDTO)
        {
            try
            {
                Email_Validation email_Validation = new Email_Validation();
                var booleanValueEmail = email_Validation.ValidateEmail(EmployeeDetailsDTO.EmployeeEmail);
                var booleanValueContact = email_Validation.ValidateContact(EmployeeDetailsDTO.EmployeeContact);
                if (booleanValueEmail)
                {
                    if (booleanValueContact)
                    {
                        using (var connection = new SqlConnection(connectionstring))
                        {

                            var command = new SqlCommand
                            {
                                CommandText = $" UPDATE Employee " +
                                              $"SET  EmployeeName= @employeename, EmployeeUserName = @employeeusername, EmployeeGender=@employeegender, " +
                                              $"EmployeeAddress=@employeeaddress,EmployeeContact=@employeecontact,EmployeeEmail=@employeeemail " +

                                              $"WHERE EmployeeId = @ID",
                                Connection = connection,
                                CommandType = CommandType.Text
                            };
                            command.Parameters.AddWithValue("@employeename", EmployeeDetailsDTO.EmployeeName);
                            command.Parameters.AddWithValue("@employeeusername", EmployeeDetailsDTO.EmployeeUserName);
                            command.Parameters.AddWithValue("@employeegender", EmployeeDetailsDTO.EmployeeGender);
                            command.Parameters.AddWithValue("@employeeaddress", EmployeeDetailsDTO.EmployeeAddress);
                            command.Parameters.AddWithValue("@employeecontact", EmployeeDetailsDTO.EmployeeContact);
                            command.Parameters.AddWithValue("@employeeemail", EmployeeDetailsDTO.EmployeeEmail);


                            command.Parameters.AddWithValue("@Id", employeeId);


                            connection.Open();
                            command.ExecuteNonQuery();

                            connection.Close();

                        }
                    }
                    else
                    {
                        Console.WriteLine("Enter Valid Company Contact");
                    }

                }
                else
                {
                    Console.WriteLine("Enter Valid Company Email");
                }


            }
            catch (Exception updateException)
            {
                Console.WriteLine(updateException.Message);
            }
        }
    }
}
