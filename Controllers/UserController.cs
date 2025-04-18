﻿using Aesthetica.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.ComponentModel.DataAnnotations.Schema;


namespace Aesthetica.Controllers
{
    public class UserController : Controller
    {

        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }

        [RoleAuthorize("User")]
        public async Task<IActionResult> Index()
        {
            ViewBag.UserName = HttpContext.Session.GetString("UserName");
            return View();
        }


        public IActionResult Logout()
        {
            HttpContext.Session.Clear(); // Session deleted
            return RedirectToAction("Index", "Home"); // return toguest panel
        }

        public IActionResult Blog()
        {
            return View();
        }

        public IActionResult Style()
        {
            return View();
        }

        public IActionResult Budget()
        {
            //var model = new PaymentViewModel
            //{
            //    // Populate dummy/test values to avoid nulls
            //    UserId=1,
            //    PropertyID = 1,
            //    Amount = 0
            //    // Add other required properties here
            //};
            return View();
        }

        public IActionResult Measure()
        {
            return View();
        }

        public IActionResult Career()
        {
            return View();
        }

        public IActionResult Profile()
        {
            var model = _context.userRegister.FirstOrDefault();

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }
    }
}
