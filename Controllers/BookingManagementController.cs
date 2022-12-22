using Microsoft.AspNetCore.Mvc;
using BookingPlatform.Data;
using BookingPlatform.Models;
using Microsoft.AspNetCore.Authorization;

namespace BookingPlatform.Controllers
{
    public class BookingManagementController : Controller
    {
        private readonly AppDbContext _db;

        public BookingManagementController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Booking> BookingsList = _db.Bookings;
            return View(BookingsList);
        }
        public IActionResult Index1()
        {
            IEnumerable<Booking> BookingsList = _db.Bookings;
          
            return View(BookingsList);
        }

        /// <summary>
        /// (GET)
        /// </summary>
        /// <returns></returns
        public IActionResult EditBooking(int? BookingID)
        {
            if (BookingID == 0 || BookingID == null)
            {
                return NotFound();
            }
            Booking? bookingFromDB = _db.Bookings.Find(BookingID);
            if (bookingFromDB == null)
            {
                return NotFound();
            }
            return View(bookingFromDB);
        }

        /// <summary>
        /// (POST)
        /// </summary>
        /// <param name="adminData"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditBooking(Booking bookingData)
        {
            if (ModelState.IsValid)
            {
                _db.Bookings.Update(bookingData);
                _db.SaveChanges();
                return RedirectToAction("Index", "BookingManagement");
            }
            else
                return View(bookingData);
        }

       
        /// <summary>
        /// (GET)
        /// </summary>
        /// <returns></returns>
   
    }
 }
