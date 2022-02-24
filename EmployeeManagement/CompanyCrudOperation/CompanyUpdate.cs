using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.CompanyCrudOperation;
using EmployeeManagement.DTO;
using System.Data.SqlClient;
using System.Data;
using EmployeeManagement.Validation;
namespace EmployeeManagement.CompanyCrudOperation
{
    public class CompanyUpdate
    {
     
        private readonly string connectionstring = "server=(LocalDB)\\MSSQLLocalDB; Initial catalog=db_Employee; integrated security=SSPI";
        public void CompanyUpdateOperation(int companyId, CompanyDTO companyDetailsDTO)
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
                                CommandText = $" UPDATE Company " +
                                              $"SET  CompanyName= @companyname, CompanyAddress = @companyaddress, CompanyEmail=@companyemail, " +
                                              $" CompanyContactNo=@companycontactno " +
                                              $"WHERE CompanyId = @ID",
                                Connection = connection,
                                CommandType = CommandType.Text
                            };
                            command.Parameters.AddWithValue("@companyname", companyDetailsDTO.CompanyName);
                            command.Parameters.AddWithValue("@companyaddress", companyDetailsDTO.CompanyAddress);
                            command.Parameters.AddWithValue("@companyemail", companyDetailsDTO.CompanyEmail);
                            command.Parameters.AddWithValue("@companycontactno", companyDetailsDTO.CompanyContactNo);

                            command.Parameters.AddWithValue("@ID", companyId);
                            connection.Open();
                            command.ExecuteNonQuery();

                            connection.Close();

                        }
                    }
                    else
                    {
                        Console.WriteLine("Enter Valid Contact");
                    }
                }
                else
                {
                    Console.WriteLine("Enter Valid Email");
                }

            }
            catch (Exception updateException)
            {
                Console.WriteLine(updateException.Message);
            }
        }
    }
}
