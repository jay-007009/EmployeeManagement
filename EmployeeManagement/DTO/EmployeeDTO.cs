using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.DTO
{
    public class EmployeeDTO
    {
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeUserName { get; set; }
        public string EmployeeGender { get; set; }
        public string EmployeeAddress { get; set; }
        public string EmployeeContact { get; set; }
        public string EmployeeEmail { get; set; }
        public int CompanyID { get; set; }
        public int DepartmentID { get; set; }

         public List<CompanyDTO> CompanyList { set; get; }
        public List<DepartmentDTO> DepartmentList { set; get; }
        public EmployeeDTO()
        {
           // CompanyList = new List<CompanyDTO>();
            DepartmentList = new List<DepartmentDTO>();
        }
    }
}
