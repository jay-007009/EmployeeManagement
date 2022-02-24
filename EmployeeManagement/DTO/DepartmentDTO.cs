using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.DTO
{
    public class DepartmentDTO
    {
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public string BranchAddress { get; set; }
        public string DepartmentLead { get; set; }
        public int CompanyID { get; set; }
        public List<CompanyDTO> CompanyList { set; get; }
        public List<EmployeeDTO> EmployeeList { set; get; }
        public DepartmentDTO()
        {
            EmployeeList = new List<EmployeeDTO>();
        }
    }
}
