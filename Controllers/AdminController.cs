﻿using Microsoft.AspNetCore.Mvc;

namespace Aesthetica.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("UserEmail") != "admin")
            {
                return RedirectToAction("Login", "Account");
            }

            return View();
        }

        public IActionResult Blog()
        {
            List<Models.BlogPost> blogPosts = new List<Models.BlogPost>
        {
            new Models.BlogPost { Id = 1, Title = "Modern Interior Design Trends 2025", Category = "Interior Design", Author = "Sarah Johnson", AuthorImage = "/images/p1.png", Status = "Published", Date = new DateTime(2025, 1, 15), Thumbnail = "/images/blog1.png" },
            new Models.BlogPost { Id = 2, Title = "Luxury Bedroom Designs", Category = "Decoration", Author = "Mike Wilson", AuthorImage = "/images/p2.png", Status = "Draft", Date = new DateTime(2025, 1, 12), Thumbnail = "/images/blog2.png" }
        };

            return View(blogPosts);
        }

        public IActionResult Budget()
        {
            return View();
        }

        public IActionResult Room()
        {
            return View();
        }

        public IActionResult Career()
        {
            return View();
        }

        public IActionResult JobApplication()
        {
            return View();
        }

        public IActionResult Setting()
        {
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear(); // Session deleted
            return RedirectToAction("Index", "Home"); // return toguest panel
        }

        [HttpPost]
        public ActionResult UpdateProfile(string FirstName, string LastName, string Email, string Bio)
        {
            // Handle profile update logic (Save to DB, validate, etc.)
            TempData["Message"] = "Profile updated successfully!";
            return RedirectToAction("Settings");
        }

        [HttpPost]
        public ActionResult UpdatePassword(string CurrentPassword, string NewPassword, string ConfirmPassword)
        {
            // Handle password update logic (validation, hashing, saving to DB)
            if (NewPassword == ConfirmPassword)
            {
                TempData["Message"] = "Password updated successfully!";
            }
            else
            {
                TempData["Error"] = "Passwords do not match!";
            }
            return RedirectToAction("Settings");
        }
    }
}
