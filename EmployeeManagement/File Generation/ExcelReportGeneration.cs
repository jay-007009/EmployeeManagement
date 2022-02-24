using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.EmployeeCrudOperation;
using EmployeeManagement.DepartmentCrudOperation;
using EmployeeManagement.CompanyCrudOperation;
using System.IO;
using NPOI.XSSF.UserModel;

namespace EmployeeManagement.File_Generation
{
    public class ExcelReportGeneration
    {
        public string Report()
        {
            List<string> res = new List<string>();
            companyView retriveCompanyDetails = new companyView();
            var companieslist = retriveCompanyDetails.DisplayCompany();
            string filePath = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\CompanyExcelReport.xlsx";

            var workbook = new XSSFWorkbook();
            var sheet = (XSSFSheet)workbook.CreateSheet("Company Details");


            var headerRow = sheet.CreateRow(0);

            headerRow.CreateCell(0).SetCellValue("CompanyId");
            headerRow.CreateCell(1).SetCellValue("CompanyName");
            headerRow.CreateCell(2).SetCellValue("CompanyAddress");
            headerRow.CreateCell(3).SetCellValue("CompanyEmail");
            headerRow.CreateCell(4).SetCellValue("CompanyContactNo");
            headerRow.CreateCell(5).SetCellValue("DepartmentId");
            headerRow.CreateCell(6).SetCellValue("DepartmentName");
            headerRow.CreateCell(7).SetCellValue("BranchAddress");
            headerRow.CreateCell(8).SetCellValue("DepartmentLead");
            headerRow.CreateCell(9).SetCellValue("EmployeeId");
            headerRow.CreateCell(10).SetCellValue("EmployeeName");
            headerRow.CreateCell(11).SetCellValue("EmployeeUserName");
            headerRow.CreateCell(12).SetCellValue("EmployeeGender");
            headerRow.CreateCell(13).SetCellValue("EmployeeAddress");
            headerRow.CreateCell(14).SetCellValue("EmployeeContact");
            headerRow.CreateCell(15).SetCellValue("EmployeeEmail");
          
            sheet.CreateFreezePane(0, 1, 0, 1);
            int rowNumber = 1;

            foreach (var company in companieslist)
            {
                var row = sheet.CreateRow(rowNumber++);

                row.CreateCell(0).SetCellValue(company.CompanyID);
                row.CreateCell(1).SetCellValue(company.CompanyName);
                row.CreateCell(2).SetCellValue(company.CompanyAddress);
                row.CreateCell(3).SetCellValue(company.CompanyEmail);
                row.CreateCell(4).SetCellValue(company.CompanyContactNo);

                foreach (var department in company.DepartmentList)
                {
                    row.CreateCell(5).SetCellValue(department.DepartmentID);
                    row.CreateCell(6).SetCellValue(department.DepartmentName);
                    row.CreateCell(7).SetCellValue(department.BranchAddress);
                    row.CreateCell(8).SetCellValue(department.DepartmentLead);
                    foreach (var employee in department.EmployeeList)
                    {
                        row.CreateCell(9).SetCellValue(employee.EmployeeID);
                        row.CreateCell(10).SetCellValue(employee.EmployeeName);
                        row.CreateCell(11).SetCellValue(employee.EmployeeUserName);
                        row.CreateCell(12).SetCellValue(employee.EmployeeGender);
                        row.CreateCell(13).SetCellValue(employee.EmployeeAddress);
                        row.CreateCell(14).SetCellValue(employee.EmployeeContact);
                        row.CreateCell(15).SetCellValue(employee.EmployeeEmail);
                       
                    }

                }
            }
            for (int column = 0; column <= 15; column++)
            {
                sheet.AutoSizeColumn(column);
            }

            using (FileStream fileStream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                workbook.Write(fileStream);
                fileStream.Dispose();
            }
            return filePath;
        }

        internal object GenerateReport(int id)
        {
            throw new NotImplementedException();
        }
    }
}

