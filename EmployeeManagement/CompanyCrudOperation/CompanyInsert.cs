using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.DTO;
using EmployeeManagement.Validation;
namespace EmployeeManagement.CompanyCrudOperation
{
    public class CompanyInsert
    {
        private readonly string connectionstring = "server=(LocalDB)\\MSSQLLocalDB; Initial catalog=db_Employee; integrated security=SSPI";
        public void CompanyInsertOperation(CompanyDTO companyDetailsDTO)
        {
            try
            {
                Email_Validation email_Validation = new Email_Validation();
                var booleanValueEmail = email_Validation.ValidateEmail(companyDetailsDTO.CompanyEmail);
                var booleanValueContact = email_Validation.ValidateContact(companyDetailsDTO.CompanyContactNo);
                if (booleanValueEmail)
                {
                    if (booleanValueContact)
                    {
                        using (var connection = new SqlConnection(connectionstring))
                        {

                            var command = new SqlCommand
                            {
                                CommandText = $"INSERT INTO Company " +
                                              $"(CompanyName,CompanyAddress,CompanyEmail,CompanyContactNo) " +
                                              $"VALUES (@Companyname,@Companyaddress,@companyemail,@companycontactno)",
                                Connection = connection,
                                CommandType = CommandType.Text
                            };
                            command.Parameters.AddWithValue("@companyname", companyDetailsDTO.CompanyName);
                            command.Parameters.AddWithValue("@companyaddress", companyDetailsDTO.CompanyAddress);
                            command.Parameters.AddWithValue("@companyemail", companyDetailsDTO.CompanyEmail);
                            command.Parameters.AddWithValue("@companycontactno", companyDetailsDTO.CompanyContactNo);

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
            catch (Exception insertException)
            {
                Console.WriteLine(insertException.Message);
            }
        }
    }
}
