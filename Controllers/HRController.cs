using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml.Style;
using OfficeOpenXml;
using ST10140587_Prog6212_Part2.Data;
using ST10140587_Prog6212_Part2.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Security.Claims;

namespace ST10140587_Prog6212_Part2.Controllers
{
    [Authorize(Roles = "HR")]
    public class HRController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HRController(ApplicationDbContext context)
        {
            _context = context;
        }

        // View Approved Claims
        public async Task<IActionResult> ViewApprovedClaims()
        {
            var approvedClaims = await _context.Claims
                .Where(c => c.Status == "Approved")
                .ToListAsync();

            return View(approvedClaims);
        }

        public IActionResult GeneratePdfReport()
        {
            var claims = _context.Claims.Where(c => c.Status == "Approved").ToList();

            // Create a temporary file path for the PDF
            string filePath = Path.Combine(Path.GetTempPath(), "ApprovedClaimsReport.pdf");

            using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                using (var writer = new StreamWriter(fileStream))
                {
                    writer.WriteLine("Approved Claims Report");
                    writer.WriteLine("Generated on: " + DateTime.Now.ToString("g"));
                    writer.WriteLine("-----------------------------------");

                    // Add headers
                    writer.WriteLine($"{"Lecturer Name",-20} {"Hours Worked",-15} {"Hourly Rate",-15} {"Total Payment",-15}");

                    // Add claim details
                    foreach (var claim in claims)
                    {
                        writer.WriteLine($"{claim.LecturerName,-20} {claim.HoursWorked,-15} {claim.HourlyRate,-15:C} {(claim.HoursWorked * claim.HourlyRate),-15:C}");
                    }

                    writer.WriteLine("-----------------------------------");
                }
            }

            // Return the PDF file for download
            byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
            return File(fileBytes, "application/pdf", "ApprovedClaimsReport.pdf");
        }


        public IActionResult GenerateExcelReport()
        {
            // Set the license context (required for EPPlus)
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Approved Claims Report");

                // Add headers
                worksheet.Cells[1, 1].Value = "Lecturer Name";
                worksheet.Cells[1, 2].Value = "Hours Worked";
                worksheet.Cells[1, 3].Value = "Hourly Rate";
                worksheet.Cells[1, 4].Value = "Total Payment";

                // Fetch approved claims
                var claims = _context.Claims.Where(c => c.Status == "Approved").ToList();

                // Add data rows
                int row = 2;
                foreach (var claim in claims)
                {
                    worksheet.Cells[row, 1].Value = claim.LecturerName;
                    worksheet.Cells[row, 2].Value = claim.HoursWorked;
                    worksheet.Cells[row, 3].Value = claim.HourlyRate;
                    worksheet.Cells[row, 4].Value = claim.HoursWorked * claim.HourlyRate;
                    row++;
                }

                // Auto-fit columns for better formatting
                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                // Generate the Excel file in memory
                var excelData = package.GetAsByteArray();

                // Return the file for download
                return File(excelData, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "ApprovedClaimsReport.xlsx");
            }
        }
    }
}