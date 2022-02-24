using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.EmployeeCrudOperation;
using EmployeeManagement.DTO;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        // GET: api/<EmployeeController>
        [HttpGet]
        public List<EmployeeDTO> Get()
        {
            EmployeeView employeeget = new EmployeeView();

            return employeeget.DisplayEmployee();
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public void Post([FromBody] EmployeeDTO employeeDetailsDTO)
        {
            EmployeeInsert employeeInsert = new EmployeeInsert();
            employeeInsert.EmployeeInsertOperation(employeeDetailsDTO);
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] EmployeeDTO EmployeeDetailsDTO)
        {
            EmployeeUpdate employeeupdate = new EmployeeUpdate();
            employeeupdate.EmployeeUpdateOperation(id, EmployeeDetailsDTO);
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            EmployeeDelete employeedelete = new EmployeeDelete();
            employeedelete.EmployeeDeleteOperationByID(id);
        }
    }
}
