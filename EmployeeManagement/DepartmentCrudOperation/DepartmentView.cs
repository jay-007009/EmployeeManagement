using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.DTO;
using EmployeeManagement.DepartmentCrudOperation;

namespace EmployeeManagement.DepartmentCrudOperation
{
    public class DepartmentView
    {

        private readonly string connectionstring = "server=(LocalDB)\\MSSQLLocalDB; Initial catalog=db_Employee; integrated security=SSPI";
        public List<DepartmentDTO> DisplayDepartment()
        {



            DepartmentDTO departmentDTO = new DepartmentDTO();
            CompanyDTO companyDTO = new CompanyDTO();
          //  DepartmentDTO departmentDetailsDTO;
            try
            {
                List<DepartmentDTO> departmentDetailsDTOList = new List<DepartmentDTO>();
                using (var connection = new SqlConnection(connectionstring))
                {
                    var command = new SqlCommand
                    {
                        CommandText = "Select d.DepartmentId, d.DepartmentName,d.BranchAddress,d.DepartmentLead,c.CompanyName,c.CompanyId " +
                                      "from Department d " +
                                      "Inner join Company c " +
                                      "on d.CompanyId=c.CompanyId",

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
                            departmentDTO.DepartmentID = Convert.ToInt32(sqlReader["DepartmentId"]);
                            departmentDTO.DepartmentName = sqlReader["DepartmentName"].ToString();
                            departmentDTO.BranchAddress = sqlReader["BranchAddress"].ToString();
                            departmentDTO.DepartmentLead = sqlReader["DepartmentLead"].ToString();
                            departmentDTO.CompanyID = Convert.ToInt32(sqlReader["CompanyId"]);

                            companyDTO.CompanyName = sqlReader["CompanyName"].ToString();



                        };
                        departmentDetailsDTOList.Add(departmentDTO);
                        departmentDTO.CompanyList.Add(companyDTO);
                    }
                    connection.Close();

                }
                return departmentDetailsDTOList;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}
