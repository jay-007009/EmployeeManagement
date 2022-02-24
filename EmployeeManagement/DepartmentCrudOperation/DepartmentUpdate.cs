using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using EmployeeManagement.DTO;
using System.Data.SqlClient;
using System.Data;
using EmployeeManagement.Validation;
using EmployeeManagement.DepartmentCrudOperation;

namespace EmployeeManagement.DepartmentCrudOperation
{
    public class DepartmentUpdate
    {
      
        private readonly string connectionstring = "server=(LocalDB)\\MSSQLLocalDB; Initial catalog=db_Employee; integrated security=SSPI";
        public void DepartmentUpdateOperation(int departmentId, DepartmentDTO DepartmentDetailsDTO)
        {
            try
            {
                
                    using (var connection = new SqlConnection(connectionstring))
                    {

                        var command = new SqlCommand
                        {
                            CommandText = $" UPDATE Department " +
                                          $"SET  DepartmentName= @departmentname, BranchAddress = @branchaddress, DepartmentLead=@departmentlead " +
                                         
                                          $"WHERE DepartmentId = @ID",
                            Connection = connection,
                            CommandType = CommandType.Text
                        };
                        command.Parameters.AddWithValue("@departmentname", DepartmentDetailsDTO.DepartmentName);
                        command.Parameters.AddWithValue("@branchaddress", DepartmentDetailsDTO.BranchAddress);
                        command.Parameters.AddWithValue("@departmentlead", DepartmentDetailsDTO.DepartmentLead);
                        command.Parameters.AddWithValue("@Id", departmentId);
                       
                      
                        connection.Open();
                        command.ExecuteNonQuery();

                        connection.Close();

                    }
                
              

            }
            catch (Exception updateException)
            {
                Console.WriteLine(updateException.Message);
            }
        }
    }
}
