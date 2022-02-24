using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.DTO;
using EmployeeManagement.Validation;
using EmployeeManagement.DepartmentCrudOperation;
namespace EmployeeManagement.DepartmentCrudOperation
{
    public class DepartmentInsert
    {
        private readonly string connectionstring = "server=(LocalDB)\\MSSQLLocalDB; Initial catalog=db_Employee; integrated security=SSPI";
        public void DepartmentInsertOperation(DepartmentDTO departmentDetailsDTO)
        {

            try
            {


                using (var connection = new SqlConnection(connectionstring))
                {

                    var command = new SqlCommand
                    {
                        CommandText = $"INSERT INTO Department " +
                                      $"(DepartmentName,BranchAddress,DepartmentLead,CompanyId) " +
                                      $"VALUES (@departmentname,@branchaddress,@departmentlead,@companyid)",
                        Connection = connection,
                        CommandType = CommandType.Text
                    };
                    command.Parameters.AddWithValue("@departmentname", departmentDetailsDTO.DepartmentName);
                    command.Parameters.AddWithValue("@branchaddress", departmentDetailsDTO.BranchAddress);
                    command.Parameters.AddWithValue("@departmentlead", departmentDetailsDTO.DepartmentLead);
                    command.Parameters.AddWithValue("@companyid", departmentDetailsDTO.CompanyID);

                    connection.Open();
                    command.ExecuteNonQuery();

                    connection.Close();

                }
            }


            catch (Exception insertException)
            {
                Console.WriteLine(insertException.Message);
            }
        }
    }
}


