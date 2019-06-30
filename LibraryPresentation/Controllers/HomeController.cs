using Library.Business;
using Library.Entity;
using Library.Presentation.Core;
using Library.Presentation.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Library.Presentation.Controllers
{
    public class HomeController : Controller
    {

        private readonly IBorrowLogic borrowLogic;

        public HomeController(IBorrowLogic bookingLogic)
        {
            this.borrowLogic = bookingLogic;
        }
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            ViewBag.UserLogged = userId != null;
            var bookings = this.borrowLogic.GetBorrowedBooksByUser(userId);
            var bookingsModel = ControllerProfile.Mapper.Map<List<BorrowedBook>, List<BorrowModel>>(bookings);
            return View(bookingsModel);
        }

    }
}