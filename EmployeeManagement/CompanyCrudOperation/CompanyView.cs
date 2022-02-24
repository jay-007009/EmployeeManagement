using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.DTO;
using EmployeeManagement.CompanyCrudOperation;
namespace EmployeeManagement.CompanyCrudOperation
{
    public class companyView
    {
        
        private readonly string connectionstring = "server=(LocalDB)\\MSSQLLocalDB; Initial catalog=db_Employee; integrated security=SSPI";
        public List<CompanyDTO> DisplayCompany()
        {
            List<CompanyDTO> companyDetailsDTOList = new List<CompanyDTO>();
           // CompanyDTO companyDetailsDTO;
            try
            {
                using (var connection = new SqlConnection(connectionstring)) 
                {
                    var command = new SqlCommand
                    {
                        CommandText = "Select c.CompanyId,CompanyName,CompanyAddress,CompanyEmail,CompanyContactNo, " +
                                      "d.DepartmentId,DepartmentName,BranchAddress,DepartmentLead,c.CompanyId,e.EmployeeId, "+
                                      "EmployeeName,EmployeeUserName,EmployeeGender,EmployeeAddress,EmployeeContact,EmployeeEmail, "+
                                      "c.CompanyId,d.DepartmentId "+
                                      "from Company c full outer join Department d "+
                                      "on d.CompanyId=c.CompanyId "+
                                      "full outer join Employee e "+
                                      "on e.DepartmentId=d.DepartmentId",
                        Connection = connection,
                        CommandType = CommandType.Text
                    };
                    connection.Open();
                    var sqlReader = command.ExecuteReader();
                    while (sqlReader.Read())
                    {
                        CompanyDTO companyDTO = new CompanyDTO();


                           companyDTO.CompanyID = sqlReader["CompanyId"]  as int? ?? default;
                        companyDTO.CompanyName = sqlReader["CompanyName"].ToString();
                        companyDTO.CompanyAddress = sqlReader["CompanyAddress"].ToString();
                        companyDTO.CompanyEmail = sqlReader["CompanyEmail"].ToString();
                        companyDTO.CompanyContactNo = sqlReader["CompanyContactNo"].ToString();

                        DepartmentDTO departmentDTO = new DepartmentDTO();

                        departmentDTO.DepartmentID = sqlReader["DepartmentId"] as int? ?? default;
                        departmentDTO.DepartmentName = sqlReader["DepartmentName"].ToString();
                        departmentDTO.BranchAddress = sqlReader["BranchAddress"].ToString();
                        departmentDTO.DepartmentLead = sqlReader["DepartmentLead"].ToString();
                        departmentDTO.CompanyID = sqlReader["CompanyId"] as int? ?? default;

                        EmployeeDTO employeeDTO = new EmployeeDTO();

                        employeeDTO.EmployeeID = sqlReader["EmployeeId"] as int? ?? default;
                        employeeDTO.EmployeeName = sqlReader["EmployeeName"].ToString();
                        employeeDTO.EmployeeUserName = sqlReader["EmployeeUserName"].ToString();
                        employeeDTO.EmployeeGender = sqlReader["EmployeeGender"].ToString();
                        employeeDTO.EmployeeAddress = sqlReader["EmployeeAddress"].ToString();
                        employeeDTO.EmployeeContact = sqlReader["EmployeeContact"].ToString();
                        employeeDTO.EmployeeEmail = sqlReader["EmployeeEmail"].ToString();
                        employeeDTO.CompanyID = sqlReader["CompanyId"] as int? ?? default;
                        employeeDTO.DepartmentID = sqlReader["DepartmentId"] as int? ?? default;

                        departmentDTO.EmployeeList.Add(employeeDTO);
                        companyDTO.DepartmentList.Add(departmentDTO);
                        companyDetailsDTOList.Add(companyDTO);
                    }
                    connection.Close();

                }
                return companyDetailsDTOList;
            }
            
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}
