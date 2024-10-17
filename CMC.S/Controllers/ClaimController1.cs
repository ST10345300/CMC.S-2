using System.Linq;
using Microsoft.AspNetCore.Mvc;
using CMCS.Models;

namespace CMCS.Controllers
{
    public class ClaimController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClaimController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Display the claim submission form for lecturers
        public IActionResult SubmitClaim()
        {
            return View();
        }

        // Handle the claim submission
        [HttpPost]
        public IActionResult SubmitClaim(Claim claim)
        {
            if (ModelState.IsValid)
            {
                _context.Claims.Add(claim);
                _context.SaveChanges();
                return RedirectToAction("ClaimSubmitted");
            }
            return View(claim);
        }

        public IActionResult ClaimSubmitted()
        {
            return View();
        }

        // Coordinator and Manager view to verify claims
        public IActionResult VerifyClaims()
        {
            var pendingClaims = _context.Claims.Where(c => c.ClaimStatus == "Pending").ToList();
            return View(pendingClaims);
        }

        // Approve a claim
        public IActionResult ApproveClaim(int id)
        {
            var claim = _context.Claims.Find(id);
            if (claim != null)
            {
                claim.ClaimStatus = "Approved";
                _context.SaveChanges();
            }
            return RedirectToAction("VerifyClaims");
        }

        // Reject a claim
        public IActionResult RejectClaim(int id)
        {
            var claim = _context.Claims.Find(id);
            if (claim != null)
            {
                claim.ClaimStatus = "Rejected";
                _context.SaveChanges();
            }
            return RedirectToAction("VerifyClaims");
        }
    }

    public class ApplicationDbContext
    {
    }
}
