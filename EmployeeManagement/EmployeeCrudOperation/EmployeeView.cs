using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.DTO;
using EmployeeManagement.EmployeeCrudOperation;
namespace EmployeeManagement.EmployeeCrudOperation
{
    public class EmployeeView
    {

        private readonly string connectionstring = "server=(LocalDB)\\MSSQLLocalDB; Initial catalog=db_Employee; integrated security=SSPI";
        public List<EmployeeDTO> DisplayEmployee()
        {


            EmployeeDTO employeeDTO = new EmployeeDTO();
            CompanyDTO companyDTO = new CompanyDTO();
            DepartmentDTO departmentDTO = new DepartmentDTO();
            //  DepartmentDTO departmentDetailsDTO;
            try
            {
                List<EmployeeDTO> employeeDetailsDTOList = new List<EmployeeDTO>();
                using (var connection = new SqlConnection(connectionstring))
                {
                    var command = new SqlCommand
                    {
                        CommandText = "Select e.EmployeeId, e.EmployeeName,e.EmployeeUserName,e.EmployeeGender,e.EmployeeAddress,e.EmployeeContact,e.EmployeeEmail, " +
                        "c.CompanyId,c.CompanyName,d.DepartmentId,d.DepartmentName " +

                                      "from Employee e " +
                                      "Inner join Company c " +
                                      "on e.CompoanyId=c.CompanyId " +
                                      "Inner join Department d " +
                                      "on d.DepartmentId=e.EmployeeId",


                        //CommandText = "Select DepartmentId DepartmentName,BranchAddress,DepartmentLead," +
                        //             "from Department ",

                        Connection = connection,
                        CommandType = CommandType.Text
                    };
                    connection.Open();
                    var sqlReader = command.ExecuteReader();
                    while (sqlReader.Read())
                    {
                        //departmentDetailsDTO = new DepartmentDTO()
                        {
                            employeeDTO.EmployeeID = Convert.ToInt32(sqlReader["EmployeeId"]);
                            employeeDTO.EmployeeName = sqlReader["EmployeeName"].ToString();
                            employeeDTO.EmployeeUserName = sqlReader["EmployeeUserName"].ToString();
                            employeeDTO.EmployeeGender = sqlReader["EmployeeGender"].ToString();
                            employeeDTO.EmployeeAddress = sqlReader["EmployeeAddress"].ToString();
                            employeeDTO.EmployeeContact = sqlReader["EmployeeContact"].ToString();
                            employeeDTO.EmployeeContact = sqlReader["EmployeeContact"].ToString();
                            employeeDTO.EmployeeEmail = sqlReader["EmployeeEmail"].ToString();

                            companyDTO.CompanyID = Convert.ToInt32( sqlReader["CompanyId"]);
                            companyDTO.CompanyName = sqlReader["CompanyName"].ToString();

                            departmentDTO.DepartmentID = Convert.ToInt32(sqlReader["DepartmentId"]);

                            departmentDTO.DepartmentName = sqlReader["DepartmentName"].ToString();



                        };
                        employeeDetailsDTOList.Add(employeeDTO);
                        employeeDTO.DepartmentList.Add(departmentDTO);
                        departmentDTO.CompanyList.Add(companyDTO);
                    }
                    connection.Close();

                }
                return employeeDetailsDTOList;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}
