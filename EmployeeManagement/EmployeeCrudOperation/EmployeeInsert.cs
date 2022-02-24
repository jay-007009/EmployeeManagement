using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.DTO;
using EmployeeManagement.Validation;
using EmployeeManagement.EmployeeCrudOperation;

namespace EmployeeManagement.EmployeeCrudOperation
{
    public class EmployeeInsert
    {
        private readonly string connectionstring = "server=(LocalDB)\\MSSQLLocalDB; Initial catalog=db_Employee; integrated security=SSPI";
        public void EmployeeInsertOperation(EmployeeDTO employeeDetailsDTO)
        {

            try
            {
                Email_Validation email_Validation = new Email_Validation();
                var booleanValueEmail = email_Validation.ValidateEmail(employeeDetailsDTO.EmployeeEmail);
                var booleanValueContact = email_Validation.ValidateContact(employeeDetailsDTO.EmployeeContact);
                if (booleanValueEmail)
                {
                    if (booleanValueContact)
                    {

                        using (var connection = new SqlConnection(connectionstring))
                        {

                            var command = new SqlCommand
                            {
                                CommandText = $"INSERT INTO Employee " +
                                              $"(EmployeeName,EmployeeUserName,EmployeeGender,EmployeeAddress,EmployeeContact,EmployeeEmail,CompanyId,DepartmentId) " +
                                              $"VALUES (@employeename,@employeeusername,@employeegender,@employeeaddress,@employeecontact,@employeeemail,@companyid,@departmentid)",
                                Connection = connection,
                                CommandType = CommandType.Text
                            };
                            command.Parameters.AddWithValue("@employeename", employeeDetailsDTO.EmployeeName);
                            command.Parameters.AddWithValue("@employeeusername", employeeDetailsDTO.EmployeeUserName);
                            command.Parameters.AddWithValue("@employeegender", employeeDetailsDTO.EmployeeGender);
                            command.Parameters.AddWithValue("@employeeaddress", employeeDetailsDTO.EmployeeAddress);
                            command.Parameters.AddWithValue("@employeecontact", employeeDetailsDTO.EmployeeContact);
                            command.Parameters.AddWithValue("@employeeemail", employeeDetailsDTO.EmployeeEmail);
                            command.Parameters.AddWithValue("@companyid", employeeDetailsDTO.CompanyID);
                            command.Parameters.AddWithValue("@departmentid", employeeDetailsDTO.DepartmentID);
                            connection.Open();
                            command.ExecuteNonQuery();

                            connection.Close();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Enter Valid Employee Contact");
                    }
                }
                else
                {
                    Console.WriteLine("Enter Valid Employee Email");
                }
            }


            catch (Exception insertException)
            {
                Console.WriteLine(insertException.Message);
            }
        }
    }
}


