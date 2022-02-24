using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.File_Generation;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportGenerationController : ControllerBase
    {
        ExcelReportGeneration excelReportGeneration = new ExcelReportGeneration();
        // GET: api/<ReportGenerationController>
        [HttpGet]
        public string Get()
        {
            return excelReportGeneration.Report();
        }

        // GET api/<ReportGenerationController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ReportGenerationController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ReportGenerationController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ReportGenerationController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
