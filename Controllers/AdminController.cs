using BookingPlatform.Data;
using BookingPlatform.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace BookingPlatform.Controllers
{
   
    public class AdminController : Controller
    {
        //A DbContext var to get the tables and do queries to them 
        private readonly AppDbContext _db;
        public AdminController(AppDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// An Action Method that returns a View
        /// </summary>
        /// <returns>The Admins List View</returns>
        public IActionResult Index()
        {
            IEnumerable<Admin> admins = _db.Admins;
            return View(admins);
        }

        /// <summary>
        /// (GET)
        /// An Action Method that returns a View to add new Admin
        /// </summary>
        /// <returns>The Add Admin Form View</returns>
        public IActionResult CreateAdmin()
        {
            return View();
        }

        /// <summary>
        /// (POST)
        /// An Action that recieves the data filled in the form in our View and save it in the DB
        /// </summary>
        /// <param name="adminData"></param>
        /// <returns>The View from the Index Action Method so the Admin list view</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateAdmin(Admin adminData)
        {
            //Maybe the Admin ID is longer than our Matrikel number
            //I will also do it with [Range] DataAnnotation 

            //if (adminData.AdminID.Length > 8)
            //{
            //    ModelState.AddModelError("Lange Matrikelnummer", "Die eingegebenen Matrikelnummer ist länger als die zulässige Eingabelänge.");
            //}
            if (_db.Admins.Contains(adminData))
            {
                ModelState.AddModelError("AdminID", "Die eingegebene Matrikelnummer ist registriert");
            }

            if (ModelState.IsValid)
            {
                _db.Admins.Add(adminData);
                _db.SaveChanges();
                return RedirectToAction("Index", "Admin");
            }
            else
                return View(adminData);
        }

        /// <summary>
        /// (GET)
        /// </summary>
        /// <returns></returns>
        public IActionResult EditAdmin(string? AdminID)
        {
            if (string.IsNullOrWhiteSpace(AdminID))
            {
                return NotFound();
            }
            Admin? adminFromDB = _db.Admins.Find(AdminID);
            if (adminFromDB == null)
            {
                return NotFound();
            }
            return View(adminFromDB);
        }

        /// <summary>
        /// (POST)
        /// </summary>
        /// <param name="adminData"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditAdmin(Admin adminData)
        {
            if (ModelState.IsValid)
            {
                _db.Admins.Update(adminData);
                _db.SaveChanges();
                return RedirectToAction("Index", "Admin");
            }
            else
                return View(adminData);
        }

        /// <summary>
        /// (GET)
        /// </summary>
        /// <returns></returns>
        public IActionResult DeleteAdmin(string? AdminID)
        {
            if (string.IsNullOrWhiteSpace(AdminID))
            {
                return NotFound();
            }
            Admin? adminFromDB = _db.Admins.Find(AdminID);
            if (adminFromDB == null)
            {
                return NotFound();
            }
            return View(adminFromDB);
        }

        /// <summary>
        /// (POST)
        /// </summary>
        /// <param name="adminData"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteAdmin(Admin adminData)
        {
            if (ModelState.IsValid)
            {
                _db.Admins.Remove(adminData);
                _db.SaveChanges();
                return RedirectToAction("Index", "Admin");
            }
            else
                return View(adminData);
        }
    }
}
