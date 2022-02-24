using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using EmployeeManagement.EmployeeCrudOperation;
using EmployeeManagement.DTO;
using OfficeOpenXml;
using System.IO;
using EmployeeManagement.File_Generation;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExcelfileController : ControllerBase
    {
        private ExcelReportGeneration _report;

        public ExcelfileController(ExcelReportGeneration excelReport)
        {
            _report = excelReport;
        }
        // GET: api/<ExcelfileController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ExcelfileController>/5
        [HttpGet("{id}")]
       
       public void GenerateReport(int id)
        {
            //ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            //var file = new FileInfo(@"C:\Employee.xlsx");
            //var reportfile = _report.GenerateReport(id);

            //ExcelPackage excelPackage = new ExcelPackage(file);
            //var worksheet = excelPackage.Workbook.Worksheets.Add("REportofEmployee");
            //var range = worksheet.Cells["A1"].LoadFromCollection(reportfile, true);
            //range.AutoFitColumns();
            //worksheet.Cells["B1:B1"].AutoFilter = true;
            //excelPackage.Save();
        }

        // POST api/<ExcelfileController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ExcelfileController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ExcelfileController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
