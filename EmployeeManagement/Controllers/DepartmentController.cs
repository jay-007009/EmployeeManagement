using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.DTO;
using EmployeeManagement.DepartmentCrudOperation;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        // GET: api/<DepartmentController>
        [HttpGet]
        public List<DepartmentDTO> Get()
        {
            DepartmentView departmentget = new DepartmentView();

            return departmentget.DisplayDepartment();
        }

        // GET api/<DepartmentController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<DepartmentController>
        [HttpPost]
        public void Post([FromBody] DepartmentDTO departmentDetailsDTO)
        {
            DepartmentInsert addDepartment = new DepartmentInsert();
            addDepartment.DepartmentInsertOperation(departmentDetailsDTO);
        }

        // PUT api/<DepartmentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] DepartmentDTO DepartmentDetailsDTO)
        {
            DepartmentUpdate updateDepartment = new DepartmentUpdate();
            updateDepartment.DepartmentUpdateOperation(id, DepartmentDetailsDTO);
        }

        // DELETE api/<DepartmentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            DepartmentDelete departmentdelete = new DepartmentDelete();
            departmentdelete.DepartmentDeleteOperationByID(id);
        }
    }
}
