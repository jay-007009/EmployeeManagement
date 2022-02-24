using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.CompanyCrudOperation;
using EmployeeManagement.DTO;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        // GET: api/<CompanyController>
        [HttpGet]
        public List<CompanyDTO> Get()
        {
            companyView companyget = new companyView();
            
            return companyget.DisplayCompany();
            
        }

        // GET api/<CopanyController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CopanyController>
        [HttpPost]
        public void Post([FromBody] CompanyDTO companyDetailsDTO)
        {
            CompanyInsert addStudent = new CompanyInsert();
            addStudent.CompanyInsertOperation(companyDetailsDTO);
        }

        // PUT api/<CopanyController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] CompanyDTO companyDetailsDTO)
        {
            CompanyUpdate companyUpdate = new CompanyUpdate();
            companyUpdate.CompanyUpdateOperation(id,companyDetailsDTO);
        }

        // DELETE api/<CopanyController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            CompanyDelete companydelete = new CompanyDelete();
            companydelete.CompanyDeleteOperationByID(id);
        }
    }
}
