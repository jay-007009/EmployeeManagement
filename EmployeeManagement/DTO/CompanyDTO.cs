using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.DTO
{
    public class CompanyDTO
    {
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
       
        public string CompanyAddress { get; set; }
        public string CompanyEmail { get; set; }
        public string CompanyContactNo { get; set; }
        public List<DepartmentDTO> DepartmentList { set; get; }
        public CompanyDTO()
        {
            DepartmentList = new List<DepartmentDTO>();
        }
    }
}
