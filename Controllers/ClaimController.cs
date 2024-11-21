using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ST10140587_Prog6212_Part2.Models;
using ST10140587_Prog6212_Part2.Data;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

[Authorize]
public class ClaimsController : Controller
{
    private readonly ApplicationDbContext _dbContext;
    private readonly long _maxFileSize = 5 * 1024 * 1024; // 5 MB
    private readonly string[] _allowedExtensions = { ".pdf", ".docx", ".xlsx" };

    public ClaimsController(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    public IActionResult SubmitClaim()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> SubmitClaim(Claim claim, IFormFile document)
    {
        var userName = User.Identity.Name; // Get the logged-in user's username
        claim.LecturerName = userName; // Assign the lecturer's name to the claim

        // Validate and save the uploaded document
        if (document != null && document.Length > 0)
        {
            var fileExtension = Path.GetExtension(document.FileName).ToLower();
            if (!_allowedExtensions.Contains(fileExtension))
            {
                ModelState.AddModelError("document", "Invalid file type. Only PDF, DOCX, and XLSX files are allowed.");
                return View(claim);
            }

            var uploadsPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");
            if (!Directory.Exists(uploadsPath))
            {
                Directory.CreateDirectory(uploadsPath);
            }

            var filePath = Path.Combine(uploadsPath, document.FileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await document.CopyToAsync(stream);
            }

            claim.DocumentPath = $"/uploads/{document.FileName}";
        }
        else
        {
            ModelState.AddModelError("document", "Please upload a supporting document.");
            return View(claim);
        }

        // Calculate the salary and set the status based on the rules
        claim.Salary = claim.HoursWorked * claim.HourlyRate;

        // Automation rules for claim rejection
        if (claim.HourlyRate > 150 || claim.HoursWorked > 100)
        {
            claim.Status = "Rejected"; // Automatically reject the claim
            TempData["ErrorMessage"] = "Your claim was automatically rejected because it exceeded the allowed criteria.";
        }
        else
        {
            claim.Status = "Pending"; // Send for approval
        }

        // Save the claim to the database
        _dbContext.Claims.Add(claim);
        await _dbContext.SaveChangesAsync();

        // Redirect to Track Claims page
        return RedirectToAction("TrackClaims");
    }

    [Authorize(Roles = "Co-ordinator,Manager")]
    [HttpGet]
    public async Task<IActionResult> ViewPendingClaims()
    {
        try
        {
            var pendingClaims = await _dbContext.Claims.Where(c => c.Status == "Pending").ToListAsync();
            return View(pendingClaims);
        }
        catch (Exception ex)
        {
            ModelState.AddModelError(string.Empty, "An error occurred while fetching the claims. Please try again later.");
            Console.WriteLine(ex.Message);
            return View("Error");
        }
    }

    [Authorize(Roles = "Co-ordinator,Manager,Lecturer")]
    [HttpGet]
    public async Task<IActionResult> TrackClaims()
    {
        try
        {
            IEnumerable<Claim> claims;

            if (User.IsInRole("Co-ordinator") || User.IsInRole("Manager"))
            {
                claims = await _dbContext.Claims.ToListAsync(); // Co-ordinator/Manager can view all claims
            }
            else
            {
                var userName = User.Identity.Name; // Get the logged-in user's name
                claims = await _dbContext.Claims
                    .Where(c => c.LecturerName == userName) // Filter claims by LecturerName
                    .ToListAsync();
            }

            return View(claims);
        }
        catch (Exception ex)
        {
            ModelState.AddModelError(string.Empty, "An error occurred while fetching the claims. Please try again later.");
            Console.WriteLine(ex.Message);
            return View("Error");
        }
    }

    [Authorize(Roles = "Co-ordinator,Manager")]
    [HttpPost]
    public async Task<IActionResult> ApproveClaim(int id)
    {
        try
        {
            var claim = await _dbContext.Claims.FindAsync(id);
            if (claim != null)
            {
                claim.Status = "Approved";
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Claim not found.");
            }
        }
        catch (Exception ex)
        {
            ModelState.AddModelError(string.Empty, "An error occurred while approving the claim. Please try again.");
            Console.WriteLine(ex.Message);
        }
        return RedirectToAction("ViewPendingClaims");
    }

    [Authorize(Roles = "Co-ordinator,Manager")]
    [HttpPost]
    public async Task<IActionResult> RejectClaim(int id)
    {
        try
        {
            var claim = await _dbContext.Claims.FindAsync(id);
            if (claim != null)
            {
                claim.Status = "Rejected";
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Claim not found.");
            }
        }
        catch (Exception ex)
        {
            ModelState.AddModelError(string.Empty, "An error occurred while rejecting the claim. Please try again.");
            Console.WriteLine(ex.Message);
        }
        return RedirectToAction("ViewPendingClaims");
    }

    [Authorize(Roles = "Co-ordinator,Manager")]
    [HttpPost]
    public async Task<IActionResult> DeleteClaim(int id)
    {
        var claim = await _dbContext.Claims.FindAsync(id);
        if (claim != null)
        {
            _dbContext.Claims.Remove(claim);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction("TrackClaims");
        }
        else
        {
            ModelState.AddModelError(string.Empty, "Claim not found.");
            return View("Error");
        }
    }
}
